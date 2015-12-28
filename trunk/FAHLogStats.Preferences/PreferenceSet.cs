/*
 * FAHLogStats.NET - User Preferences
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
using System.IO;
using System.Text;
using System.Windows.Forms;

using NLog;

using FAHLogStats.Preferences.Properties;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Preferences
{
    public class PreferenceSet
    {
        public const String EOCUserBaseURL = "http://folding.extremeoverclocking.com/user_summary.php?s=&u=";
        public const String EOCTeamBaseURL = "http://folding.extremeoverclocking.com/team_summary.php?s=&t=";
        public const String StanfordBaseURL = "http://fah-web.stanford.edu/cgi-bin/main.py?qtype=userpage&username=";

        private Logger ClassLogger = LogManager.GetCurrentClassLogger();

        #region Public Properties and associated Private Variables
        private Boolean _SyncOnLoad;
        public Boolean SyncOnLoad
        {
            get { return _SyncOnLoad; }
            set { _SyncOnLoad = value; }
        }

        private Boolean _SyncOnSchedule;
        public Boolean SyncOnSchedule
        {
            get { return _SyncOnSchedule; }
            set { _SyncOnSchedule = value; }
        }

        private Int32 _SyncTimeMinutes;
        public Int32 SyncTimeMinutes
        {
            get { return _SyncTimeMinutes; }
            set { _SyncTimeMinutes = value; }
        }

        private Boolean _GenerateWeb;
        public Boolean GenerateWeb
        {
            get { return _GenerateWeb; }
            set { _GenerateWeb = value; }
        }

        private Int32 _GenerateInterval;
        public Int32 GenerateInterval
        {
            get { return _GenerateInterval; }
            set { _GenerateInterval = value; }
        }

        private String _WebRoot;
        public String WebRoot
        {
            get { return _WebRoot; }
            set { _WebRoot = value; }
        }

        private String _CSSFile;
        public String CSSFileName
        {
            get { return _CSSFile; }
            set { _CSSFile = value; }
        }

        private Int32 _EOCUserID;
        public Int32 EOCUserID
        {
            get { return _EOCUserID; }
            set { _EOCUserID = value; }
        }

        private String _StanfordID;
        public String StanfordID
        {
            get { return _StanfordID; }
            set { _StanfordID = value; }
        }

        private String _AppDataPath;
        public String AppDataPath
        {
            get { return _AppDataPath; }
        }

        private String _RegDataPath;
        public String RegDataPath
        {
            get { return _RegDataPath; }
        }

        private Int32 _TeamID;
        public Int32 TeamID
        {
            get { return _TeamID; }
            set { _TeamID = value; }
        }

        private Boolean _UseProxy;
        public Boolean UseProxy
        {
            get { return _UseProxy; }
            set { _UseProxy = value; }
        }

        private String _ProxyServer;
        public String ProxyServer
        {
            get { return _ProxyServer; }
            set { _ProxyServer = value; }
        }

        private Int32 _ProxyPort;
        public Int32 ProxyPort
        {
            get { return _ProxyPort; }
            set { _ProxyPort = value; }
        }

        private Boolean _UseProxyAuth;
        public Boolean UseProxyAuth
        {
            get { return _UseProxyAuth; }
            set { _UseProxyAuth = value; }
        }

        private String _ProxyUser;
        public String ProxyUser
        {
            get { return _ProxyUser; }
            set { _ProxyUser = value; }
        }

        private String _ProxyPass;
        public String ProxyPass
        {
            get { return _ProxyPass; }
            set { _ProxyPass = value; }
        }

        public String AppPath
        {
            get
            {
                String s = System.Reflection.Assembly.GetEntryAssembly().Location;
                String[] sParts = s.Split('\\');
                sParts[sParts.GetUpperBound(0)] = "";
                s = String.Join("\\", sParts);
                s.Trim(new char[] { '\\' });

                return s;
            }
        }

        public string EOCUserURL
        {
            get
            {
                return EOCUserBaseURL + _EOCUserID;
            }
        }

        public string EOCTeamURL
        {
            get
            {
                return EOCTeamBaseURL + _TeamID;
            }
        }

        public string StanfordUserURL
        {
            get
            {
                return StanfordBaseURL + PreferenceSet.Instance.StanfordID;
            }
        }

        #endregion

        #region Singleton Support

        private static PreferenceSet _Instance;
        private static Object classLock = typeof(PreferenceSet);

        public static PreferenceSet Instance
        {
            get
            {
                lock (classLock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new PreferenceSet();
                    }
                }
                return _Instance;
            }
        }

        #endregion

        /// <summary>
        /// Private Constructor to enforce Singleton pattern; loads preferences
        /// </summary>
        private PreferenceSet()
        {
            Load();
        }

        /// <summary>
        /// Load the current set of preferences and adjust for sanity
        /// </summary>
        public void Load()
        {
            DateTime Start = Debug.ExecStart;

            try
            {
                _CSSFile = Settings.Default.CSSFile;
            }
            catch
            {
                _CSSFile = "Blue.CSS";
            }

            if (!Int32.TryParse(Settings.Default.GenerateInterval, out _GenerateInterval))
                _GenerateInterval = 15;
            
            try
            {
                _GenerateWeb = Settings.Default.GenerateWeb;
            }
            catch
            {
                _GenerateWeb = false;
            }
            try
            {
                _SyncOnLoad = Settings.Default.SyncOnLoad;
            }
            catch
            {
                _SyncOnLoad = true;
            }
            try
            {
                _SyncOnSchedule = Settings.Default.SyncOnSchedule;
            }
            catch
            {
                _SyncOnSchedule = true;
            }
            try
            {
                _SyncTimeMinutes = Int32.Parse(Settings.Default.SyncTimeMinutes);
            }
            catch
            {
                _SyncTimeMinutes = 15;
            }
            try
            {
                _WebRoot = Settings.Default.WebRoot;
            }
            catch
            {
                _WebRoot = "C:\\INetPub\\WWWRoot\\MyFolding";
            }
            try
            {
                _EOCUserID = Settings.Default.EOCUserID;
            }
            catch
            {
                _EOCUserID = 0;
            }
            try
            {
                _StanfordID = Settings.Default.StanfordID;
            }
            catch
            {
                _StanfordID = "";
            }
            try
            {
                _TeamID = Settings.Default.TeamID;
            }
            catch
            {
                _TeamID = 0;
            }
            try
            {

                _UseProxy = Settings.Default.UseProxy;
            }
            catch
            {
                _UseProxy = false;
            }
            try
            {
                _ProxyServer = Settings.Default.ProxyServer;
            }
            catch
            {
                _ProxyServer = "";
            }
            try
            {
                _ProxyPort = Settings.Default.ProxyPort;
            }
            catch
            {
                _ProxyPort = 8080;
            }
            try
            {
                _UseProxyAuth = Settings.Default.UseProxyAuth;
            }
            catch
            {
                _UseProxyAuth = false;
            }
            try
            {
                _ProxyUser = Settings.Default.ProxyUser;
            }
            catch
            {
                _ProxyUser = "";
            }
            try
            {
                _ProxyPass = Settings.Default.ProxyPass;
            }
            catch
            {
                _ProxyPass = "";
            }

            String sAppPath = Application.UserAppDataPath;
            String sRegPath = Application.UserAppDataRegistry.ToString();
            String sVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Remove my name from the string - complete waste of space/time
            // Also kill the version number so the settings are cross-version
            sAppPath = sAppPath.Replace("David Rawling", "");
            sAppPath = sAppPath.Replace(sVersion, "");
            while (sAppPath.IndexOf("\\\\") > 0)
                sAppPath = sAppPath.Replace("\\\\", "\\");
            _AppDataPath = sAppPath.Trim('\\');

            if (!Directory.Exists(_AppDataPath))
                Directory.CreateDirectory(_AppDataPath);

            // Remove my name from the string - complete waste of space/time
            // Also kill the version number so the settings are cross-version
            sRegPath = sRegPath.Replace("David Rawling", "");
            sRegPath = sRegPath.Replace("HKEY_CURRENT_USER\\", "");
            sRegPath = sRegPath.Replace(sVersion, "");
            while (sRegPath.IndexOf("\\\\") > 0)
                sRegPath = sRegPath.Replace("\\\\", "\\");
            _RegDataPath = sRegPath.Trim('\\');

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Revert to the previously saved settings
        /// </summary>
        public void Discard()
        {
            Load();
        }
        
        /// <summary>
        /// Save the current settings
        /// </summary>
        public void Save()
        {
            DateTime Start = Debug.ExecStart;

            try
            {
                Settings.Default.CSSFile = _CSSFile;
                Settings.Default.GenerateInterval = _GenerateInterval.ToString();
                Settings.Default.GenerateWeb = _GenerateWeb;
                Settings.Default.SyncOnLoad = _SyncOnLoad;
                Settings.Default.SyncOnSchedule = _SyncOnSchedule;
                Settings.Default.SyncTimeMinutes = _SyncTimeMinutes.ToString();
                Settings.Default.WebRoot = _WebRoot;
                Settings.Default.EOCUserID = _EOCUserID;
                Settings.Default.StanfordID = _StanfordID;
                Settings.Default.TeamID = _TeamID;

                // Proxy Settings
                Settings.Default.UseProxy = _UseProxy;
                Settings.Default.ProxyServer = _ProxyServer;
                Settings.Default.ProxyPort = _ProxyPort;
                Settings.Default.UseProxyAuth = _UseProxyAuth;
                Settings.Default.ProxyUser = _ProxyUser;
                Settings.Default.ProxyPass = _ProxyPass;

                Settings.Default.Save();
            }
            catch (Exception Ex)
            {
                ClassLogger.LogException(LogLevel.Error, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Save on destroy
        /// </summary>
        ~PreferenceSet()
        {
            Save();
        }
    }
}
