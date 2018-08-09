using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.FAT_PROJECT;
using ForensicsCourseToolkit.Framework_Project.Examination;

namespace ForensicsCourseToolkit.Framework_Project
{
    public partial class mainFrm : RibbonForm
    {
        //  readonly Color _empColor = Color.FromArgb(201, 51, 63);
        private readonly Color _filesystemColor = Color.FromArgb(0, 155, 170);
        private readonly Color _toolsColor = Color.FromArgb(133, 205, 9);
        private readonly Color _examinationcolor = Color.FromArgb(158, 119, 0);
        private bool _manualMinimize;
        private bool _semaphore; /*simple sync flag*/

        public mainFrm()
        {
            InitializeComponent();
            Text = $" SDES  v{Application.ProductVersion}";//{Application.ProductVersion}
            ribbon1.Resize += Ribbon_Resize;
            Resize += Ribbon_Resize;

            aTabControl.MouseClick += TabControl_MouseClick;
            aTabControl.DoubleClick += TabControl_MouseDoubleClick;
            debugMsgChkBox.Checked = Program.LoggingFlags[(short)LogMsgType.Debug];
            verboseMsgChkBox.Checked = Program.LoggingFlags[(short)LogMsgType.Verbose];
            ErrorMsgChkBox.Checked = Program.LoggingFlags[(short)LogMsgType.Error];
            WarningMsgChkBox.Checked = Program.LoggingFlags[(short)LogMsgType.Fatal];


            pictureBox1.AppendText(Environment.NewLine);
            pictureBox1.AppendText(Environment.NewLine);
            pictureBox1.AppendText("SDES with FCT", new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Color.Black);
            pictureBox1.AppendText(Environment.NewLine);
            pictureBox1.AppendText("SDES", new System.Drawing.Font("Courier New", 100, FontStyle.Bold), Color.Black);

            pictureBox1.AppendText($"v{Application.ProductVersion}", new System.Drawing.Font("Courier New", 20), Color.Red);
            pictureBox1.AppendText(Environment.NewLine);
            pictureBox1.AppendText($"Supervisor: Dr. Ayed Salman", new System.Drawing.Font("Courier New", 20), Color.Black);
            pictureBox1.AppendText(Environment.NewLine);
            pictureBox1.AppendText($"Programmed By: Sari Sultan", new System.Drawing.Font("Courier New", 20), Color.Black);
            pictureBox1.AppendText(Environment.NewLine);
            //pictureBox1.AppendText("~~C R E D I T S | O P E N  S O U R C E ~~", new System.Drawing.Font("Courier New", 20), Color.BlueViolet);
            //pictureBox1.AppendText(Environment.NewLine);
//            pictureBox1.AppendText(@"



//1.NTFS Learning for the NTFS part
//https://github.com/marwahha/NTFSLearning

//2.RawDiskLib(used by 1)
//https://github.com/LordMike/RawDiskLib

//3.FlatTabControl

//4.RibbonWinForms
//https://github.com/RibbonWinForms/RibbonWinForms

//5.DeviceIOControlLIB(used by 1)
//https://github.com/LordMike/DeviceIOControlLib

//6.Be.Hex Editor
//https://github.com/Pkcs11Admin/Be.HexEditor

//7. Encryption Done using Bouncy Castle c-sharp (thanks James Tuley for working example [here https://gist.github.com/jbtule/4336842]) 
//https://github.com/bcgit/bc-csharp "

//);
            pictureBox1.SelectAll();
            pictureBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void TabControl_MouseDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (aTabControl.SelectedTab != null)
                {
                    foreach (Control acontrol in aTabControl.SelectedTab.Controls)
                    {
                        (acontrol as Form)?.Close();
                    }
                    // aTabControl.TabPages.Remove(aTabControl.SelectedTab);
                    // tabs.Remove(tabs.Cast<TabPage>().Where((t, i) => tabControl.GetTabRect(i).Contains(((MouseEventArgs)e).Location)).First());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@" IN Main2[TabControl_MouseDoubleClick] Exception " + ex, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                // throw;
            }
        }

        private void TabControl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var tabControl = sender as TabControl;
                if (tabControl != null)
                {
                    var tabs = tabControl.TabPages;
                    if (e.Button == MouseButtons.Middle)
                    {
                        var aTabPage = tabs.Cast<TabPage>()
                            .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location))
                            .First();
                        if (aTabPage != null)
                        {
                            foreach (Control acontrol in aTabPage.Controls)
                            {
                                (acontrol as Form)?.Close();
                            }
                            // aTabControl.TabPages.Remove(aTabControl.SelectedTab);
                            // tabs.Remove(tabs.Cast<TabPage>().Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location)).First());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@" IN MainFrm[TabControl_MouseClick] Exception " + ex, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Ribbon_Resize(object sender, EventArgs e)
        {
            if (!_semaphore)
            {
                _semaphore = true;
                MaximizeTPTimer.Start();
                _semaphore = false;
            }
        }

        private void __AddTabPage(Form aForm, Color aColor)
        {
            try
            {
                pictureBox1.Hide();

                var fonttemp = aForm.Font;
                var backcolortemp = aForm.BackColor;
                var forcecolortemp = aForm.ForeColor;
                aForm.Activate();
                aForm.Visible = false;
                aForm.WindowState = FormWindowState.Maximized;
                aForm.FormBorderStyle = FormBorderStyle.None;
                aForm.FormClosing += childForm_FormClosing;
                //TopLevel for form is set to false
                aForm.TopLevel = false;
                //Added new TabPage
                var tbp = new TabPage();
                tbp.MouseDoubleClick += TabControl_MouseDoubleClick;
                tbp.Text = aForm.Text;
                tbp.Text += @"            ";
                tbp.BackColor = aColor;
                // tbp.ImageIndex = 0;              
                tbp.AutoScroll = true;
                aTabControl.TabPages.Add(tbp);
                aTabControl.Font = new Font("Tahoma", 12, FontStyle.Bold);

                tbp.ForeColor = Color.White;
                tbp.Controls.Add(aForm);
                aTabControl.SelectedTab = tbp;

                //Added form to tabpage
                aForm.WindowState = FormWindowState.Maximized;
                aForm.Font = fonttemp;
                aForm.ForeColor = forcecolortemp;
                aForm.BackColor = backcolortemp;
                aForm.Activate();
                aForm.Visible = true;


                if (!_manualMinimize)
                {
                    ribbon1.Minimized = true;
                }
            }
            catch (Exception ex)
            {
                aTabControl.TabPages.Remove(aTabControl.SelectedTab);
                MessageBox.Show(@" IN Main2[AddTabPage] Exception " + ex, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                //throw;
            }
        }

        private void childForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.Cancel)
                {
                    return;
                }
                //Close Parent Tab
                var aChildForm = sender as Form;
                aChildForm?.Parent.Dispose();
            }
            catch (Exception)
            {
                //  MessageBox.Show(MsgTxt.UnexpectedError + " IN Main2[childForm_FormClosing] Exception " + ex.ToString(), MsgTxt.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By Sari Sultan");
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            var aboutFrm = new AboutFrm();
            aboutFrm.ShowIcon = false;
            aboutFrm.ShowDialog();
        }

        private void ExitSelectedTabBtn_Click(object sender, EventArgs e)
        {
        }

        private void CollapseRibbonBtn_Click(object sender, EventArgs e)
        {
            ribbon1.Minimized = !ribbon1.Minimized;
            _manualMinimize = !_manualMinimize;
        }

        private void ExitSelectedTabBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (aTabControl.SelectedTab != null)
                {
                    foreach (Control acontrol in aTabControl.SelectedTab.Controls)
                    {
                        (acontrol as Form)?.Close();
                    }
                    // aTabControl.TabPages.Remove(aTabControl.SelectedTab);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" IN Main[ExitSelectedTabBtn_Click] Exception " + ex, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                // throw;
            }
        }

        private void MbrFrmBtn_Click(object sender, EventArgs e)
        {
            var aMbrFrm = new mbrFrm();
            __AddTabPage(aMbrFrm, _filesystemColor);
        }

        private void fatExamMakerBtn_Click(object sender, EventArgs e)
        {
            var aMbrQuizFrm = new MbrQuizFrm();
            __AddTabPage(aMbrQuizFrm, _filesystemColor);
        }

        private void convertersBtn_Click(object sender, EventArgs e)
        {
            var aFrm = new CovertersFrm();
            __AddTabPage(aFrm, _toolsColor);
        }

        private void MaximizeTPTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (aTabControl.SelectedTab == null)
                {
                    return;
                }
                foreach (Control aForm in aTabControl.SelectedTab.Controls)
                {
                    if (aForm is Form)
                    {
                        SuspendLayout();
                        var form = aForm as Form;
                        form.Dock = DockStyle.Fill;
                        form.Width = ((TabPage)form.Parent).ClientSize.Width;
                        form.Height = ((TabPage)form.Parent).ClientSize.Height;
                        form.WindowState = FormWindowState.Minimized;
                        while (true)
                        {
                            if (form.WindowState != FormWindowState.Maximized)
                            {
                                form.WindowState = FormWindowState.Maximized;
                            }
                            else
                            {
                                break;
                            }
                        }
                        ResumeLayout();
                    }
                }
            }
            catch (Exception)
            {
                //  MessageBox.Show(MsgTxt.UnexpectedError + " IN Main2[MaximizeTPTimer_Tick] Exception " + ex.ToString(), MsgTxt.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MaximizeTPTimer.Stop();
            }
        }

        private void aTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_semaphore)
            {
                _semaphore = true;
                MaximizeTPTimer.Start();
                _semaphore = false;
            }
        }

        private void debugMsgChkBox_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Program.LoggingFlags[(short)LogMsgType.Debug] = debugMsgChkBox.Checked;
        }

        private void verboseMsgChkBox_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Program.LoggingFlags[(short)LogMsgType.Verbose] = verboseMsgChkBox.Checked;
        }

        private void ErrorMsgChkBox_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Program.LoggingFlags[(short)LogMsgType.Error] = ErrorMsgChkBox.Checked;
        }

        private void WarningMsgChkBox_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            Program.LoggingFlags[(short)LogMsgType.Warning] = WarningMsgChkBox.Checked;
        }

        private void beHexEditorBtn_Click(object sender, EventArgs e)
        {
            var behexEditorPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "BeHexEditor",
                "Be.HexEditor.exe"
                );
            if (!File.Exists(behexEditorPath))
            {
                MessageBox.Show($"Oh Snap!, It seems that you do not have the binary [{behexEditorPath}] installed.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Process.Start(behexEditorPath);
            }
        }




        private void examServerBtn_Click(object sender, EventArgs e)
        {
            var aFrm = new ExamServer();
            __AddTabPage(aFrm, _examinationcolor);
        }

        private void examTakingWindowBtn_Click(object sender, EventArgs e)
        {
            var aFrm = new ExaminationWindow();
            __AddTabPage(aFrm, _examinationcolor);
        }

        private void examFromFileBtn_Click(object sender, EventArgs e)
        {
            var aFrm = new ExaminationWindowFromFile();
            __AddTabPage(aFrm, _examinationcolor);
        }

        private void examGradingBtn_Click(object sender, EventArgs e)
        {
            var aFrm = new ExamGradingFrm();
            __AddTabPage(aFrm, _examinationcolor);
        }


    }
}