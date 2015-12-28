/*
 * FAHLogStats.NET - Base Instance Class
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
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FAHLogStats.Proteins;
using FAHLogStats.Preferences;
using FAHLogStats.Instrumentation;

using NLog;

namespace FAHLogStats.Instances
{
    public abstract class Base
    {
        #region Constants

        private const String xmlAttrName = "Name";
        private const String xmlNodeInstance = "Instance";
        private const String xmlNodeFAHLog = "FAHLogFile";
        private const String xmlNodeUnitInfo = "UnitInfoFile";

        #endregion

        #region Public Properties and Related Private Variables

        private String _InstanceName;
        public String Name
        {
            get { return _InstanceName; }
            set { _InstanceName = value; }
        }

        private Protein _CurrentProtein;
        public Protein CurrentProtein
        {
            get { return _CurrentProtein; }
        }

        private UnitInfo _UnitInfo;
        public UnitInfo UnitInfo
        {
            get { return _UnitInfo; }
        }

        private DateTime _LastRetrieved = new DateTime(1900, 1, 1, 0, 0, 0);
        public DateTime LastRetrievalTime
        {
            get { return _LastRetrieved; }
        }

        private Int32 _TotalUnits;
        public Int32 TotalUnits
        {
            get { return _TotalUnits; }
            set { _TotalUnits = value; }
        }

        private String _RemoteFAHLogFilename = "FAHLog.txt";
        public String RemoteFAHLogFilename
        {
            get { return _RemoteFAHLogFilename; }
            set { _RemoteFAHLogFilename = value; }
        }

        private String _RemoteUnitInfoFilename = "unitinfo.txt";
        public String RemoteUnitInfoFilename
        {
            get { return _RemoteUnitInfoFilename; }
            set { _RemoteUnitInfoFilename = value; }
        }
	

        public String BaseDirectory
        {
            get { return PreferenceSet.Instance.AppDataPath + "\\" + _InstanceName + "\\"; }
        }
  
#endregion

        protected static Logger ClassLogger = LogManager.GetCurrentClassLogger();

        #region Protected Variables

        protected ProteinCollection _Proteins;

        protected const String LocalFAHLog = "FAHLog.txt";
        protected const String LocalUnitInfo = "UnitInfo.txt";

        #endregion

        #region Constructor
        
        /// <summary>
        /// Class constructor
        /// </summary>
        public Base()
        {
            _UnitInfo = new UnitInfo();
            _UnitInfo.DownloadTime = new DateTime(1900, 1, 1, 0, 0, 0);
            _UnitInfo.PercentComplete = 0;
            _UnitInfo.ProteinID = 0;
            _UnitInfo.FramesComplete = 0;
            _UnitInfo.TimeOfLastFrame = new DateTime(1900, 1, 1, 0, 0, 0);
            _UnitInfo.TimePerFrame = new TimeSpan(0, 1, 0, 0);
            _UnitInfo.PPD = 0.0;
            _UnitInfo.UPD = 0.0;

            _CurrentProtein = new Protein();
            _CurrentProtein.Contact = "Unassigned Contact";
            _CurrentProtein.Core = "Unassigned Core";
            _CurrentProtein.Credit = 0;
            _CurrentProtein.Description = "Unassigned Description";
            _CurrentProtein.Frames = 100;
            _CurrentProtein.MaxDays = 0;
            _CurrentProtein.NumAtoms = 0;
            _CurrentProtein.PreferredDays = 0;
            _CurrentProtein.ProjectNumber = 0;
            _CurrentProtein.ServerIP = "0.0.0.0";
            _CurrentProtein.WorkUnitName = "Unassigned Protein";

            _Proteins = Proteins.ProteinCollection.Instance;

        }
        #endregion

        #region Data retrieval

        /// <summary>
        /// Creates the correct directory for the instance log files (local copy)
        /// </summary>
        /// <returns>Whether the directory exists</returns>
        protected Boolean MakeInstanceDir()
        {
            DateTime Start = Debug.ExecStart;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(BaseDirectory);
            if (!di.Exists)
            {
                try
                {
                    di.Create();
                    di.Refresh();
                }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                }
            }

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
            return di.Exists;
        }

        
        public void ProcessExisting()
        {
            DateTime Start = Debug.ExecStart;

            Boolean allGood;

            LogParser lp = new LogParser();
            allGood = lp.ParseUnitInfo(BaseDirectory + "\\" + LocalUnitInfo, this) && lp.ParseFAHLog(BaseDirectory + "\\" + LocalFAHLog, this);

            if (allGood)
            {
                try
                {
                    _CurrentProtein = ProteinCollection.Instance[_UnitInfo.ProteinID];
                }
                catch (System.Collections.Generic.KeyNotFoundException Ex)
                {
                    // Disregard - we don't know the protein name!
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                }
                _LastRetrieved = DateTime.Now;
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }


        /// <summary>
        /// Virtual method - override to define appropriate retrieval semantics for
        /// the subclass. Note: Call base class method from override to correctly
        /// update internal structures.
        /// </summary>
        public virtual void Retrieve()
        {
            ProcessExisting();
        }

        #endregion

        #region XML Serialization

        /// <summary>
        /// Virtual method - override to define appropriate save to XML semantics for
        /// the subclass. Note: Call base class method from override to correctly
        /// save common elements.
        /// </summary>
        public virtual System.Xml.XmlDocument ToXml()
        {
            DateTime Start = Debug.ExecStart;

            try
            {
                System.Xml.XmlDocument xmlData = new System.Xml.XmlDocument();

                System.Xml.XmlElement xmlRoot = xmlData.CreateElement(xmlNodeInstance);
                xmlRoot.SetAttribute(xmlAttrName, Name);
                xmlData.AppendChild(xmlRoot);

                System.Xml.XmlElement xmlLogFile = xmlData.CreateElement(xmlNodeFAHLog);
                xmlLogFile.InnerText = this._RemoteFAHLogFilename;
                xmlRoot.AppendChild(xmlLogFile);

                System.Xml.XmlElement xmlUIFile = xmlData.CreateElement(xmlNodeUnitInfo);
                xmlUIFile.InnerText = this._RemoteUnitInfoFilename;
                xmlRoot.AppendChild(xmlUIFile);

                ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
                return xmlData;
            }
            catch (Exception Ex)
            {
                ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
            }
            return null;
        }
        
        /// <summary>
        /// Virtual method - override to define appropriate load from XML semantics for
        /// the subclass. Note: Call base class method from override to correctly
        /// load common elements.
        /// </summary>
        /// <param name="xmlData">Xml containing the Instance configuration.
        /// Should be identical in structure and scope to the output of the ToXml
        /// method in the same class.</param>
        public virtual void FromXml(System.Xml.XmlNode xmlData)
        {
            DateTime Start = Debug.ExecStart;
            _InstanceName = xmlData.Attributes[xmlAttrName].ChildNodes[0].Value;
            try
            {
                // This is in a try block because older config files don't have
                // this entry; we need to default it. This was introduced in 0.2.26
                _RemoteFAHLogFilename = xmlData.SelectSingleNode(xmlNodeFAHLog).InnerText;
            }
            catch
            {
                _RemoteFAHLogFilename = LocalFAHLog;
            }
            try
            {
                // This is in a try block because older config files don't have
                // this entry; we need to default it. This was introduced in 0.2.26
                _RemoteUnitInfoFilename = xmlData.SelectSingleNode(xmlNodeUnitInfo).InnerText;
            }
            catch
            {
                _RemoteUnitInfoFilename = LocalUnitInfo;
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        #endregion
    }
}
