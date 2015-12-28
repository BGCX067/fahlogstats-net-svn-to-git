/*
 * FAHLogStats.NET - Log Parser Helper Class
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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using NLog;

using FAHLogStats.Helpers;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Instances
{
    class LogParser
    {
        private static Logger ClassLogger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Extract the content from the UnitInfo.txt file produced by the folding
        /// console
        /// </summary>
        /// <param name="LogFileName">Full path to local copy of UnitInfo.txt</param>
        /// <param name="Instance">Reference back to the instance to which the
        /// UnitInfo file belongs</param>
        public Boolean ParseUnitInfo (String LogFileName, Base Instance)
        {
            if (!System.IO.File.Exists(LogFileName)) return false;
            DateTime Start = Debug.ExecStart;
            TextReader tr;
            try
            {
                tr = File.OpenText(LogFileName);
            }
            catch (Exception Ex)
            {
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                ClassLogger.Log(LogLevel.Trace, Debug.FunctionName, String.Format("Execution Time: {0}", Debug.GetExecTime(Start)));
                return false;
            }
            while (tr.Peek() != -1)
            {
                String sData = tr.ReadLine();
                if (sData.StartsWith("Name: "))
                {
                    Instance.UnitInfo.ProteinID = ProteinHelper.ExtractProteinID(sData.Substring(6));
                    Instance.UnitInfo.ProteinName = sData.Substring(6);
                }
                else if (sData.StartsWith("Download time: "))
                {
                    Instance.UnitInfo.DownloadTime = DateTime.ParseExact(sData.Substring(15), "MMMM d H:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AssumeUniversal);
                }
                else if (sData.StartsWith("Progress: "))
                {
                    Instance.UnitInfo.PercentComplete = Int32.Parse(sData.Substring(10, sData.IndexOf("%") - 10));
                }
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), ""); 
            return true;
        }

        /// <summary>
        /// Reads through the FAH log file and grabs desired information
        /// </summary>
        /// <param name="LogFileName">Full path to the FAH log file</param>
        /// <param name="Instance">Instance to which the log file data is
        /// attached</param>
        /// <returns></returns>
        public Boolean ParseFAHLog(String LogFileName, Base Instance)
        {
            if (!System.IO.File.Exists(LogFileName)) return false;
            DateTime Start = Debug.ExecStart;
            TextReader FAHlog;
            try
            {
                FAHlog = File.OpenText(LogFileName);
            }
            catch (Exception Ex)
            {
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                return false;
            }
            String s;

            //Regex rCoreVersion =
            //    new Regex("Folding@Home (?<CoreVer>.*) Core", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
            //Regex rProjectNumber =
            //    new Regex("Project: (?<ProjectNumber>.*)", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
            Regex rFramesCompleted =
                new Regex("\\[(?<Timestamp>.*)\\] Completed (?<Completed>.*) out of (?<Total>.*) steps  ((?<Percent>.*))", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
            Regex rProtein =
                new Regex("Protein: (?<Protein>.*)", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
            Regex rCompletedWUs = 
                new Regex("Number of Units Completed: (?<Completed>.*)$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline);

            DateTime time1 = new DateTime(1900, 1, 1, 0, 0, 0);         // Placeholder date
            DateTime time2 = new DateTime(1900, 1, 1, 0, 0, 0);         // Placeholder date
            DateTime time3 = new DateTime(1900, 1, 1, 0, 0, 0);         // Placeholder date

            while (FAHlog.Peek() != -1)
            {
                s = FAHlog.ReadLine();
                //Match mCoreVer = rCoreVersion.Match(s);
                //Match mProjectNumber = rProjectNumber.Match(s);
                Match mFramesCompleted = rFramesCompleted.Match(s);
                Match mProtein = rProtein.Match(s);
                Match mCompletedWUs = rCompletedWUs.Match(s);

                if (mProtein.Success)
                {
                    Instance.UnitInfo.ProteinID = ProteinHelper.ExtractProteinID(mProtein.Result("${Protein}"));
                    Instance.UnitInfo.ProteinName = mProtein.Result("${Protein}");
                }

                if (mFramesCompleted.Success)
                {
                    Instance.UnitInfo.RawFramesComplete = Int32.Parse(mFramesCompleted.Result("${Completed}"));
                    Instance.UnitInfo.RawFramesTotal = Int32.Parse(mFramesCompleted.Result("${Total}"));

                    time1 = time2;
                    time2 = time3;
                    time3 = DateTime.ParseExact(mFramesCompleted.Result("${Timestamp}"), "H:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AssumeUniversal);

                    if (time1.Year != 1900)
                    {
                        // time1 is valid for 2 "sets" ago
                        TimeSpan tDelta = time3.Subtract(time1);

                        Instance.UnitInfo.RawTimePerSection = Convert.ToInt32((tDelta.TotalSeconds) / 2);
                    }
                    else if (time2.Year != 1900)
                    {
                        // time2 is valid for 1 "set" ago
                        TimeSpan tDelta = time3.Subtract(time2);

                        Instance.UnitInfo.RawTimePerSection = Convert.ToInt32(tDelta.TotalSeconds);
                    }
                }

                if (mCompletedWUs.Success)
                {
                    Instance.TotalUnits = Int32.Parse(mCompletedWUs.Result("${Completed}"));
                }
                Application.DoEvents();
            }

            FAHlog.Close();

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
            return true;
        }
    }
}
