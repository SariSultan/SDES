namespace ForensicsCourseToolkit.FAT_PROJECT
{
    partial class mbrFrm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.topPnl = new System.Windows.Forms.Panel();
            this.vbrGB = new System.Windows.Forms.GroupBox();
            this.showVbrStructureBtn = new System.Windows.Forms.Button();
            this.printVbrsBtn = new System.Windows.Forms.Button();
            this.mbrGB = new System.Windows.Forms.GroupBox();
            this.printMbrValsBtn = new System.Windows.Forms.Button();
            this.showMbrStructureBtn = new System.Windows.Forms.Button();
            this.stepsBtn = new System.Windows.Forms.Button();
            this.openImageBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.topPnl.SuspendLayout();
            this.vbrGB.SuspendLayout();
            this.mbrGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(0, 105);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(982, 507);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // topPnl
            // 
            this.topPnl.Controls.Add(this.clearBtn);
            this.topPnl.Controls.Add(this.vbrGB);
            this.topPnl.Controls.Add(this.mbrGB);
            this.topPnl.Controls.Add(this.openImageBtn);
            this.topPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPnl.Location = new System.Drawing.Point(0, 0);
            this.topPnl.Name = "topPnl";
            this.topPnl.Size = new System.Drawing.Size(982, 105);
            this.topPnl.TabIndex = 2;
            // 
            // vbrGB
            // 
            this.vbrGB.Controls.Add(this.showVbrStructureBtn);
            this.vbrGB.Controls.Add(this.printVbrsBtn);
            this.vbrGB.Location = new System.Drawing.Point(553, 4);
            this.vbrGB.Name = "vbrGB";
            this.vbrGB.Size = new System.Drawing.Size(357, 84);
            this.vbrGB.TabIndex = 77;
            this.vbrGB.TabStop = false;
            this.vbrGB.Text = "VBR";
            // 
            // showVbrStructureBtn
            // 
            this.showVbrStructureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.showVbrStructureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showVbrStructureBtn.FlatAppearance.BorderSize = 0;
            this.showVbrStructureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showVbrStructureBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showVbrStructureBtn.ForeColor = System.Drawing.Color.White;
            this.showVbrStructureBtn.Location = new System.Drawing.Point(6, 12);
            this.showVbrStructureBtn.Name = "showVbrStructureBtn";
            this.showVbrStructureBtn.Size = new System.Drawing.Size(170, 30);
            this.showVbrStructureBtn.TabIndex = 75;
            this.showVbrStructureBtn.Text = "Show (VBR Structure)";
            this.showVbrStructureBtn.UseVisualStyleBackColor = false;
            this.showVbrStructureBtn.Click += new System.EventHandler(this.showVbrStructureBtn_Click);
            // 
            // printVbrsBtn
            // 
            this.printVbrsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.printVbrsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printVbrsBtn.FlatAppearance.BorderSize = 0;
            this.printVbrsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printVbrsBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printVbrsBtn.ForeColor = System.Drawing.Color.White;
            this.printVbrsBtn.Location = new System.Drawing.Point(181, 46);
            this.printVbrsBtn.Name = "printVbrsBtn";
            this.printVbrsBtn.Size = new System.Drawing.Size(170, 30);
            this.printVbrsBtn.TabIndex = 74;
            this.printVbrsBtn.Text = "Print Vbr(s) Fields Values";
            this.printVbrsBtn.UseVisualStyleBackColor = false;
            this.printVbrsBtn.Click += new System.EventHandler(this.printVbrsBtn_Click);
            // 
            // mbrGB
            // 
            this.mbrGB.Controls.Add(this.printMbrValsBtn);
            this.mbrGB.Controls.Add(this.showMbrStructureBtn);
            this.mbrGB.Controls.Add(this.stepsBtn);
            this.mbrGB.Location = new System.Drawing.Point(188, 3);
            this.mbrGB.Name = "mbrGB";
            this.mbrGB.Size = new System.Drawing.Size(359, 85);
            this.mbrGB.TabIndex = 76;
            this.mbrGB.TabStop = false;
            this.mbrGB.Text = "MBR";
            // 
            // printMbrValsBtn
            // 
            this.printMbrValsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.printMbrValsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printMbrValsBtn.FlatAppearance.BorderSize = 0;
            this.printMbrValsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printMbrValsBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printMbrValsBtn.ForeColor = System.Drawing.Color.White;
            this.printMbrValsBtn.Location = new System.Drawing.Point(182, 46);
            this.printMbrValsBtn.Name = "printMbrValsBtn";
            this.printMbrValsBtn.Size = new System.Drawing.Size(170, 30);
            this.printMbrValsBtn.TabIndex = 73;
            this.printMbrValsBtn.Text = "Print MBR Fields Values";
            this.printMbrValsBtn.UseVisualStyleBackColor = false;
            this.printMbrValsBtn.Visible = false;
            this.printMbrValsBtn.Click += new System.EventHandler(this.printMbrValsBtn_Click);
            // 
            // showMbrStructureBtn
            // 
            this.showMbrStructureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.showMbrStructureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showMbrStructureBtn.FlatAppearance.BorderSize = 0;
            this.showMbrStructureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMbrStructureBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMbrStructureBtn.ForeColor = System.Drawing.Color.White;
            this.showMbrStructureBtn.Location = new System.Drawing.Point(6, 12);
            this.showMbrStructureBtn.Name = "showMbrStructureBtn";
            this.showMbrStructureBtn.Size = new System.Drawing.Size(170, 30);
            this.showMbrStructureBtn.TabIndex = 72;
            this.showMbrStructureBtn.Text = "Show (MBR Structure)";
            this.showMbrStructureBtn.UseVisualStyleBackColor = false;
            this.showMbrStructureBtn.Click += new System.EventHandler(this.showMbrStructureBtn_Click);
            // 
            // stepsBtn
            // 
            this.stepsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.stepsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepsBtn.FlatAppearance.BorderSize = 0;
            this.stepsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepsBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsBtn.ForeColor = System.Drawing.Color.White;
            this.stepsBtn.Location = new System.Drawing.Point(182, 12);
            this.stepsBtn.Name = "stepsBtn";
            this.stepsBtn.Size = new System.Drawing.Size(170, 30);
            this.stepsBtn.TabIndex = 71;
            this.stepsBtn.Text = "Steps (click one by one)";
            this.stepsBtn.UseVisualStyleBackColor = false;
            this.stepsBtn.Visible = false;
            this.stepsBtn.Click += new System.EventHandler(this.stepsBtn_Click);
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
            // mbrFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 612);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.topPnl);
            this.Name = "mbrFrm";
            this.Text = "MBR";
            this.topPnl.ResumeLayout(false);
            this.vbrGB.ResumeLayout(false);
            this.mbrGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel topPnl;
        private System.Windows.Forms.Button openImageBtn;
        private System.Windows.Forms.Button stepsBtn;
        private System.Windows.Forms.Button showMbrStructureBtn;
        private System.Windows.Forms.Button printMbrValsBtn;
        private System.Windows.Forms.Button printVbrsBtn;
        private System.Windows.Forms.Button showVbrStructureBtn;
        private System.Windows.Forms.GroupBox vbrGB;
        private System.Windows.Forms.GroupBox mbrGB;
        private System.Windows.Forms.Button clearBtn;
    }
}

