/*
 * FAHLogStats.NET - FTP Downloader Instance Class
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
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Xml;

using NLog;

using FAHLogStats.Helpers;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Instances
{
    public class FTPInstance : Base
    {
        #region Constants

        const String XmlPropType = "HostType";
        const String XmlPropServ = "Server";
        const String XmlPropPath = "Path";
        const String XmlPropUser = "Username";
        const String XmlPropPass = "Password";

        #endregion

        #region Private variables and related Public Properties

        /// <summary>
        /// FTP Server name or IP Address
        /// </summary>
        private String _Server;
        /// <summary>
        /// FTP Server name or IP Address
        /// </summary>
        public String Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        /// <summary>
        /// Path to files on remote server
        /// </summary>
        private String _Path;
        public String Path
        {
            get { return _Path; }
            set { _Path = value; }
        }

        /// <summary>
        /// FTP username on remote server
        /// </summary>
        private String _Username;
        public String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        /// <summary>
        /// FTP password on remote server
        /// </summary>
        private String _Password;
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        #endregion

        #region XML Serialization

        /// <summary>
        /// Deserialize the instance from XML
        /// </summary>
        /// <param name="xmlData"></param>
        public override void FromXml(XmlNode xmlData)
        {
            DateTime Start = Debug.ExecStart;

            try { base.FromXml(xmlData); }
            catch { ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, "Cannot load base instance data."), null); }
            try { this._Server = xmlData.SelectSingleNode(XmlPropServ).InnerText; }
            catch { ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, "Cannot load FTP server."), null); }
            try { this._Path = xmlData.SelectSingleNode(XmlPropPath).InnerText; }
            catch { ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, "Cannot load FTP path."), null); }
            try { this._Username = xmlData.SelectSingleNode(XmlPropUser).InnerText; }
            catch { ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, "Cannot load FTP username."), null); }
            try { this._Password = xmlData.SelectSingleNode(XmlPropPass).InnerText; }
            catch { ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, "Cannot load FTP password."), null); }

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Seralize the instance to XML
        /// </summary>
        /// <returns></returns>
        public override System.Xml.XmlDocument ToXml()
        {
            DateTime Start = Debug.ExecStart;

            try
            {
                XmlDocument xmlDoc = base.ToXml();

                xmlDoc.ChildNodes[0].AppendChild(XMLOps.createXmlNode(xmlDoc, XmlPropType, this.GetType().ToString()));
                xmlDoc.ChildNodes[0].AppendChild(XMLOps.createXmlNode(xmlDoc, XmlPropServ, Server));
                xmlDoc.ChildNodes[0].AppendChild(XMLOps.createXmlNode(xmlDoc, XmlPropPath, Path));
                xmlDoc.ChildNodes[0].AppendChild(XMLOps.createXmlNode(xmlDoc, XmlPropUser, Username));
                xmlDoc.ChildNodes[0].AppendChild(XMLOps.createXmlNode(xmlDoc, XmlPropPass, Password));

                ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
                return xmlDoc;
            }
            catch (Exception Ex)
            {
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                return null;
            }
        }

        #endregion

        #region Data retrieval

        /// <summary>
        /// Retrieve the log and unit info files from the configured FTP location
        /// </summary>
        public override void Retrieve()
        {
            DateTime Start = Debug.ExecStart;

            // If last retrieval was less than a minute ago, don't do it again
            if ((LastRetrievalTime + new TimeSpan(0, 1, 0)) > DateTime.Now)
                return;

            if (MakeInstanceDir())
            {
                Preferences.PreferenceSet Prefs = Preferences.PreferenceSet.Instance;

                // Download FAHlog.txt
                FtpWebRequest ftpc1 = (FtpWebRequest)FtpWebRequest.Create("ftp://" + this._Server + this._Path + this.RemoteFAHLogFilename);
                ftpc1.Method = WebRequestMethods.Ftp.DownloadFile;
                if ((_Username != "") && (_Username != null))
                {
                    if (_Username.Contains("\\"))
                    {
                        String[] UserParts = _Username.Split('\\');
                        ftpc1.Credentials = new NetworkCredential(UserParts[1], _Password, UserParts[0]);
                    }
                    else
                    {
                        ftpc1.Credentials = new NetworkCredential(_Username, _Password);
                    }
                }
                ftpc1.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                if (Prefs.UseProxy)
                {
                    ftpc1.Proxy = new WebProxy(Prefs.ProxyServer, Prefs.ProxyPort);
                    if (Prefs.UseProxyAuth)
                    {
                        ftpc1.Proxy.Credentials = new NetworkCredential(Prefs.ProxyUser, Prefs.ProxyPass);
                    }
                }
                else
                {
                    ftpc1.Proxy = null;
                }

                FtpWebResponse ftpr1;
                try
                {
                    ftpr1 = (FtpWebResponse)ftpc1.GetResponse();
                }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                    return;
                }
                String FAHLog_txt = base.BaseDirectory + LocalFAHLog;
                StreamWriter sw1 = new StreamWriter(FAHLog_txt, false);
                StreamReader sr1 = new StreamReader(ftpr1.GetResponseStream(), Encoding.ASCII);

                sw1.Write(sr1.ReadToEnd());
                sw1.Flush();
                sw1.Close();
                sr1.Close();

                // Download unitinfo.txt
                FtpWebRequest ftpc2 = (FtpWebRequest)FtpWebRequest.Create("ftp://" + this._Server + this._Path + this.RemoteUnitInfoFilename);
                if ((_Username != "") && (_Username != null))
                {
                    if (_Username.Contains("\\"))
                    {
                        String[] UserParts = _Username.Split('\\');
                        ftpc2.Credentials = new NetworkCredential(UserParts[1], _Password, UserParts[0]);
                    }
                    else
                    {
                        ftpc2.Credentials = new NetworkCredential(_Username, _Password);
                    }
                }
                ftpc2.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
                ftpc2.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                if (Prefs.UseProxy)
                {
                    ftpc2.Proxy = new WebProxy(Prefs.ProxyServer, Prefs.ProxyPort);
                    if (Prefs.UseProxyAuth)
                    {
                        ftpc2.Proxy.Credentials = new NetworkCredential(Prefs.ProxyUser, Prefs.ProxyPass);
                    }
                }
                else
                {
                    ftpc2.Proxy = null;
                }

                System.Net.FtpWebResponse ftpr2;
                try
                {
                    ftpr2 = (System.Net.FtpWebResponse)ftpc2.GetResponse();
                }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                    return;
                }
                String UnitInfo_txt = base.BaseDirectory + LocalUnitInfo;
                StreamWriter sw2 = new StreamWriter(UnitInfo_txt, false);
                StreamReader sr2 = new StreamReader(ftpr2.GetResponseStream(), Encoding.ASCII);

                sw2.Write(sr2.ReadToEnd());
                sw2.Flush();
                sw2.Close();
                sr2.Close();

                base.Retrieve();
            }

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        #endregion
    }
}
