/*
 * FAHLogStats.NET - HTTP Downloader Instance Class
 * Copyright (C) 2006 David Rawling

 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; version 2
 * of the License. See the included file GPLv2.TXT.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.IO;

using NLog;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Instances
{
    public class HTTPInstance : Base
    {
        #region Constants

        const String XmlPropType = "HostType";
        const String XmlPropURL = "URL";
        const String XmlPropUser = "Username";
        const String XmlPropPass = "Password";

        #endregion

        #region Private variables and public properties

        private String _URL;
        public String URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        private String _Username;
        public String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private String _Password;
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        #endregion

        #region XML serialization

        public override void FromXml(System.Xml.XmlNode xmlData)
        {
            base.FromXml(xmlData);
            this._URL = xmlData.SelectSingleNode(XmlPropURL).InnerText;
            this._Username = xmlData.SelectSingleNode(XmlPropUser).InnerText;
            this._Password = xmlData.SelectSingleNode(XmlPropPass).InnerText;
        }

        public override System.Xml.XmlDocument ToXml()
        {
            System.Xml.XmlDocument xmlDoc = base.ToXml();

            System.Xml.XmlElement xmlTypeEl = xmlDoc.CreateElement(XmlPropType);
            System.Xml.XmlNode xmlType = xmlDoc.CreateNode(System.Xml.XmlNodeType.Text, XmlPropType, String.Empty);
            xmlType.Value = this.GetType().ToString();
            xmlTypeEl.AppendChild(xmlType);

            System.Xml.XmlElement xmlURLEl = xmlDoc.CreateElement(XmlPropURL);
            System.Xml.XmlNode xmlURL = xmlDoc.CreateNode(System.Xml.XmlNodeType.Text, XmlPropURL, String.Empty);
            xmlURL.Value = URL;
            xmlURLEl.AppendChild(xmlURL);

            System.Xml.XmlElement xmlUsernameEl = xmlDoc.CreateElement(XmlPropUser);
            System.Xml.XmlNode xmlUsername = xmlDoc.CreateNode(System.Xml.XmlNodeType.Text, XmlPropUser, String.Empty);
            xmlUsername.Value = Username;
            xmlUsernameEl.AppendChild(xmlUsername);

            System.Xml.XmlElement xmlPasswordEl = xmlDoc.CreateElement(XmlPropPass);
            System.Xml.XmlNode xmlPassword = xmlDoc.CreateNode(System.Xml.XmlNodeType.Text, XmlPropPass, String.Empty);
            xmlPassword.Value = Password;
            xmlPasswordEl.AppendChild(xmlPassword);

            xmlDoc.ChildNodes[0].AppendChild(xmlTypeEl);
            xmlDoc.ChildNodes[0].AppendChild(xmlURLEl);
            xmlDoc.ChildNodes[0].AppendChild(xmlUsernameEl);
            xmlDoc.ChildNodes[0].AppendChild(xmlPasswordEl);

            return xmlDoc;
        }

        #endregion

        #region Data retrieval

        /// <summary>
        /// 
        /// </summary>
        public override void Retrieve()
        {
            // If we last retrieved data less than a minute ago, don't do it again
            if ((LastRetrievalTime + new TimeSpan(0, 1, 0)) > DateTime.Now)
                return;

            if (MakeInstanceDir())
            {
                Preferences.PreferenceSet Prefs = Preferences.PreferenceSet.Instance;

                // Download FAHlog.txt
                WebRequest httpc1 = (WebRequest)WebRequest.Create(this._URL + "/" + this.RemoteFAHLogFilename);
                httpc1.Credentials = new NetworkCredential(_Username, _Password);
                httpc1.Method = WebRequestMethods.Http.Get;
                httpc1.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                if (Prefs.UseProxy)
                {
                    httpc1.Proxy = new WebProxy(Prefs.ProxyServer, Prefs.ProxyPort);
                    if (Prefs.UseProxyAuth)
                    {
                        httpc1.Proxy.Credentials = new NetworkCredential(Prefs.ProxyUser, Prefs.ProxyPass);
                    }
                }
                else
                {
                    httpc1.Proxy = null;
                }

                try
                {
                    WebResponse r1 = (WebResponse)httpc1.GetResponse();
                    String FAHLog_txt = base.BaseDirectory + LocalFAHLog;
                    StreamWriter sw1 = new StreamWriter(FAHLog_txt, false);
                    StreamReader sr1 = new StreamReader(r1.GetResponseStream(), Encoding.ASCII);

                    sw1.Write(sr1.ReadToEnd());
                    sw1.Flush();
                    sw1.Close();
                    sr1.Close();
                }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                }

                // Download unitinfo.txt
                WebRequest httpc2 = (WebRequest)WebRequest.Create(this._URL + "/" + this.RemoteUnitInfoFilename);
                httpc2.Credentials = new NetworkCredential(_Username, _Password);
                httpc2.Method = WebRequestMethods.Http.Get;
                httpc2.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                if (Prefs.UseProxy)
                {
                    httpc2.Proxy = new WebProxy(Prefs.ProxyServer, Prefs.ProxyPort);
                    if (Prefs.UseProxyAuth)
                    {
                        httpc2.Proxy.Credentials = new NetworkCredential(Prefs.ProxyUser, Prefs.ProxyPass);
                    }
                }
                else
                {
                    httpc2.Proxy = null;
                }

                try
                {
                    WebResponse r2 = (WebResponse)httpc2.GetResponse();
                    String UnitInfo_txt = base.BaseDirectory + LocalUnitInfo;
                    StreamWriter sw2 = new StreamWriter(UnitInfo_txt, false);
                    StreamReader sr2 = new StreamReader(r2.GetResponseStream(), Encoding.ASCII);

                    sw2.Write(sr2.ReadToEnd());
                    sw2.Flush();
                    sw2.Close();
                    sr2.Close();
                }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                }

                base.Retrieve();
            }
        }

        #endregion
    }
}
