/*
 * FAHLogStats.NET - Instrumentation Class
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
using System.Diagnostics;
using System.Text;

namespace FAHLogStats.Instrumentation
{
    public static class Debug
    {
        /// <summary>
        /// The function name of the caller function (1 stack level up)
        /// </summary>
        /// <returns>Class.Function name </returns>
        public static String FunctionName
        {
            get
            {
                StackFrame sf = new StackFrame(1, true);

                return sf.GetMethod().DeclaringType.ToString() + "." + sf.GetMethod().Name;
            }
        }

        /// <summary>
        /// The function name of the parent function (2 stack levels up)
        /// </summary>
        /// <returns>Class.Function name </returns>
        public static String ParentFunctionName
        {
            get
            {
                StackFrame sf = new StackFrame(2, true);

                return sf.GetMethod().DeclaringType.ToString() + "." + sf.GetMethod().Name;
            }
        }

        /// <summary>
        /// The function name of the grandparent function (3 stack levels up)
        /// </summary>
        /// <returns>Class.Function name </returns>
        public static String GParentFunctionName
        {
            get
            {
                StackFrame sf = new StackFrame(3, true);

                return sf.GetMethod().DeclaringType.ToString() + "." + sf.GetMethod().Name;
            }
        }

        /// <summary>
        /// The filename in which the function can be found
        /// </summary>
        /// <returns></returns>
        public static String FileName
        {
            get
            {
            StackFrame sf = new StackFrame (1, true);

            String[] fileParts = sf.GetFileName().Split('\\');

            return fileParts[fileParts.Length-1];
            }
        }

        /// <summary>
        /// Returns the execution time of the function
        /// </summary>
        /// <param name="Start">The start time as previously returned by ExecStart</param>
        /// <returns>String formatted as "#,##0 ms"</returns>
        public static String GetExecTime(DateTime Start)
        {
            TimeSpan t = DateTime.Now.Subtract(Start);

            return String.Format("{0:#,##0} ms", t.TotalMilliseconds);
        }

        /// <summary>
        /// Simple wrapper around DateTime to return current time (usable for Start Time of a function or operation)
        /// </summary>
        public static DateTime ExecStart
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
