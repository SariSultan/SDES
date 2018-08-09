namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    partial class ExamGradingFrm
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
            this.showInstructorPassChkBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.instructorPassTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventLogChkBox = new System.Windows.Forms.CheckBox();
            this.reportBtn = new System.Windows.Forms.Button();
            this.showPasswordChkBox = new System.Windows.Forms.CheckBox();
            this.studentPassTxtBox = new System.Windows.Forms.TextBox();
            this.studentPasswordLbl = new System.Windows.Forms.Label();
            this.openExamBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showInstructorPassChkBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.instructorPassTxtBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.eventLogChkBox);
            this.panel1.Controls.Add(this.reportBtn);
            this.panel1.Controls.Add(this.showPasswordChkBox);
            this.panel1.Controls.Add(this.studentPassTxtBox);
            this.panel1.Controls.Add(this.studentPasswordLbl);
            this.panel1.Controls.Add(this.openExamBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 125);
            this.panel1.TabIndex = 1;
            // 
            // showInstructorPassChkBox
            // 
            this.showInstructorPassChkBox.AutoSize = true;
            this.showInstructorPassChkBox.Location = new System.Drawing.Point(813, 19);
            this.showInstructorPassChkBox.Name = "showInstructorPassChkBox";
            this.showInstructorPassChkBox.Size = new System.Drawing.Size(64, 21);
            this.showInstructorPassChkBox.TabIndex = 96;
            this.showInstructorPassChkBox.Text = "Show";
            this.showInstructorPassChkBox.UseVisualStyleBackColor = true;
            this.showInstructorPassChkBox.CheckedChanged += new System.EventHandler(this.showInstructorPassChkBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(4, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 37);
            this.button1.TabIndex = 95;
            this.button1.Text = "Add Exams Folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // instructorPassTxtBox
            // 
            this.instructorPassTxtBox.Location = new System.Drawing.Point(602, 17);
            this.instructorPassTxtBox.Name = "instructorPassTxtBox";
            this.instructorPassTxtBox.Size = new System.Drawing.Size(205, 22);
            this.instructorPassTxtBox.TabIndex = 94;
            this.instructorPassTxtBox.Text = "123456";
            this.instructorPassTxtBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 93;
            this.label1.Text = "Instructor Password";
            // 
            // eventLogChkBox
            // 
            this.eventLogChkBox.AutoSize = true;
            this.eventLogChkBox.Location = new System.Drawing.Point(466, 53);
            this.eventLogChkBox.Name = "eventLogChkBox";
            this.eventLogChkBox.Size = new System.Drawing.Size(136, 21);
            this.eventLogChkBox.TabIndex = 92;
            this.eventLogChkBox.Text = "Include Full Logs";
            this.eventLogChkBox.UseVisualStyleBackColor = true;
            // 
            // reportBtn
            // 
            this.reportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.reportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportBtn.FlatAppearance.BorderSize = 0;
            this.reportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBtn.ForeColor = System.Drawing.Color.White;
            this.reportBtn.Location = new System.Drawing.Point(602, 46);
            this.reportBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(205, 37);
            this.reportBtn.TabIndex = 91;
            this.reportBtn.Text = "Create Grades Report";
            this.reportBtn.UseVisualStyleBackColor = false;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // showPasswordChkBox
            // 
            this.showPasswordChkBox.AutoSize = true;
            this.showPasswordChkBox.Location = new System.Drawing.Point(317, 15);
            this.showPasswordChkBox.Name = "showPasswordChkBox";
            this.showPasswordChkBox.Size = new System.Drawing.Size(64, 21);
            this.showPasswordChkBox.TabIndex = 89;
            this.showPasswordChkBox.Text = "Show";
            this.showPasswordChkBox.UseVisualStyleBackColor = true;
            this.showPasswordChkBox.CheckedChanged += new System.EventHandler(this.showPasswordChkBox_CheckedChanged);
            // 
            // studentPassTxtBox
            // 
            this.studentPassTxtBox.Location = new System.Drawing.Point(140, 14);
            this.studentPassTxtBox.Name = "studentPassTxtBox";
            this.studentPassTxtBox.Size = new System.Drawing.Size(171, 22);
            this.studentPassTxtBox.TabIndex = 87;
            this.studentPassTxtBox.Text = "123456";
            this.studentPassTxtBox.UseSystemPasswordChar = true;
            // 
            // studentPasswordLbl
            // 
            this.studentPasswordLbl.AutoSize = true;
            this.studentPasswordLbl.Location = new System.Drawing.Point(12, 17);
            this.studentPasswordLbl.Name = "studentPasswordLbl";
            this.studentPasswordLbl.Size = new System.Drawing.Size(122, 17);
            this.studentPasswordLbl.TabIndex = 86;
            this.studentPasswordLbl.Text = "Student Password";
            // 
            // openExamBtn
            // 
            this.openExamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.openExamBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openExamBtn.FlatAppearance.BorderSize = 0;
            this.openExamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openExamBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openExamBtn.ForeColor = System.Drawing.Color.White;
            this.openExamBtn.Location = new System.Drawing.Point(4, 43);
            this.openExamBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openExamBtn.Name = "openExamBtn";
            this.openExamBtn.Size = new System.Drawing.Size(227, 37);
            this.openExamBtn.TabIndex = 71;
            this.openExamBtn.Text = "Add Exam File";
            this.openExamBtn.UseVisualStyleBackColor = false;
            this.openExamBtn.Click += new System.EventHandler(this.openExamBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 125);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1006, 598);
            this.richTextBox1.TabIndex = 95;
            this.richTextBox1.Text = "";
            // 
            // ExamGradingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ExamGradingFrm";
            this.Text = "Exam Grading Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox showInstructorPassChkBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox instructorPassTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox eventLogChkBox;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.CheckBox showPasswordChkBox;
        private System.Windows.Forms.TextBox studentPassTxtBox;
        private System.Windows.Forms.Label studentPasswordLbl;
        private System.Windows.Forms.Button openExamBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}