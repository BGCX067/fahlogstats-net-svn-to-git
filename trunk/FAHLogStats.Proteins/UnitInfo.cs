/*
 * FAHLogStats.NET - Unit Info Class
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
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using NLog;

using FAHLogStats.Helpers;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Proteins
{
    /// <summary>
    /// Contains the state of a protein in progress, as recorded by the UnitInfo.txt file
    /// </summary>
    public class UnitInfo
    {
        private static Logger ClassLogger = LogManager.GetCurrentClassLogger();
        private Boolean _NeedCalcXPD = false;

        /// <summary>
        /// Private member holding the name of the unit
        /// </summary>
        private Int32 _ProteinID;
        /// <summary>
        /// 
        /// </summary>
        public Int32 ProteinID
        {
            get { return _ProteinID; }
            set { _ProteinID = value; }
        }

        /// <summary>
        /// Private member holding the name of the unit
        /// </summary>
        private String _ProteinName;
        /// <summary>
        /// 
        /// </summary>
        public String ProteinName
        {
            get { return _ProteinName; }
            set { _ProteinName = value; }
        }

        /// <summary>
        /// Private member holding the download time of the unit
        /// </summary>
        private DateTime _DownloadTime;
        /// <summary>
        /// Date/time the unit was downloaded
        /// </summary>
        public DateTime DownloadTime
        {
            get { return _DownloadTime; }
            set { _DownloadTime = value; }
        }

        /// <summary>
        /// Private member holding the percentage progress of the unit
        /// </summary>
        private int _PercentComplete;
        /// <summary>
        /// Current progress (percentage) of the unit
        /// </summary>
        public int PercentComplete
        {
            get { return _PercentComplete; }
            set { _PercentComplete = value; }
        }

        /// <summary>
        /// Private member holding the frame progress of the unit
        /// </summary>
        private int _FramesComplete;
        /// <summary>
        /// 
        /// </summary>
        public int FramesComplete
        {
            get { return _FramesComplete; }
            set { _FramesComplete = value; }
        }

        /// <summary>
        /// Private member holding the time per frame of the unit
        /// </summary>
        private TimeSpan _TimePerFrame;
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan TimePerFrame
        {
            get { return _TimePerFrame; }
            set { _TimePerFrame = value; }
        }

        /// <summary>
        /// Private member holding the date and time that the last frame completed
        /// </summary>
        private DateTime _TimeOfLastFrame;
        /// <summary>
        /// The time taken to execute the last frame of the protein
        /// </summary>
        public DateTime TimeOfLastFrame
        {
            get { return _TimeOfLastFrame; }
            set { _TimeOfLastFrame = value; }
        }

        /// <summary>
        /// Private variable holding the PPD rating for this instance
        /// </summary>
        private Double _PPD;
        /// <summary>
        /// PPD rating for this instance
        /// </summary>
        public Double PPD
        {
            get
            {
                if (_NeedCalcXPD) SetTimebasedValues();
                return _PPD;
            }
            set { _PPD = value; }
        }

        /// <summary>
        /// Private variable holding the UPD rating for this instance
        /// </summary>
        private Double _UPD;
        /// <summary>
        /// UPD rating for this instance
        /// </summary>
        public Double UPD
        {
            get
            {
                if (_NeedCalcXPD) SetTimebasedValues();
                return _UPD;
            }
            set { _UPD = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Int32 _RawComplete;
        /// <summary>
        /// 
        /// </summary>
        private Int32 _RawCompleteOld;
        /// <summary>
        /// 
        /// </summary>
        public Int32 RawFramesComplete
        {
            get { return _RawComplete; }
            set
            {
                _RawCompleteOld = _RawComplete;
                _RawComplete = value;
                _NeedCalcXPD = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Int32 _RawTotal;
        /// <summary>
        /// 
        /// </summary>
        public Int32 RawFramesTotal
        {
            get { return _RawTotal; }
            set
            {
                _RawTotal = value;
                _NeedCalcXPD = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Int32 _RawTimePerSection = 0;
        /// <summary>
        /// 
        /// </summary>
        public Int32 RawTimePerSection
        {
            get { return _RawTimePerSection; }
            set
            {
                _RawTimePerSection = value;
                _NeedCalcXPD = true;
            }
        }

        private void SetTimebasedValues ()
        {
            if (!_NeedCalcXPD) return;
            DateTime Start = Debug.ExecStart;
            if ((_RawTotal != 0) && (_RawComplete != 0) && (_RawCompleteOld != 0) && (_RawTimePerSection != 0))
            {
                try
                {
                    Int32 FramesTotal = ProteinCollection.Instance[_ProteinID].Frames;
                    Int32 RawScaleFactor = _RawTotal / FramesTotal;
                    Int32 RawPerTime = _RawComplete - _RawCompleteOld;
                    Double FramesPerTime = RawPerTime / RawScaleFactor;
                    _FramesComplete = _RawComplete / RawScaleFactor;
                    _PercentComplete = _FramesComplete * 100 / FramesTotal;
                    _TimePerFrame = new TimeSpan(0, 0, Convert.ToInt32(_RawTimePerSection / FramesPerTime));
                    if (_TimePerFrame.Hours < 0)
                        _TimePerFrame += new TimeSpan(12, 0, 0);
                    _UPD = 86400 / (_TimePerFrame.TotalSeconds * FramesTotal);
                    _PPD = _UPD * ProteinCollection.Instance[_ProteinID].Credit;
                    _NeedCalcXPD = false;
                }
                catch (Exception Ex)
                {
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                }
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
            return;
        }

        /// <summary>
        /// Parses one line from a UnitInfo file to the correct class property
        /// </summary>
        /// <param name="sData">Line from UnitInfo.txt</param>
        private void ParseUI(String sData)
        {
            DateTime Start = Debug.ExecStart;
            if (sData.StartsWith("Name:"))
            {
                // Dammit, Stanford trims the protein name to 24 characters and some are much longer!
                // Still, grab it as it's a good start, extract the ID and use it
                _ProteinName = sData.Split(' ')[1].Trim();
                _ProteinID = ProteinHelper.ExtractProteinID(_ProteinName);
            }
            else if (sData.StartsWith("Download time:"))
            {
                String sDate = sData.Substring(15).Trim();
                this.DownloadTime = DateTime.ParseExact(sDate, "MMMM d HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AssumeUniversal);
            }
            else if (sData.StartsWith("Progress:"))
            {
                String sProgress = sData.Split(' ')[1].Replace("%", "");
                this.PercentComplete = Int32.Parse(sProgress);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Parses the contents of a UnitInfo.txt file into this instance of the UnitInfo class
        /// </summary>
        /// <param name="sFileName">Name of file to load</param>
        public void ParseFile(String sFileName)
        {
            DateTime Start = Debug.ExecStart;
            System.IO.StreamReader fInput;
            
            try
            {
                fInput = File.OpenText(sFileName);

                while (fInput.Peek() != -1)
                {
                    String sData = fInput.ReadLine();
                    this.ParseUI(sData);
                }

                fInput.Close();
            }
            catch (Exception Ex)
            {
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }
    }
}
