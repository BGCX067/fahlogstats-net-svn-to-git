/*
 * FAHLogStats.NET - Local Path Instance Class
 * Copyright (C) 2006-2007 David Rawling

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
using System.Text;

using NLog;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Instances
{
    public class PathInstance : Base
    {
        const String XmlPropType = "HostType";
        const String XmlPropPath = "Path";

        /// <summary>
        /// Private variable storing location of log files for this instance
        /// </summary>
        private String _Path;
        /// <summary>
        /// Public property storing location of log files for this instance
        /// </summary>
        public String Path
        {
            get { return _Path; }
            set { _Path = value; }
        }

        /// <summary>
        /// Deserialize the object from XML storage
        /// </summary>
        /// <param name="xmlData"></param>
        public override void FromXml(System.Xml.XmlNode xmlData)
        {
            DateTime Start = Debug.ExecStart;
            base.FromXml(xmlData);
            this._Path = xmlData.SelectSingleNode(XmlPropPath).InnerText;
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Serialize the object to XML
        /// </summary>
        /// <returns></returns>
        public override System.Xml.XmlDocument ToXml()
        {
            DateTime Start = Debug.ExecStart;
            System.Xml.XmlDocument xmlDoc = base.ToXml();

            System.Xml.XmlElement xmlTypeEl = xmlDoc.CreateElement(XmlPropType);
            System.Xml.XmlNode xmlType = xmlDoc.CreateNode(System.Xml.XmlNodeType.Text, XmlPropType, String.Empty);
            xmlType.Value = this.GetType().ToString();
            xmlTypeEl.AppendChild(xmlType);

            System.Xml.XmlElement xmlPathEl = xmlDoc.CreateElement(XmlPropPath);
            System.Xml.XmlNode xmlPath = xmlDoc.CreateNode(System.Xml.XmlNodeType.Text, XmlPropPath, String.Empty);
            xmlPath.Value = Path;
            xmlPathEl.AppendChild(xmlPath);

            xmlDoc.ChildNodes[0].AppendChild(xmlTypeEl);
            xmlDoc.ChildNodes[0].AppendChild(xmlPathEl);

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
            return xmlDoc;
        }

        /// <summary>
        /// Retrieve the instance's log files
        /// </summary>
        public override void Retrieve()
        {
            DateTime Start = Debug.ExecStart;

            // Don't retrieve data if we only retrieved successfully less than a minute ago
            if ((LastRetrievalTime + new TimeSpan(0, 1, 0)) > DateTime.Now)
                return;

            if (MakeInstanceDir())
            {
                // Retrieve FAHLog.txt (or equivalent)
                System.IO.FileInfo fiLog = new System.IO.FileInfo(_Path + "\\" + RemoteFAHLogFilename);
                String FAHLog_txt = base.BaseDirectory + LocalFAHLog;
                try { fiLog.CopyTo(FAHLog_txt, true); }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                    return;
                }

                // Retrieve UnitInfo.txt (or equivalent)
                System.IO.FileInfo fiUI = new System.IO.FileInfo(_Path + "\\" + RemoteUnitInfoFilename);
                String UnitInfo_txt = base.BaseDirectory + LocalUnitInfo;
                try { fiUI.CopyTo(UnitInfo_txt, true); }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                    return;
                }

                base.Retrieve();
            }

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");

        }
    }
}
