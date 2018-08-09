namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    partial class ExaminationWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.showKeySharedISChkBox = new System.Windows.Forms.CheckBox();
            this.showPasswordChkBox = new System.Windows.Forms.CheckBox();
            this.sharedKeyISTxtBox = new System.Windows.Forms.TextBox();
            this.stdPassLbl = new System.Windows.Forms.Label();
            this.submitExamBtn = new System.Windows.Forms.Button();
            this.remainingtimeLbl = new System.Windows.Forms.Label();
            this.startExamBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.examKeyTxtBox = new System.Windows.Forms.TextBox();
            this.studentPasswordLbl = new System.Windows.Forms.Label();
            this.studentIDTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.networkGB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ipTxtBox = new System.Windows.Forms.TextBox();
            this.studentNameTxtBox = new System.Windows.Forms.TextBox();
            this.openExamBtn = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.assetsrtb = new System.Windows.Forms.RichTextBox();
            this.flowlayout = new System.Windows.Forms.FlowLayoutPanel();
            this.highSecChkBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.networkGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.highSecChkBox);
            this.panel1.Controls.Add(this.showKeySharedISChkBox);
            this.panel1.Controls.Add(this.showPasswordChkBox);
            this.panel1.Controls.Add(this.sharedKeyISTxtBox);
            this.panel1.Controls.Add(this.stdPassLbl);
            this.panel1.Controls.Add(this.submitExamBtn);
            this.panel1.Controls.Add(this.remainingtimeLbl);
            this.panel1.Controls.Add(this.startExamBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.examKeyTxtBox);
            this.panel1.Controls.Add(this.studentPasswordLbl);
            this.panel1.Controls.Add(this.studentIDTxtBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.networkGB);
            this.panel1.Controls.Add(this.studentNameTxtBox);
            this.panel1.Controls.Add(this.openExamBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 125);
            this.panel1.TabIndex = 1;
            // 
            // showKeySharedISChkBox
            // 
            this.showKeySharedISChkBox.AutoSize = true;
            this.showKeySharedISChkBox.Location = new System.Drawing.Point(846, 96);
            this.showKeySharedISChkBox.Name = "showKeySharedISChkBox";
            this.showKeySharedISChkBox.Size = new System.Drawing.Size(64, 21);
            this.showKeySharedISChkBox.TabIndex = 103;
            this.showKeySharedISChkBox.Text = "Show";
            this.showKeySharedISChkBox.UseVisualStyleBackColor = true;
            this.showKeySharedISChkBox.Visible = false;
            this.showKeySharedISChkBox.CheckedChanged += new System.EventHandler(this.showKeySharedISChkBox_CheckedChanged);
            // 
            // showPasswordChkBox
            // 
            this.showPasswordChkBox.AutoSize = true;
            this.showPasswordChkBox.Location = new System.Drawing.Point(695, 64);
            this.showPasswordChkBox.Name = "showPasswordChkBox";
            this.showPasswordChkBox.Size = new System.Drawing.Size(64, 21);
            this.showPasswordChkBox.TabIndex = 89;
            this.showPasswordChkBox.Text = "Show";
            this.showPasswordChkBox.UseVisualStyleBackColor = true;
            this.showPasswordChkBox.CheckedChanged += new System.EventHandler(this.showPasswordChkBox_CheckedChanged);
            // 
            // sharedKeyISTxtBox
            // 
            this.sharedKeyISTxtBox.Location = new System.Drawing.Point(720, 96);
            this.sharedKeyISTxtBox.Name = "sharedKeyISTxtBox";
            this.sharedKeyISTxtBox.Size = new System.Drawing.Size(120, 22);
            this.sharedKeyISTxtBox.TabIndex = 102;
            this.sharedKeyISTxtBox.Text = "123456";
            this.sharedKeyISTxtBox.UseSystemPasswordChar = true;
            this.sharedKeyISTxtBox.Visible = false;
            // 
            // stdPassLbl
            // 
            this.stdPassLbl.AutoSize = true;
            this.stdPassLbl.Location = new System.Drawing.Point(592, 99);
            this.stdPassLbl.Name = "stdPassLbl";
            this.stdPassLbl.Size = new System.Drawing.Size(122, 17);
            this.stdPassLbl.TabIndex = 101;
            this.stdPassLbl.Text = "Student Password";
            this.stdPassLbl.Visible = false;
            // 
            // submitExamBtn
            // 
            this.submitExamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(50)))));
            this.submitExamBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitExamBtn.FlatAppearance.BorderSize = 0;
            this.submitExamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitExamBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitExamBtn.ForeColor = System.Drawing.Color.White;
            this.submitExamBtn.Location = new System.Drawing.Point(291, 14);
            this.submitExamBtn.Margin = new System.Windows.Forms.Padding(4);
            this.submitExamBtn.Name = "submitExamBtn";
            this.submitExamBtn.Size = new System.Drawing.Size(144, 37);
            this.submitExamBtn.TabIndex = 100;
            this.submitExamBtn.Text = "Submit Exam";
            this.submitExamBtn.UseVisualStyleBackColor = false;
            this.submitExamBtn.Visible = false;
            this.submitExamBtn.Click += new System.EventHandler(this.submitExamBtn_Click);
            // 
            // remainingtimeLbl
            // 
            this.remainingtimeLbl.AutoSize = true;
            this.remainingtimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingtimeLbl.Location = new System.Drawing.Point(98, 100);
            this.remainingtimeLbl.Name = "remainingtimeLbl";
            this.remainingtimeLbl.Size = new System.Drawing.Size(144, 20);
            this.remainingtimeLbl.TabIndex = 99;
            this.remainingtimeLbl.Text = "Remaining Time";
            this.remainingtimeLbl.Visible = false;
            // 
            // startExamBtn
            // 
            this.startExamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.startExamBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startExamBtn.FlatAppearance.BorderSize = 0;
            this.startExamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startExamBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startExamBtn.ForeColor = System.Drawing.Color.White;
            this.startExamBtn.Location = new System.Drawing.Point(291, 62);
            this.startExamBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startExamBtn.Name = "startExamBtn";
            this.startExamBtn.Size = new System.Drawing.Size(144, 37);
            this.startExamBtn.TabIndex = 98;
            this.startExamBtn.Text = "Start Exam";
            this.startExamBtn.UseVisualStyleBackColor = false;
            this.startExamBtn.Visible = false;
            this.startExamBtn.Click += new System.EventHandler(this.startExamBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 96;
            this.label4.Text = "Student ID";
            // 
            // examKeyTxtBox
            // 
            this.examKeyTxtBox.Location = new System.Drawing.Point(569, 64);
            this.examKeyTxtBox.Name = "examKeyTxtBox";
            this.examKeyTxtBox.Size = new System.Drawing.Size(120, 22);
            this.examKeyTxtBox.TabIndex = 87;
            this.examKeyTxtBox.Text = "123456";
            this.examKeyTxtBox.UseSystemPasswordChar = true;
            // 
            // studentPasswordLbl
            // 
            this.studentPasswordLbl.AutoSize = true;
            this.studentPasswordLbl.Location = new System.Drawing.Point(442, 64);
            this.studentPasswordLbl.Name = "studentPasswordLbl";
            this.studentPasswordLbl.Size = new System.Drawing.Size(70, 17);
            this.studentPasswordLbl.TabIndex = 86;
            this.studentPasswordLbl.Text = "Exam Key";
            // 
            // studentIDTxtBox
            // 
            this.studentIDTxtBox.Location = new System.Drawing.Point(546, 37);
            this.studentIDTxtBox.Name = "studentIDTxtBox";
            this.studentIDTxtBox.Size = new System.Drawing.Size(144, 22);
            this.studentIDTxtBox.TabIndex = 97;
            this.studentIDTxtBox.Text = "1234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Student Name";
            // 
            // networkGB
            // 
            this.networkGB.Controls.Add(this.label2);
            this.networkGB.Controls.Add(this.portTxtBox);
            this.networkGB.Controls.Add(this.label1);
            this.networkGB.Controls.Add(this.ipTxtBox);
            this.networkGB.Location = new System.Drawing.Point(9, 7);
            this.networkGB.Name = "networkGB";
            this.networkGB.Size = new System.Drawing.Size(275, 88);
            this.networkGB.TabIndex = 94;
            this.networkGB.TabStop = false;
            this.networkGB.Text = "Network Based";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 92;
            this.label2.Text = "Port";
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(134, 51);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(125, 22);
            this.portTxtBox.TabIndex = 93;
            this.portTxtBox.Text = "10048";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 90;
            this.label1.Text = "Server IP Address";
            // 
            // ipTxtBox
            // 
            this.ipTxtBox.Location = new System.Drawing.Point(134, 30);
            this.ipTxtBox.Name = "ipTxtBox";
            this.ipTxtBox.Size = new System.Drawing.Size(125, 22);
            this.ipTxtBox.TabIndex = 91;
            this.ipTxtBox.Text = "127.0.0.1";
            // 
            // studentNameTxtBox
            // 
            this.studentNameTxtBox.Location = new System.Drawing.Point(546, 9);
            this.studentNameTxtBox.Name = "studentNameTxtBox";
            this.studentNameTxtBox.Size = new System.Drawing.Size(144, 22);
            this.studentNameTxtBox.TabIndex = 95;
            this.studentNameTxtBox.Text = "John Doe";
            // 
            // openExamBtn
            // 
            this.openExamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.openExamBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openExamBtn.FlatAppearance.BorderSize = 0;
            this.openExamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openExamBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openExamBtn.ForeColor = System.Drawing.Color.White;
            this.openExamBtn.Location = new System.Drawing.Point(766, 7);
            this.openExamBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openExamBtn.Name = "openExamBtn";
            this.openExamBtn.Size = new System.Drawing.Size(144, 75);
            this.openExamBtn.TabIndex = 71;
            this.openExamBtn.Text = "Get Exam";
            this.openExamBtn.UseVisualStyleBackColor = false;
            this.openExamBtn.Click += new System.EventHandler(this.openExamBtn_Click);
            // 
            // rtb
            // 
            this.rtb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb.Location = new System.Drawing.Point(0, 639);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(1016, 96);
            this.rtb.TabIndex = 2;
            this.rtb.Text = "";
            // 
            // assetsrtb
            // 
            this.assetsrtb.Dock = System.Windows.Forms.DockStyle.Top;
            this.assetsrtb.Location = new System.Drawing.Point(0, 125);
            this.assetsrtb.Name = "assetsrtb";
            this.assetsrtb.ReadOnly = true;
            this.assetsrtb.Size = new System.Drawing.Size(1016, 269);
            this.assetsrtb.TabIndex = 3;
            this.assetsrtb.Text = "";
            // 
            // flowlayout
            // 
            this.flowlayout.AutoScroll = true;
            this.flowlayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayout.Location = new System.Drawing.Point(0, 394);
            this.flowlayout.Name = "flowlayout";
            this.flowlayout.Size = new System.Drawing.Size(1016, 245);
            this.flowlayout.TabIndex = 4;
            // 
            // highSecChkBox
            // 
            this.highSecChkBox.AutoSize = true;
            this.highSecChkBox.Location = new System.Drawing.Point(445, 96);
            this.highSecChkBox.Name = "highSecChkBox";
            this.highSecChkBox.Size = new System.Drawing.Size(114, 21);
            this.highSecChkBox.TabIndex = 104;
            this.highSecChkBox.Text = "High Security";
            this.highSecChkBox.UseVisualStyleBackColor = true;
            this.highSecChkBox.CheckedChanged += new System.EventHandler(this.highSecChkBox_CheckedChanged);
            // 
            // ExaminationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 735);
            this.Controls.Add(this.flowlayout);
            this.Controls.Add(this.assetsrtb);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.panel1);
            this.Name = "ExaminationWindow";
            this.Text = "ExaminationWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.networkGB.ResumeLayout(false);
            this.networkGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showPasswordChkBox;
        private System.Windows.Forms.TextBox examKeyTxtBox;
        private System.Windows.Forms.Label studentPasswordLbl;
        private System.Windows.Forms.Button openExamBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox studentIDTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox networkGB;
        private System.Windows.Forms.TextBox studentNameTxtBox;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Label remainingtimeLbl;
        private System.Windows.Forms.Button startExamBtn;
        private System.Windows.Forms.RichTextBox assetsrtb;
        private System.Windows.Forms.FlowLayoutPanel flowlayout;
        private System.Windows.Forms.Button submitExamBtn;
        private System.Windows.Forms.CheckBox showKeySharedISChkBox;
        private System.Windows.Forms.TextBox sharedKeyISTxtBox;
        private System.Windows.Forms.Label stdPassLbl;
        private System.Windows.Forms.CheckBox highSecChkBox;
    }
}