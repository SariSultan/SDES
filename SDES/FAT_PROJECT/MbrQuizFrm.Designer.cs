namespace ForensicsCourseToolkit.FAT_PROJECT
{
    partial class MbrQuizFrm
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
            this.topPnl = new System.Windows.Forms.Panel();
            this.loadXMLBtn = new System.Windows.Forms.Button();
            this.saveXMLBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.vbrGB = new System.Windows.Forms.GroupBox();
            this.examDurationTxtBox = new System.Windows.Forms.TextBox();
            this.examDurationLbl = new System.Windows.Forms.Label();
            this.examDescriptionTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.studentPassTxtBox = new System.Windows.Forms.TextBox();
            this.instructorPassTxtBox = new System.Windows.Forms.TextBox();
            this.studentPasswordLbl = new System.Windows.Forms.Label();
            this.instructorPassLbl = new System.Windows.Forms.Label();
            this.exportExamBtn = new System.Windows.Forms.Button();
            this.mbrGB = new System.Windows.Forms.GroupBox();
            this.addquestionMaterialChkBox = new System.Windows.Forms.CheckBox();
            this.addanswersChkBox = new System.Windows.Forms.CheckBox();
            this.listQuestionsBtn = new System.Windows.Forms.Button();
            this.openImageBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.topPnl.SuspendLayout();
            this.vbrGB.SuspendLayout();
            this.mbrGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPnl
            // 
            this.topPnl.Controls.Add(this.loadXMLBtn);
            this.topPnl.Controls.Add(this.saveXMLBtn);
            this.topPnl.Controls.Add(this.clearBtn);
            this.topPnl.Controls.Add(this.vbrGB);
            this.topPnl.Controls.Add(this.mbrGB);
            this.topPnl.Controls.Add(this.openImageBtn);
            this.topPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPnl.Location = new System.Drawing.Point(0, 0);
            this.topPnl.Name = "topPnl";
            this.topPnl.Size = new System.Drawing.Size(874, 111);
            this.topPnl.TabIndex = 3;
            // 
            // loadXMLBtn
            // 
            this.loadXMLBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.loadXMLBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadXMLBtn.FlatAppearance.BorderSize = 0;
            this.loadXMLBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadXMLBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadXMLBtn.ForeColor = System.Drawing.Color.White;
            this.loadXMLBtn.Location = new System.Drawing.Point(752, 59);
            this.loadXMLBtn.Name = "loadXMLBtn";
            this.loadXMLBtn.Size = new System.Drawing.Size(119, 51);
            this.loadXMLBtn.TabIndex = 79;
            this.loadXMLBtn.Text = "Load XML Template";
            this.loadXMLBtn.UseVisualStyleBackColor = false;
            this.loadXMLBtn.Click += new System.EventHandler(this.loadXMLBtn_Click);
            // 
            // saveXMLBtn
            // 
            this.saveXMLBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.saveXMLBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveXMLBtn.FlatAppearance.BorderSize = 0;
            this.saveXMLBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveXMLBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveXMLBtn.ForeColor = System.Drawing.Color.White;
            this.saveXMLBtn.Location = new System.Drawing.Point(752, 7);
            this.saveXMLBtn.Name = "saveXMLBtn";
            this.saveXMLBtn.Size = new System.Drawing.Size(119, 51);
            this.saveXMLBtn.TabIndex = 76;
            this.saveXMLBtn.Text = "Save XML Template";
            this.saveXMLBtn.UseVisualStyleBackColor = false;
            this.saveXMLBtn.Click += new System.EventHandler(this.saveXMLBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.FlatAppearance.BorderSize = 0;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.Color.White;
            this.clearBtn.Location = new System.Drawing.Point(12, 58);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(170, 30);
            this.clearBtn.TabIndex = 78;
            this.clearBtn.Text = "Clear Screen";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // vbrGB
            // 
            this.vbrGB.Controls.Add(this.examDurationTxtBox);
            this.vbrGB.Controls.Add(this.examDurationLbl);
            this.vbrGB.Controls.Add(this.examDescriptionTxtBox);
            this.vbrGB.Controls.Add(this.label1);
            this.vbrGB.Controls.Add(this.studentPassTxtBox);
            this.vbrGB.Controls.Add(this.instructorPassTxtBox);
            this.vbrGB.Controls.Add(this.studentPasswordLbl);
            this.vbrGB.Controls.Add(this.instructorPassLbl);
            this.vbrGB.Controls.Add(this.exportExamBtn);
            this.vbrGB.Location = new System.Drawing.Point(386, 2);
            this.vbrGB.Name = "vbrGB";
            this.vbrGB.Size = new System.Drawing.Size(366, 103);
            this.vbrGB.TabIndex = 77;
            this.vbrGB.TabStop = false;
            this.vbrGB.Text = "Export Exam";
            // 
            // examDurationTxtBox
            // 
            this.examDurationTxtBox.Location = new System.Drawing.Point(109, 80);
            this.examDurationTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.examDurationTxtBox.Name = "examDurationTxtBox";
            this.examDurationTxtBox.Size = new System.Drawing.Size(146, 20);
            this.examDurationTxtBox.TabIndex = 84;
            this.examDurationTxtBox.Text = "30";
            // 
            // examDurationLbl
            // 
            this.examDurationLbl.AutoSize = true;
            this.examDurationLbl.Location = new System.Drawing.Point(4, 82);
            this.examDurationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.examDurationLbl.Name = "examDurationLbl";
            this.examDurationLbl.Size = new System.Drawing.Size(92, 13);
            this.examDurationLbl.TabIndex = 83;
            this.examDurationLbl.Text = "Duration (minutes)";
            // 
            // examDescriptionTxtBox
            // 
            this.examDescriptionTxtBox.Location = new System.Drawing.Point(109, 59);
            this.examDescriptionTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.examDescriptionTxtBox.Name = "examDescriptionTxtBox";
            this.examDescriptionTxtBox.Size = new System.Drawing.Size(253, 20);
            this.examDescriptionTxtBox.TabIndex = 82;
            this.examDescriptionTxtBox.Text = "Exam 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Exam Description";
            // 
            // studentPassTxtBox
            // 
            this.studentPassTxtBox.Location = new System.Drawing.Point(109, 34);
            this.studentPassTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.studentPassTxtBox.Name = "studentPassTxtBox";
            this.studentPassTxtBox.Size = new System.Drawing.Size(146, 20);
            this.studentPassTxtBox.TabIndex = 80;
            this.studentPassTxtBox.Text = "123456";
            this.studentPassTxtBox.TextChanged += new System.EventHandler(this.studentPassTxtBox_TextChanged);
            // 
            // instructorPassTxtBox
            // 
            this.instructorPassTxtBox.Location = new System.Drawing.Point(109, 10);
            this.instructorPassTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.instructorPassTxtBox.Name = "instructorPassTxtBox";
            this.instructorPassTxtBox.Size = new System.Drawing.Size(146, 20);
            this.instructorPassTxtBox.TabIndex = 79;
            this.instructorPassTxtBox.Text = "123456789";
            // 
            // studentPasswordLbl
            // 
            this.studentPasswordLbl.AutoSize = true;
            this.studentPasswordLbl.Location = new System.Drawing.Point(5, 38);
            this.studentPasswordLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.studentPasswordLbl.Name = "studentPasswordLbl";
            this.studentPasswordLbl.Size = new System.Drawing.Size(93, 13);
            this.studentPasswordLbl.TabIndex = 78;
            this.studentPasswordLbl.Text = "Student Password";
            this.studentPasswordLbl.Click += new System.EventHandler(this.studentPasswordLbl_Click);
            // 
            // instructorPassLbl
            // 
            this.instructorPassLbl.AutoSize = true;
            this.instructorPassLbl.Location = new System.Drawing.Point(5, 16);
            this.instructorPassLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.instructorPassLbl.Name = "instructorPassLbl";
            this.instructorPassLbl.Size = new System.Drawing.Size(100, 13);
            this.instructorPassLbl.TabIndex = 77;
            this.instructorPassLbl.Text = "Instructor Password";
            // 
            // exportExamBtn
            // 
            this.exportExamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.exportExamBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportExamBtn.FlatAppearance.BorderSize = 0;
            this.exportExamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportExamBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportExamBtn.ForeColor = System.Drawing.Color.White;
            this.exportExamBtn.Location = new System.Drawing.Point(260, 10);
            this.exportExamBtn.Name = "exportExamBtn";
            this.exportExamBtn.Size = new System.Drawing.Size(100, 41);
            this.exportExamBtn.TabIndex = 76;
            this.exportExamBtn.Text = "Export Exam";
            this.exportExamBtn.UseVisualStyleBackColor = false;
            this.exportExamBtn.Click += new System.EventHandler(this.exportExamBtn_Click);
            // 
            // mbrGB
            // 
            this.mbrGB.Controls.Add(this.addquestionMaterialChkBox);
            this.mbrGB.Controls.Add(this.addanswersChkBox);
            this.mbrGB.Controls.Add(this.listQuestionsBtn);
            this.mbrGB.Location = new System.Drawing.Point(188, 3);
            this.mbrGB.Name = "mbrGB";
            this.mbrGB.Size = new System.Drawing.Size(198, 105);
            this.mbrGB.TabIndex = 76;
            this.mbrGB.TabStop = false;
            this.mbrGB.Text = "Exam Creation";
            // 
            // addquestionMaterialChkBox
            // 
            this.addquestionMaterialChkBox.AutoSize = true;
            this.addquestionMaterialChkBox.Checked = true;
            this.addquestionMaterialChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addquestionMaterialChkBox.Location = new System.Drawing.Point(4, 42);
            this.addquestionMaterialChkBox.Margin = new System.Windows.Forms.Padding(2);
            this.addquestionMaterialChkBox.Name = "addquestionMaterialChkBox";
            this.addquestionMaterialChkBox.Size = new System.Drawing.Size(130, 17);
            this.addquestionMaterialChkBox.TabIndex = 75;
            this.addquestionMaterialChkBox.Text = "Add Question Material";
            this.addquestionMaterialChkBox.UseVisualStyleBackColor = true;
            // 
            // addanswersChkBox
            // 
            this.addanswersChkBox.AutoSize = true;
            this.addanswersChkBox.Checked = true;
            this.addanswersChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addanswersChkBox.Location = new System.Drawing.Point(4, 58);
            this.addanswersChkBox.Margin = new System.Windows.Forms.Padding(2);
            this.addanswersChkBox.Name = "addanswersChkBox";
            this.addanswersChkBox.Size = new System.Drawing.Size(191, 17);
            this.addanswersChkBox.TabIndex = 74;
            this.addanswersChkBox.Text = "Add Answers (Instructor View Only)";
            this.addanswersChkBox.UseVisualStyleBackColor = true;
            // 
            // listQuestionsBtn
            // 
            this.listQuestionsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.listQuestionsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listQuestionsBtn.FlatAppearance.BorderSize = 0;
            this.listQuestionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listQuestionsBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listQuestionsBtn.ForeColor = System.Drawing.Color.White;
            this.listQuestionsBtn.Location = new System.Drawing.Point(6, 15);
            this.listQuestionsBtn.Name = "listQuestionsBtn";
            this.listQuestionsBtn.Size = new System.Drawing.Size(170, 27);
            this.listQuestionsBtn.TabIndex = 71;
            this.listQuestionsBtn.Text = "List Possible Questions";
            this.listQuestionsBtn.UseVisualStyleBackColor = false;
            this.listQuestionsBtn.Visible = false;
            this.listQuestionsBtn.Click += new System.EventHandler(this.listQuestionsBtn_Click);
            // 
            // openImageBtn
            // 
            this.openImageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.openImageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openImageBtn.FlatAppearance.BorderSize = 0;
            this.openImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openImageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openImageBtn.ForeColor = System.Drawing.Color.White;
            this.openImageBtn.Location = new System.Drawing.Point(12, 15);
            this.openImageBtn.Name = "openImageBtn";
            this.openImageBtn.Size = new System.Drawing.Size(170, 30);
            this.openImageBtn.TabIndex = 70;
            this.openImageBtn.Text = "Open Image (RAW)";
            this.openImageBtn.UseVisualStyleBackColor = false;
            this.openImageBtn.Click += new System.EventHandler(this.openImageBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(0, 111);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(661, 487);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // flowLayout
            // 
            this.flowLayout.AutoScroll = true;
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayout.Location = new System.Drawing.Point(661, 111);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(213, 487);
            this.flowLayout.TabIndex = 5;
            // 
            // MbrQuizFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 598);
            this.Controls.Add(this.flowLayout);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.topPnl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MbrQuizFrm";
            this.Text = "FAT Quiz Maker";
            this.topPnl.ResumeLayout(false);
            this.vbrGB.ResumeLayout(false);
            this.vbrGB.PerformLayout();
            this.mbrGB.ResumeLayout(false);
            this.mbrGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPnl;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox vbrGB;
        private System.Windows.Forms.GroupBox mbrGB;
        private System.Windows.Forms.Button listQuestionsBtn;
        private System.Windows.Forms.Button openImageBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.CheckBox addanswersChkBox;
        private System.Windows.Forms.CheckBox addquestionMaterialChkBox;
        private System.Windows.Forms.Button exportExamBtn;
        private System.Windows.Forms.TextBox studentPassTxtBox;
        private System.Windows.Forms.TextBox instructorPassTxtBox;
        private System.Windows.Forms.Label studentPasswordLbl;
        private System.Windows.Forms.Label instructorPassLbl;
        private System.Windows.Forms.TextBox examDurationTxtBox;
        private System.Windows.Forms.Label examDurationLbl;
        private System.Windows.Forms.TextBox examDescriptionTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadXMLBtn;
        private System.Windows.Forms.Button saveXMLBtn;
    }
}