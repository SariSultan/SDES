namespace ForensicsCourseToolkit.Framework_Project
{
    partial class mainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.aboutBtn = new System.Windows.Forms.RibbonOrbMenuItem();
            this.exitBtn = new System.Windows.Forms.RibbonOrbOptionButton();
            this.fileSystemsTab = new System.Windows.Forms.RibbonTab();
            this.fatRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.fatExamMakerBtn = new System.Windows.Forms.RibbonButton();
            this.ConfigTabs = new System.Windows.Forms.RibbonTab();
            this.msgLvlPnl = new System.Windows.Forms.RibbonPanel();
            this.debugMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.verboseMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.ErrorMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.WarningMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.examinationTab = new System.Windows.Forms.RibbonTab();
            this.InstructorExaminationPanel = new System.Windows.Forms.RibbonPanel();
            this.examServerBtn = new System.Windows.Forms.RibbonButton();
            this.examGradingBtn = new System.Windows.Forms.RibbonButton();
            this.examTakerPanel = new System.Windows.Forms.RibbonPanel();
            this.examTakingWindowBtn = new System.Windows.Forms.RibbonButton();
            this.examFromFileBtn = new System.Windows.Forms.RibbonButton();
            this.aTabControl = new FlatTabControl.FlatTabControl();
            this.MaximizeTPTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.RichTextBox();
            this.CollapseRibbonBtn = new System.Windows.Forms.Button();
            this.ExitSelectedTabBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.aboutBtn);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.OptionItems.Add(this.exitBtn);
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "SDES";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(754, 162);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.fileSystemsTab);
            this.ribbon1.Tabs.Add(this.ConfigTabs);
            this.ribbon1.Tabs.Add(this.examinationTab);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(5, 26, 20, 0);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.Text = "sari";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // aboutBtn
            // 
            this.aboutBtn.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.aboutBtn.Image = ((System.Drawing.Image)(resources.GetObject("aboutBtn.Image")));
            this.aboutBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.LargeImage")));
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.SmallImage")));
            this.aboutBtn.Text = "About";
            this.aboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.LargeImage")));
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.SmallImage")));
            this.exitBtn.Text = "Exit";
            // 
            // fileSystemsTab
            // 
            this.fileSystemsTab.Name = "fileSystemsTab";
            this.fileSystemsTab.Panels.Add(this.fatRibbonPanel);
            this.fileSystemsTab.Text = "File Systems";
            // 
            // fatRibbonPanel
            // 
            this.fatRibbonPanel.Items.Add(this.fatExamMakerBtn);
            this.fatRibbonPanel.Name = "fatRibbonPanel";
            this.fatRibbonPanel.Text = "FAT";
            // 
            // fatExamMakerBtn
            // 
            this.fatExamMakerBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.QuizMakerIcon;
            this.fatExamMakerBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.QuizMakerIcon;
            this.fatExamMakerBtn.Name = "fatExamMakerBtn";
            this.fatExamMakerBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("fatExamMakerBtn.SmallImage")));
            this.fatExamMakerBtn.Click += new System.EventHandler(this.fatExamMakerBtn_Click);
            // 
            // ConfigTabs
            // 
            this.ConfigTabs.Name = "ConfigTabs";
            this.ConfigTabs.Panels.Add(this.msgLvlPnl);
            this.ConfigTabs.Text = "Configurations";
            // 
            // msgLvlPnl
            // 
            this.msgLvlPnl.Items.Add(this.debugMsgChkBox);
            this.msgLvlPnl.Items.Add(this.verboseMsgChkBox);
            this.msgLvlPnl.Items.Add(this.ErrorMsgChkBox);
            this.msgLvlPnl.Items.Add(this.WarningMsgChkBox);
            this.msgLvlPnl.Name = "msgLvlPnl";
            this.msgLvlPnl.Text = "Messages to show";
            // 
            // debugMsgChkBox
            // 
            this.debugMsgChkBox.Name = "debugMsgChkBox";
            this.debugMsgChkBox.Text = "Show Debug Messages";
            this.debugMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.debugMsgChkBox_CheckBoxCheckChanged);
            // 
            // verboseMsgChkBox
            // 
            this.verboseMsgChkBox.Name = "verboseMsgChkBox";
            this.verboseMsgChkBox.Text = "Show Verbose Messages";
            this.verboseMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.verboseMsgChkBox_CheckBoxCheckChanged);
            // 
            // ErrorMsgChkBox
            // 
            this.ErrorMsgChkBox.Name = "ErrorMsgChkBox";
            this.ErrorMsgChkBox.Text = "Show Error Messages";
            this.ErrorMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.ErrorMsgChkBox_CheckBoxCheckChanged);
            // 
            // WarningMsgChkBox
            // 
            this.WarningMsgChkBox.Name = "WarningMsgChkBox";
            this.WarningMsgChkBox.Text = "Show Warning Messages";
            this.WarningMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.WarningMsgChkBox_CheckBoxCheckChanged);
            // 
            // examinationTab
            // 
            this.examinationTab.Name = "examinationTab";
            this.examinationTab.Panels.Add(this.InstructorExaminationPanel);
            this.examinationTab.Panels.Add(this.examTakerPanel);
            this.examinationTab.Text = "Examination Center";
            // 
            // InstructorExaminationPanel
            // 
            this.InstructorExaminationPanel.Items.Add(this.examServerBtn);
            this.InstructorExaminationPanel.Items.Add(this.examGradingBtn);
            this.InstructorExaminationPanel.Name = "InstructorExaminationPanel";
            this.InstructorExaminationPanel.Text = "Instructor Section";
            // 
            // examServerBtn
            // 
            this.examServerBtn.Image = ((System.Drawing.Image)(resources.GetObject("examServerBtn.Image")));
            this.examServerBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examServerBtn.LargeImage")));
            this.examServerBtn.Name = "examServerBtn";
            this.examServerBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examServerBtn.SmallImage")));
            this.examServerBtn.Text = "";
            this.examServerBtn.Click += new System.EventHandler(this.examServerBtn_Click);
            // 
            // examGradingBtn
            // 
            this.examGradingBtn.Image = ((System.Drawing.Image)(resources.GetObject("examGradingBtn.Image")));
            this.examGradingBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examGradingBtn.LargeImage")));
            this.examGradingBtn.Name = "examGradingBtn";
            this.examGradingBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examGradingBtn.SmallImage")));
            this.examGradingBtn.Text = "";
            this.examGradingBtn.Click += new System.EventHandler(this.examGradingBtn_Click);
            // 
            // examTakerPanel
            // 
            this.examTakerPanel.Items.Add(this.examTakingWindowBtn);
            this.examTakerPanel.Items.Add(this.examFromFileBtn);
            this.examTakerPanel.Name = "examTakerPanel";
            this.examTakerPanel.Text = "Student Panel ";
            // 
            // examTakingWindowBtn
            // 
            this.examTakingWindowBtn.Image = ((System.Drawing.Image)(resources.GetObject("examTakingWindowBtn.Image")));
            this.examTakingWindowBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examTakingWindowBtn.LargeImage")));
            this.examTakingWindowBtn.Name = "examTakingWindowBtn";
            this.examTakingWindowBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examTakingWindowBtn.SmallImage")));
            this.examTakingWindowBtn.Text = "";
            this.examTakingWindowBtn.Click += new System.EventHandler(this.examTakingWindowBtn_Click);
            // 
            // examFromFileBtn
            // 
            this.examFromFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("examFromFileBtn.Image")));
            this.examFromFileBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examFromFileBtn.LargeImage")));
            this.examFromFileBtn.Name = "examFromFileBtn";
            this.examFromFileBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examFromFileBtn.SmallImage")));
            this.examFromFileBtn.Text = "";
            this.examFromFileBtn.Click += new System.EventHandler(this.examFromFileBtn_Click);
            // 
            // aTabControl
            // 
            this.aTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aTabControl.ItemSize = new System.Drawing.Size(0, 40);
            this.aTabControl.Location = new System.Drawing.Point(0, 162);
            this.aTabControl.myBackColor = System.Drawing.SystemColors.Control;
            this.aTabControl.Name = "aTabControl";
            this.aTabControl.SelectedIndex = 0;
            this.aTabControl.Size = new System.Drawing.Size(754, 425);
            this.aTabControl.TabIndex = 2;
            this.aTabControl.SelectedIndexChanged += new System.EventHandler(this.aTabControl_SelectedIndexChanged);
            // 
            // MaximizeTPTimer
            // 
            this.MaximizeTPTimer.Interval = 50;
            this.MaximizeTPTimer.Tick += new System.EventHandler(this.MaximizeTPTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 162);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.ReadOnly = true;
            this.pictureBox1.Size = new System.Drawing.Size(754, 425);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.Text = "";
            // 
            // CollapseRibbonBtn
            // 
            this.CollapseRibbonBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollapseRibbonBtn.BackColor = System.Drawing.Color.Transparent;
            this.CollapseRibbonBtn.BackgroundImage = global::ForensicsCourseToolkit.Properties.Resources.Down_Arrow;
            this.CollapseRibbonBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CollapseRibbonBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CollapseRibbonBtn.FlatAppearance.BorderSize = 0;
            this.CollapseRibbonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollapseRibbonBtn.Location = new System.Drawing.Point(706, 25);
            this.CollapseRibbonBtn.Name = "CollapseRibbonBtn";
            this.CollapseRibbonBtn.Size = new System.Drawing.Size(20, 20);
            this.CollapseRibbonBtn.TabIndex = 7;
            this.CollapseRibbonBtn.UseVisualStyleBackColor = false;
            this.CollapseRibbonBtn.Click += new System.EventHandler(this.CollapseRibbonBtn_Click);
            // 
            // ExitSelectedTabBtn
            // 
            this.ExitSelectedTabBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitSelectedTabBtn.BackColor = System.Drawing.Color.White;
            this.ExitSelectedTabBtn.BackgroundImage = global::ForensicsCourseToolkit.Properties.Resources.x_ribbon;
            this.ExitSelectedTabBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitSelectedTabBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitSelectedTabBtn.FlatAppearance.BorderSize = 0;
            this.ExitSelectedTabBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitSelectedTabBtn.Location = new System.Drawing.Point(732, 25);
            this.ExitSelectedTabBtn.Name = "ExitSelectedTabBtn";
            this.ExitSelectedTabBtn.Size = new System.Drawing.Size(20, 20);
            this.ExitSelectedTabBtn.TabIndex = 6;
            this.ExitSelectedTabBtn.UseVisualStyleBackColor = false;
            this.ExitSelectedTabBtn.Click += new System.EventHandler(this.ExitSelectedTabBtn_Click_1);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(754, 587);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CollapseRibbonBtn);
            this.Controls.Add(this.ExitSelectedTabBtn);
            this.Controls.Add(this.aTabControl);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "mainFrm";
            this.Text = "SDES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab fileSystemsTab;
        private System.Windows.Forms.RibbonTab ConfigTabs;
        private System.Windows.Forms.RibbonOrbOptionButton infoBtn;
        private System.Windows.Forms.RibbonOrbOptionButton exitBtn;

        private FlatTabControl.FlatTabControl aTabControl;
        private System.Windows.Forms.Button CollapseRibbonBtn;
        private System.Windows.Forms.Button ExitSelectedTabBtn;
        private System.Windows.Forms.Timer MaximizeTPTimer;
        private System.Windows.Forms.RibbonPanel msgLvlPnl;
        private System.Windows.Forms.RibbonCheckBox debugMsgChkBox;
        private System.Windows.Forms.RibbonCheckBox verboseMsgChkBox;
        private System.Windows.Forms.RibbonCheckBox ErrorMsgChkBox;
        private System.Windows.Forms.RibbonCheckBox WarningMsgChkBox;
        private System.Windows.Forms.RibbonOrbMenuItem aboutBtn;
        private System.Windows.Forms.RibbonPanel fatRibbonPanel;
        private System.Windows.Forms.RichTextBox pictureBox1;
        private System.Windows.Forms.RibbonTab examinationTab;
        private System.Windows.Forms.RibbonPanel InstructorExaminationPanel;
        private System.Windows.Forms.RibbonButton examServerBtn;
        private System.Windows.Forms.RibbonPanel examTakerPanel;
        private System.Windows.Forms.RibbonButton examTakingWindowBtn;
        private System.Windows.Forms.RibbonButton examFromFileBtn;
        private System.Windows.Forms.RibbonButton examGradingBtn;
        private System.Windows.Forms.RibbonButton fatExamMakerBtn;
    }
}