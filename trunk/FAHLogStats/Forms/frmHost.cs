/*
 * FAHLogStats.NET - Host Configuration Form
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using NLog;
using FAHLogStats.Instrumentation;

namespace FAHLogStats.Forms
{
    public partial class frmHost : Form
    {

        private static Logger ClassLogger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public frmHost()
        {
            InitializeComponent();

            // Layout the dialog

            Int32 labelHeight = Convert.ToInt32(TextRenderer.MeasureText("ABgy", lblInstanceName.Font).Height + 2);
            lblInstanceName.Width = Convert.ToInt32(TextRenderer.MeasureText(lblInstanceName.Text, lblInstanceName.Font).Width + 2);
            lblInstanceName.Height = labelHeight;

            lblLogFileName.Width = Convert.ToInt32(TextRenderer.MeasureText(lblLogFileName.Text, lblLogFileName.Font).Width + 2);
            lblLogFileName.Height = labelHeight;

            lblUnitInfoName.Width = Convert.ToInt32(TextRenderer.MeasureText(lblUnitInfoName.Text, lblUnitInfoName.Font).Width + 2);
            lblUnitInfoName.Height = labelHeight;

            lblLogFolder.Width = Convert.ToInt32(TextRenderer.MeasureText(lblLogFolder.Text, lblLogFolder.Font).Width + 2);
            lblLogFolder.Height = labelHeight;

            lblFTPServer.Width = Convert.ToInt32(TextRenderer.MeasureText(lblFTPServer.Text, lblFTPServer.Font).Width + 2);
            lblFTPServer.Height = labelHeight;

            lblFTPPath.Width = Convert.ToInt32(TextRenderer.MeasureText(lblFTPPath.Text, lblFTPPath.Font).Width + 2);
            lblFTPPath.Height = labelHeight;

            lblFTPUser.Width = Convert.ToInt32(TextRenderer.MeasureText(lblFTPUser.Text, lblFTPUser.Font).Width + 2);
            lblFTPUser.Height = labelHeight;

            lblFTPPass.Width = Convert.ToInt32(TextRenderer.MeasureText(lblFTPPass.Text, lblFTPPass.Font).Width + 2);
            lblFTPPass.Height = labelHeight;

            lblWebURL.Width = Convert.ToInt32(TextRenderer.MeasureText(lblWebURL.Text, lblWebURL.Font).Width + 2);
            lblWebURL.Height = labelHeight;

            lblWebUser.Width = Convert.ToInt32(TextRenderer.MeasureText(lblWebUser.Text, lblWebUser.Font).Width + 2);
            lblWebUser.Height = labelHeight;

            lblWebPass.Width = Convert.ToInt32(TextRenderer.MeasureText(lblWebPass.Text, lblWebPass.Font).Width + 2);
            lblWebPass.Height = labelHeight;

            Int32 textboxHeight = Convert.ToInt32(TextRenderer.MeasureText("ABgy", txtName.Font).Height + 2);
            txtName.Height = textboxHeight;
            txtLogFileName.Height = textboxHeight;
            txtUnitFileName.Height = textboxHeight;
            txtLocalPath.Height = textboxHeight;
            txtFTPServer.Height = textboxHeight;
            txtFTPPath.Height = textboxHeight;
            txtFTPUser.Height = textboxHeight;
            txtFTPPass.Height = textboxHeight;
            txtWebURL.Height = textboxHeight;
            txtWebUser.Height = textboxHeight;
            txtWebPass.Height = textboxHeight;

            lblInstanceName.Left = 6;
            lblLogFileName.Left = 6;
            lblUnitInfoName.Left = 6;

            txtName.Top = 6;
            txtLogFileName.Top = txtName.Top + txtName.Height + 6;
            txtUnitFileName.Top = txtLogFileName.Top + txtLogFileName.Height + 6;

            txtUnitFileName.Left = txtLogFileName.Left = txtName.Left = Math.Max(lblLogFileName.Width, lblUnitInfoName.Width) + 12;

            lblInstanceName.Top = txtName.Top + 3;
            lblLogFileName.Top = txtLogFileName.Top + 3;
            lblUnitInfoName.Top = txtUnitFileName.Top + 3;

            radioLocal.Left = 6;
            radioLocal.Top = txtUnitFileName.Top + txtUnitFileName.Height + 8;
            radioLocal.Width = Convert.ToInt32(TextRenderer.MeasureText(radioLocal.Text, radioLocal.Font).Width + 20);
            radioLocal.Height = Convert.ToInt32(TextRenderer.MeasureText(radioLocal.Text, radioLocal.Font).Height + 2);

            grpLocal.Top = radioLocal.Top + radioLocal.Height;
            grpLocal.Left = 24;
            grpLocal.Width = 360;

            txtLocalPath.Top = 18;
            lblLogFolder.Top = 20;
            lblLogFolder.Left = 6;

            btnBrowseLocal.Top = txtLocalPath.Top;
            btnBrowseLocal.Left = grpLocal.Width - btnBrowseLocal.Width - 6;
            btnBrowseLocal.Height = txtLocalPath.Height;

            txtLocalPath.Width = grpLocal.Width - (btnBrowseLocal.Width + 12) - (lblLogFolder.Width + 12);
            txtLocalPath.Left = lblLogFolder.Left + lblLogFolder.Width + 6;
            grpLocal.Height = txtLocalPath.Top + txtLocalPath.Height + 10;

            radioFTP.Top = grpLocal.Top + grpLocal.Height + 6;
            radioFTP.Left = radioLocal.Left;

            grpFTP.Top = radioFTP.Top + radioFTP.Height;
            grpFTP.Left = grpLocal.Left;
            grpFTP.Width = grpLocal.Width;

            lblFTPServer.Left = lblLogFolder.Left;
            lblFTPPass.Left = lblFTPUser.Left = lblFTPPath.Left = lblFTPServer.Left;

            txtFTPServer.Top = txtLocalPath.Top;
            txtFTPPath.Top = txtFTPServer.Top + txtFTPServer.Height + 6;
            txtFTPUser.Top = txtFTPPath.Top + txtFTPPath.Height + 6;
            txtFTPPass.Top = txtFTPUser.Top + txtFTPUser.Height + 6;

            lblFTPServer.Top = txtFTPServer.Top + 2;
            lblFTPPath.Top = txtFTPPath.Top + 2;
            lblFTPUser.Top = txtFTPUser.Top + 2;
            lblFTPPass.Top = txtFTPPass.Top + 2;

            Int32 AlignLeftF = Math.Max(Math.Max(lblFTPServer.Width, lblFTPPath.Width), Math.Max(lblFTPUser.Width, lblFTPPass.Width));
            Int32 AlignLeft = Math.Max(Math.Max(lblWebURL.Width, lblWebUser.Width), Math.Max(lblWebPass.Width, AlignLeftF));
            txtFTPServer.Left = lblFTPServer.Left + AlignLeft + 6;
            txtFTPPass.Left = txtFTPUser.Left = txtFTPPath.Left = txtFTPServer.Left;

            txtFTPServer.Width = txtFTPPath.Width = txtFTPUser.Width = txtFTPPass.Width = grpFTP.Width - AlignLeft - 18;

            grpFTP.Height = txtFTPPass.Top + txtFTPPass.Height + 10;

            radioHTTP.Top = grpFTP.Top + grpFTP.Height + 6;
            radioHTTP.Left = radioFTP.Left;

            grpHTTP.Top = radioHTTP.Top + radioHTTP.Height;
            grpHTTP.Left = grpFTP.Left;
            grpHTTP.Width = grpFTP.Width;

            lblWebPass.Left = lblWebUser.Left = lblWebURL.Left = lblFTPServer.Left;
            txtWebPass.Left = txtWebUser.Left = txtWebURL.Left = txtFTPServer.Left;

            txtWebURL.Top = txtFTPServer.Top;
            txtWebUser.Top = txtFTPPath.Top;
            txtWebPass.Top = txtFTPUser.Top;

            lblWebURL.Top = lblFTPServer.Top;
            lblWebUser.Top = lblFTPPath.Top;
            lblWebPass.Top = lblFTPUser.Top;

            txtWebURL.Width = txtFTPServer.Width;
            txtWebUser.Width = txtFTPPath.Width;
            txtWebPass.Width = txtFTPUser.Width;

            grpHTTP.Height = txtWebPass.Top + txtWebPass.Height + 10;

            btnOK.Top = grpHTTP.Top + grpHTTP.Height + 6;
            btnCancel.Top = btnOK.Top;
            btnCancel.Width = btnOK.Width = 80;
            btnCancel.Left = grpHTTP.Left + grpHTTP.Width - btnCancel.Width;
            btnOK.Left = btnCancel.Left - btnOK.Width - 6;
            btnCancel.Height = btnOK.Height = 2 * labelHeight;

            txtUnitFileName.Width = txtLogFileName.Width = txtName.Width = grpHTTP.Left + grpHTTP.Width - txtLogFileName.Left - 6;

            this.ClientSize = new Size(lblInstanceName.Left + grpHTTP.Left + grpHTTP.Width, btnOK.Top + btnOK.Height + 6);
        }

        #region Radio button management

        /// <summary>
        /// Enable the HTTP controls
        /// </summary>
        /// <param name="bState"></param>
        private void HTTPFieldsActive(Boolean bState)
        {
            DateTime Start = Debug.ExecStart;
            txtWebURL.ReadOnly = !bState;
            txtWebUser.ReadOnly = !bState;
            txtWebPass.ReadOnly = !bState;
            txtWebURL.Enabled = bState;
            txtWebUser.Enabled = bState;
            txtWebPass.Enabled = bState;
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Enable/disable the FTP controls
        /// </summary>
        /// <param name="bState"></param>
        private void FTPFieldsActive(Boolean bState)
        {
            DateTime Start = Debug.ExecStart;
            txtFTPServer.ReadOnly = !bState;
            txtFTPPath.ReadOnly = !bState;
            txtFTPUser.ReadOnly = !bState;
            txtFTPPass.ReadOnly = !bState;
            txtFTPServer.Enabled = bState;
            txtFTPPath.Enabled = bState;
            txtFTPUser.Enabled = bState;
            txtFTPPass.Enabled = bState;
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Enable/disable the local path controls
        /// </summary>
        /// <param name="bState"></param>
        private void PathFieldsActive(Boolean bState)
        {
            DateTime Start = Debug.ExecStart;
            txtLocalPath.ReadOnly = !bState;
            txtLocalPath.Enabled = bState;
            btnBrowseLocal.Enabled = bState;
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Clears validation colours from all text fields (on button change)
        /// </summary>
        private void ClearValidate()
        {
            DateTime Start = Debug.ExecStart;
            txtName.BackColor = System.Drawing.SystemColors.Window;
            txtLocalPath.BackColor = System.Drawing.SystemColors.Window;
            txtFTPServer.BackColor = System.Drawing.SystemColors.Window;
            txtFTPPath.BackColor = System.Drawing.SystemColors.Window;
            txtFTPUser.BackColor = System.Drawing.SystemColors.Window;
            txtFTPPass.BackColor = System.Drawing.SystemColors.Window;
            txtWebURL.BackColor = System.Drawing.SystemColors.Window;
            txtWebUser.BackColor = System.Drawing.SystemColors.Window;
            txtWebPass.BackColor = System.Drawing.SystemColors.Window;
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Configure the form fields according to the selected radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonSet_CheckedChanged(object sender, EventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            ClearValidate();
            if (radioLocal.Checked)
            {
                PathFieldsActive(true);
                FTPFieldsActive(false);
                HTTPFieldsActive(false);
            }
            else if (radioFTP.Checked)
            {
                PathFieldsActive(false);
                FTPFieldsActive(true);
                HTTPFieldsActive(false);
            }
            else if (radioHTTP.Checked)
            {
                PathFieldsActive(false);
                FTPFieldsActive(false);
                HTTPFieldsActive(true);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        #endregion

        #region Local Path Browse functions

        /// <summary>
        /// Display the folder selection dialog. We want a path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseLocal_Click(object sender, EventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            if (txtLocalPath.Text.Length > 0)
                openLogFolder.SelectedPath = txtLocalPath.Text;
            openLogFolder.ShowDialog();
            if (openLogFolder.SelectedPath.Length > 0)
                txtLocalPath.Text = openLogFolder.SelectedPath;
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        #endregion

        #region Text field validators

        /// <summary>
        /// Validate the contents of the Instance name textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            Regex rValidName = new Regex("^[a-zA-Z0-9\\-_\\+=\\$&^\\[\\]][a-zA-Z0-9 \\.\\-_\\+=\\$&^\\[\\]]+$", RegexOptions.Singleline);
            Match mValidName = rValidName.Match(txtName.Text);
            if (!((txtName.Text.Length > 0) && mValidName.Success))
            {
                e.Cancel = true;
                txtName.Focus();
                txtName.BackColor = Color.Yellow;
                txtName.Focus();
                ShowToolTip("Instance name can contain only\r\nletters, numbers and basic symbols\r\n(+=-_~$@^&.,[]), must not end with\r\ndot (.) and cannot start with space.", txtName, txtName.Location.X, txtName.Location.Y + 8, 5000);
            }
            else
            {
                txtName.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtName);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Validate the contents of the Local File Path textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLocalPath_Validating(object sender, CancelEventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            if (!radioLocal.Checked) return;

            if (txtLocalPath.Text.ToUpper().EndsWith("FAHLOG.TXT"))
                txtLocalPath.Text = txtLocalPath.Text.Substring(0, txtLocalPath.Text.Length - 10);
            if (txtLocalPath.Text.ToUpper().EndsWith("UNITINFO.TXT"))
                txtLocalPath.Text = txtLocalPath.Text.Substring(0, txtLocalPath.Text.Length - 12);

            Regex rValidPath = new Regex("^((?<DRIVE>[a-z]:)|(\\\\\\\\(?<SERVER>[0-9]*[a-z\\-][a-z0-9\\-]*)\\\\(?<VOLUME>[^\\.\\x01-\\x1F\\\\\"\"\\*\\?<>:|\\\\/][^\\x01-\\x1F\\\\\"\"\\*\\?|><:\\\\/]*)))?(?<FOLDERS>(?<FOLDER1>(\\.|(\\.\\.)|([^\\.\\x01-\\x1F\\\\\"\"\\*\\?|><:\\\\/][^\\x01-\\x1F\\\\\"\"\\*\\?<>:|\\\\/]*)))?(?<FOLDERm>[\\\\/](\\.|(\\.\\.)|([^\\.\\x01-\\x1F\\\\\"\"\\*\\?|><:\\\\/][^\\x01-\\x1F\\\\\"\"\\*\\?<>:|\\\\/]*)))*)?[\\\\/]?$", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match mPath = rValidPath.Match(txtLocalPath.Text);
            Match mPath2 = rValidPath.Match(txtLocalPath.Text + "\\");

            if (!((txtLocalPath.Text.Length > 3) && (mPath.Success || mPath2.Success)))
            {
                e.Cancel = true;
                txtLocalPath.Focus();
                txtLocalPath.BackColor = Color.Yellow;
                txtLocalPath.Focus();
                ShowToolTip("Log Folder must be a valid local\r\nor network (UNC) path.", txtLocalPath, txtLocalPath.Location.X, txtLocalPath.Location.Y + 8, 5000);
            }
            else
            {
                if (mPath2.Success)
                    txtLocalPath.Text += "\\";
                txtLocalPath.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtLocalPath);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Validate the contents of the FTP Server textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFTPServer_Validating(object sender, CancelEventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            if (!radioFTP.Checked) return;

            Regex rServer = new Regex("^([a-z0-9]([-a-z0-9]*[a-z0-9])?\\.)+((a[cdefgilmnoqrstuwxz]|aero|arpa)|(b[abdefghijmnorstvwyz]|biz)|(c[acdfghiklmnorsuvxyz]|cat|com|coop)|d[ejkmoz]|(e[ceghrstu]|edu)|f[ijkmor]|(g[abdefghilmnpqrstuwy]|gov)|h[kmnrtu]|(i[delmnoqrst]|info|int)|(j[emop]|jobs)|k[eghimnprwyz]|l[abcikrstuvy]|(m[acdghklmnopqrstuvwxyz]|mil|mobi|museum)|(n[acefgilopruz]|name|net)|(om|org)|(p[aefghklmnrstwy]|pro)|qa|r[eouw]|s[abcdeghijklmnortvyz]|(t[cdfghjklmnoprtvwz]|travel)|u[agkmsyz]|v[aceginu]|w[fs]|y[etu]|z[amw])$", RegexOptions.Singleline);
            Regex rIP = new Regex("(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)", RegexOptions.Singleline);
            Match mServer = rServer.Match(txtFTPServer.Text);
            Match mIP = rIP.Match(txtFTPServer.Text);

            if (!((txtFTPServer.Text.Length > 0) && (mServer.Success || mIP.Success)))
            {
                e.Cancel = true;
                txtFTPServer.Focus();
                txtFTPServer.BackColor = Color.Yellow;
                txtFTPServer.Focus();
                ShowToolTip("FTP server must be a valid\r\nhost name or IP address.", txtFTPServer, txtFTPServer.Location.X, txtFTPServer.Location.Y + 8, 5000);
            }
            else
            {
                txtFTPServer.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtFTPServer);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Validate the contents of the FTP Path textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFTPPath_Validating(object sender, CancelEventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            if (!radioFTP.Checked) return;

            if (txtFTPPath.Text.ToUpper().EndsWith("FAHLOG.TXT"))
                txtFTPPath.Text = txtFTPPath.Text.Substring(0, txtFTPPath.Text.Length - 10);
            if (txtFTPPath.Text.ToUpper().EndsWith("UNITINFO.TXT"))
                txtFTPPath.Text = txtFTPPath.Text.Substring(0, txtFTPPath.Text.Length - 12);
            if (!txtFTPPath.Text.EndsWith("/"))
                txtFTPPath.Text += "/";

            Regex sPath = new Regex("^/.*/$", RegexOptions.Singleline);
            Match mPath = sPath.Match(txtFTPPath.Text);

            if (!((txtFTPPath.Text.Length > 0) && mPath.Success))
            {
                e.Cancel = true;
                txtFTPPath.Focus();
                txtFTPPath.BackColor = Color.Yellow;
                txtFTPPath.Focus();
                ShowToolTip("FTP path should be the full\r\npath to the folder that\r\ncontains the log and Unit Info\r\nfiles (including the trailing /).", txtFTPPath, txtFTPPath.Location.X, txtFTPPath.Location.Y + 8, 5000);
            }
            else
            {
                txtFTPPath.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtFTPPath);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Validate the contents of the Web URL textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWebURL_Validating(object sender, CancelEventArgs e)
        {
            DateTime Start = Debug.ExecStart;
            if (!radioHTTP.Checked) return;

            if (txtWebURL.Text.ToUpper().EndsWith("FAHLOG.TXT"))
                txtWebURL.Text = txtWebURL.Text.Substring(0, txtWebURL.Text.Length - 10);
            if (txtWebURL.Text.ToUpper().EndsWith("UNITINFO.TXT"))
                txtWebURL.Text = txtWebURL.Text.Substring(0, txtWebURL.Text.Length - 12);

            Regex rURLDNS = new Regex("^http([s])?://^([a-z0-9]([-a-z0-9]*[a-z0-9])?\\.)+((a[cdefgilmnoqrstuwxz]|aero|arpa)|(b[abdefghijmnorstvwyz]|biz)|(c[acdfghiklmnorsuvxyz]|cat|com|coop)|d[ejkmoz]|(e[ceghrstu]|edu)|f[ijkmor]|(g[abdefghilmnpqrstuwy]|gov)|h[kmnrtu]|(i[delmnoqrst]|info|int)|(j[emop]|jobs)|k[eghimnprwyz]|l[abcikrstuvy]|(m[acdghklmnopqrstuvwxyz]|mil|mobi|museum)|(n[acefgilopruz]|name|net)|(om|org)|(p[aefghklmnrstwy]|pro)|qa|r[eouw]|s[abcdeghijklmnortvyz]|(t[cdfghjklmnoprtvwz]|travel)|u[agkmsyz]|v[aceginu]|w[fs]|y[etu]|z[amw])(/([A-Za-z0-9\\-\\.\\,\\[\\]\\{\\}\\!\\@\\#\\$\\%\\^\\&\\(\\)])*)*/$", RegexOptions.Singleline);
            Regex rURLIP = new Regex("^http([s])?://(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(/([A-Za-z0-9\\-\\.\\,\\[\\]\\{\\}\\!\\@\\#\\$\\%\\^\\&\\(\\)])*)*/$", RegexOptions.Singleline);
            Match mURLDNS = rURLDNS.Match(txtWebURL.Text);
            Match mURLIP = rURLIP.Match(txtWebURL.Text);

            if (!((txtWebURL.Text.Length > 0) && (mURLDNS.Success || mURLIP.Success)))
            {
                e.Cancel = true;
                txtWebURL.Focus();
                txtWebURL.BackColor = Color.Yellow;
                txtWebURL.Focus();
                ShowToolTip("URL must be a valid URL and be\r\nthe path to the folder containing\r\nunitinfo.txt and fahlog.txt.", txtWebURL, txtWebURL.Location.X, txtWebURL.Location.Y + 8, 5000);
            }
            else
            {
                txtWebURL.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtWebURL);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        /// <summary>
        /// Delegate method to ensure tooltip is displayed by UI thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        delegate void showTooltipCallback(String sMessage, Control cTarget, Int32 atX, Int32 atY, Int32 Delay);

        /// <summary>
        /// Show the appropriate tooltip balloon/box
        /// </summary>
        /// <param name="sMessage">Tip to be displayed</param>
        /// <param name="cTarget">Control to point to with the tip</param>
        /// <param name="atX">Screen location for tip (X)</param>
        /// <param name="atY">Screen location for tip (Y)</param>
        /// <param name="Delay">Time to show tip (milliseconds)</param>
        private void ShowToolTip(String sMessage, Control cTarget, Int32 atX, Int32 atY, Int32 Delay)
        {
            DateTime Start = Debug.ExecStart;
            try
            {
                if (cTarget.InvokeRequired)
                {
                    showTooltipCallback tFunc = new showTooltipCallback(ShowToolTip);
                    this.Invoke(tFunc, new object[] { sMessage, cTarget, atX, atY, Delay });
                }
                else
                {
                    toolTipCore.Show(sMessage, cTarget, atX, atY, Delay);
                }
            }
            catch (InvalidOperationException Ex)
            {
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw InvalidOp exception {1}.", Debug.FunctionName, Ex.Message), null);
            }
            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

        #endregion

        private void frmHost_Validating(object sender, CancelEventArgs e)
        {
            DateTime Start = Debug.ExecStart;

            if (radioFTP.Checked)
            {
                // Validate that the FTP user and password are specified (both are required)

                txtFTPUser.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtFTPUser);
                txtFTPPass.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtFTPPass);
                if ((txtFTPUser.Text.Length < 1) && (txtFTPPass.Text.Length > 0))
                {
                    e.Cancel = true;
                    txtFTPUser.Focus();
                    txtFTPUser.BackColor = Color.Yellow;
                    txtFTPUser.Focus();
                    ShowToolTip("Username must be specified if\r\npassword is set.", txtFTPUser, txtFTPUser.Location.X, txtFTPUser.Location.Y + 8, 5000);
                }
                else if ((txtFTPUser.Text.Length > 0) && (txtFTPPass.Text.Length < 1))
                {
                    e.Cancel = true;
                    txtFTPPass.Focus();
                    txtFTPPass.BackColor = Color.Yellow;
                    txtFTPPass.Focus();
                    ShowToolTip("Password must be specified if\r\nusername is set.", txtFTPPass, txtFTPPass.Location.X, txtFTPPass.Location.Y + 8, 5000);
                }
            }
            else if (radioHTTP.Checked)
            {
                // Validate that the HTTP user and password are specified (both are required)

                txtWebUser.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtWebUser);
                txtWebPass.BackColor = System.Drawing.SystemColors.Window;
                toolTipCore.Hide(txtWebPass);

                if ((txtWebUser.Text.Length < 1) && (txtWebPass.Text.Length > 0))
                {
                    e.Cancel = true;
                    txtWebUser.Focus();
                    txtWebUser.BackColor = Color.Yellow;
                    txtWebUser.Focus();
                    ShowToolTip("Username must be specified if password is set.", txtWebUser, txtWebUser.Location.X, txtWebUser.Location.Y + 8, 5000);
                }
                else if ((txtWebUser.Text.Length > 0) && (txtWebPass.Text.Length < 1))
                {
                    e.Cancel = true;
                    txtWebPass.Focus();
                    txtWebPass.BackColor = Color.Yellow;
                    ShowToolTip("Username must be specified if password is set.", txtWebPass, txtWebPass.Location.X, txtWebPass.Location.Y + 8, 5000);
                }
            }

            ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
        }

#region Form Close validator



#endregion

    }
}