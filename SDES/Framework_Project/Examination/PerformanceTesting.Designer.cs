namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    partial class PerformanceTesting
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
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.ipTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfTimesTxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.stopServerBtn = new System.Windows.Forms.Button();
            this.startClientBtn = new System.Windows.Forms.Button();
            this.startServerBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.highSecChkBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.highSecChkBox);
            this.panel1.Controls.Add(this.portTxtBox);
            this.panel1.Controls.Add(this.ipTxtBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numberOfTimesTxtBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.stopServerBtn);
            this.panel1.Controls.Add(this.startClientBtn);
            this.panel1.Controls.Add(this.startServerBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 100);
            this.panel1.TabIndex = 0;
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(419, 0);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(100, 22);
            this.portTxtBox.TabIndex = 9;
            this.portTxtBox.Text = "10048";
            // 
            // ipTxtBox
            // 
            this.ipTxtBox.Location = new System.Drawing.Point(298, 0);
            this.ipTxtBox.Name = "ipTxtBox";
            this.ipTxtBox.Size = new System.Drawing.Size(100, 22);
            this.ipTxtBox.TabIndex = 8;
            this.ipTxtBox.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of Times";
            // 
            // numberOfTimesTxtBox
            // 
            this.numberOfTimesTxtBox.Location = new System.Drawing.Point(456, 72);
            this.numberOfTimesTxtBox.Name = "numberOfTimesTxtBox";
            this.numberOfTimesTxtBox.Size = new System.Drawing.Size(100, 22);
            this.numberOfTimesTxtBox.TabIndex = 5;
            this.numberOfTimesTxtBox.Text = "10000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 94);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Client (receive and submit)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopServerBtn
            // 
            this.stopServerBtn.Location = new System.Drawing.Point(149, 3);
            this.stopServerBtn.Name = "stopServerBtn";
            this.stopServerBtn.Size = new System.Drawing.Size(140, 94);
            this.stopServerBtn.TabIndex = 2;
            this.stopServerBtn.Text = "Stop Server";
            this.stopServerBtn.UseVisualStyleBackColor = true;
            this.stopServerBtn.Click += new System.EventHandler(this.stopServerBtn_Click);
            // 
            // startClientBtn
            // 
            this.startClientBtn.Location = new System.Drawing.Point(562, 0);
            this.startClientBtn.Name = "startClientBtn";
            this.startClientBtn.Size = new System.Drawing.Size(140, 94);
            this.startClientBtn.TabIndex = 1;
            this.startClientBtn.Text = "Start Client (Receive only)";
            this.startClientBtn.UseVisualStyleBackColor = true;
            this.startClientBtn.Click += new System.EventHandler(this.startClientBtn_Click);
            // 
            // startServerBtn
            // 
            this.startServerBtn.Location = new System.Drawing.Point(3, 3);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(140, 94);
            this.startServerBtn.TabIndex = 0;
            this.startServerBtn.Text = "Load Exam and Start Server";
            this.startServerBtn.UseVisualStyleBackColor = true;
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(860, 460);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // highSecChkBox
            // 
            this.highSecChkBox.AutoSize = true;
            this.highSecChkBox.Location = new System.Drawing.Point(315, 72);
            this.highSecChkBox.Name = "highSecChkBox";
            this.highSecChkBox.Size = new System.Drawing.Size(118, 21);
            this.highSecChkBox.TabIndex = 10;
            this.highSecChkBox.Text = "high security?";
            this.highSecChkBox.UseVisualStyleBackColor = true;
            // 
            // PerformanceTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "PerformanceTesting";
            this.Text = "PerformanceTesting";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startClientBtn;
        private System.Windows.Forms.Button startServerBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button stopServerBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numberOfTimesTxtBox;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.TextBox ipTxtBox;
        private System.Windows.Forms.CheckBox highSecChkBox;
    }
}