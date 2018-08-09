namespace ForensicsCourseToolkit.Common
{
    partial class CovertersFrm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.toGB = new System.Windows.Forms.GroupBox();
            this.toLittleEndianRadioBtn = new System.Windows.Forms.RadioButton();
            this.toBigEndianRadioBtn = new System.Windows.Forms.RadioButton();
            this.toIntRadioBtn = new System.Windows.Forms.RadioButton();
            this.fromGB = new System.Windows.Forms.GroupBox();
            this.fromLittleEndianRadioBrn = new System.Windows.Forms.RadioButton();
            this.fromBigEndianRadioBtn = new System.Windows.Forms.RadioButton();
            this.fromIntRadioBtn = new System.Windows.Forms.RadioButton();
            this.fromTxtBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.directoryEntryTxtBox = new System.Windows.Forms.TextBox();
            this.parseBtn = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.toGB.SuspendLayout();
            this.fromGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.groupBox1);
            this.topPanel.Controls.Add(this.UpdateBtn);
            this.topPanel.Controls.Add(this.toGB);
            this.topPanel.Controls.Add(this.fromGB);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(585, 234);
            this.topPanel.TabIndex = 0;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(193)))), ((int)(((byte)(48)))));
            this.UpdateBtn.FlatAppearance.BorderSize = 0;
            this.UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.ForeColor = System.Drawing.Color.White;
            this.UpdateBtn.Location = new System.Drawing.Point(483, 12);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(93, 82);
            this.UpdateBtn.TabIndex = 72;
            this.UpdateBtn.Text = "Convert";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // toGB
            // 
            this.toGB.Controls.Add(this.toLittleEndianRadioBtn);
            this.toGB.Controls.Add(this.toBigEndianRadioBtn);
            this.toGB.Controls.Add(this.toIntRadioBtn);
            this.toGB.Location = new System.Drawing.Point(243, 5);
            this.toGB.Name = "toGB";
            this.toGB.Size = new System.Drawing.Size(234, 92);
            this.toGB.TabIndex = 4;
            this.toGB.TabStop = false;
            this.toGB.Text = "To";
            // 
            // toLittleEndianRadioBtn
            // 
            this.toLittleEndianRadioBtn.AutoSize = true;
            this.toLittleEndianRadioBtn.Location = new System.Drawing.Point(73, 67);
            this.toLittleEndianRadioBtn.Name = "toLittleEndianRadioBtn";
            this.toLittleEndianRadioBtn.Size = new System.Drawing.Size(105, 17);
            this.toLittleEndianRadioBtn.TabIndex = 3;
            this.toLittleEndianRadioBtn.TabStop = true;
            this.toLittleEndianRadioBtn.Text = "Hex Little Endian";
            this.toLittleEndianRadioBtn.UseVisualStyleBackColor = true;
            // 
            // toBigEndianRadioBtn
            // 
            this.toBigEndianRadioBtn.AutoSize = true;
            this.toBigEndianRadioBtn.Location = new System.Drawing.Point(73, 44);
            this.toBigEndianRadioBtn.Name = "toBigEndianRadioBtn";
            this.toBigEndianRadioBtn.Size = new System.Drawing.Size(98, 17);
            this.toBigEndianRadioBtn.TabIndex = 2;
            this.toBigEndianRadioBtn.TabStop = true;
            this.toBigEndianRadioBtn.Text = "Hex Big Endian";
            this.toBigEndianRadioBtn.UseVisualStyleBackColor = true;
            // 
            // toIntRadioBtn
            // 
            this.toIntRadioBtn.AutoSize = true;
            this.toIntRadioBtn.Location = new System.Drawing.Point(9, 44);
            this.toIntRadioBtn.Name = "toIntRadioBtn";
            this.toIntRadioBtn.Size = new System.Drawing.Size(58, 17);
            this.toIntRadioBtn.TabIndex = 1;
            this.toIntRadioBtn.TabStop = true;
            this.toIntRadioBtn.Text = "Integer";
            this.toIntRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fromGB
            // 
            this.fromGB.Controls.Add(this.fromLittleEndianRadioBrn);
            this.fromGB.Controls.Add(this.fromBigEndianRadioBtn);
            this.fromGB.Controls.Add(this.fromIntRadioBtn);
            this.fromGB.Controls.Add(this.fromTxtBox);
            this.fromGB.Location = new System.Drawing.Point(3, 5);
            this.fromGB.Name = "fromGB";
            this.fromGB.Size = new System.Drawing.Size(234, 92);
            this.fromGB.TabIndex = 1;
            this.fromGB.TabStop = false;
            this.fromGB.Text = "From";
            // 
            // fromLittleEndianRadioBrn
            // 
            this.fromLittleEndianRadioBrn.AutoSize = true;
            this.fromLittleEndianRadioBrn.Location = new System.Drawing.Point(73, 67);
            this.fromLittleEndianRadioBrn.Name = "fromLittleEndianRadioBrn";
            this.fromLittleEndianRadioBrn.Size = new System.Drawing.Size(105, 17);
            this.fromLittleEndianRadioBrn.TabIndex = 3;
            this.fromLittleEndianRadioBrn.TabStop = true;
            this.fromLittleEndianRadioBrn.Text = "Hex Little Endian";
            this.fromLittleEndianRadioBrn.UseVisualStyleBackColor = true;
            // 
            // fromBigEndianRadioBtn
            // 
            this.fromBigEndianRadioBtn.AutoSize = true;
            this.fromBigEndianRadioBtn.Location = new System.Drawing.Point(73, 44);
            this.fromBigEndianRadioBtn.Name = "fromBigEndianRadioBtn";
            this.fromBigEndianRadioBtn.Size = new System.Drawing.Size(98, 17);
            this.fromBigEndianRadioBtn.TabIndex = 2;
            this.fromBigEndianRadioBtn.TabStop = true;
            this.fromBigEndianRadioBtn.Text = "Hex Big Endian";
            this.fromBigEndianRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fromIntRadioBtn
            // 
            this.fromIntRadioBtn.AutoSize = true;
            this.fromIntRadioBtn.Location = new System.Drawing.Point(9, 44);
            this.fromIntRadioBtn.Name = "fromIntRadioBtn";
            this.fromIntRadioBtn.Size = new System.Drawing.Size(58, 17);
            this.fromIntRadioBtn.TabIndex = 1;
            this.fromIntRadioBtn.TabStop = true;
            this.fromIntRadioBtn.Text = "Integer";
            this.fromIntRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fromTxtBox
            // 
            this.fromTxtBox.Location = new System.Drawing.Point(9, 18);
            this.fromTxtBox.Name = "fromTxtBox";
            this.fromTxtBox.Size = new System.Drawing.Size(204, 20);
            this.fromTxtBox.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 234);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(585, 140);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parseBtn);
            this.groupBox1.Controls.Add(this.directoryEntryTxtBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directory Entry";
            // 
            // directoryEntryTxtBox
            // 
            this.directoryEntryTxtBox.Location = new System.Drawing.Point(9, 18);
            this.directoryEntryTxtBox.Multiline = true;
            this.directoryEntryTxtBox.Name = "directoryEntryTxtBox";
            this.directoryEntryTxtBox.Size = new System.Drawing.Size(289, 68);
            this.directoryEntryTxtBox.TabIndex = 0;
            // 
            // parseBtn
            // 
            this.parseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(193)))), ((int)(((byte)(48)))));
            this.parseBtn.FlatAppearance.BorderSize = 0;
            this.parseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parseBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parseBtn.ForeColor = System.Drawing.Color.White;
            this.parseBtn.Location = new System.Drawing.Point(366, 10);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(93, 76);
            this.parseBtn.TabIndex = 73;
            this.parseBtn.Text = "Convert";
            this.parseBtn.UseVisualStyleBackColor = false;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // CovertersFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 374);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.topPanel);
            this.Name = "CovertersFrm";
            this.Text = "Converters";
            this.topPanel.ResumeLayout(false);
            this.toGB.ResumeLayout(false);
            this.toGB.PerformLayout();
            this.fromGB.ResumeLayout(false);
            this.fromGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.GroupBox toGB;
        private System.Windows.Forms.RadioButton toLittleEndianRadioBtn;
        private System.Windows.Forms.RadioButton toBigEndianRadioBtn;
        private System.Windows.Forms.RadioButton toIntRadioBtn;
        private System.Windows.Forms.GroupBox fromGB;
        private System.Windows.Forms.RadioButton fromLittleEndianRadioBrn;
        private System.Windows.Forms.RadioButton fromBigEndianRadioBtn;
        private System.Windows.Forms.RadioButton fromIntRadioBtn;
        private System.Windows.Forms.TextBox fromTxtBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.TextBox directoryEntryTxtBox;
    }
}