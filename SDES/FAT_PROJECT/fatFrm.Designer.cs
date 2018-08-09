namespace ForensicsCourseToolkit.FAT_PROJECT
{
    partial class fatFrm
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
            this.FatGB = new System.Windows.Forms.GroupBox();
            this.fatTablesBtn = new System.Windows.Forms.Button();
            this.FatTableBtn = new System.Windows.Forms.Button();
            this.FatDirectoryStructureBtn = new System.Windows.Forms.Button();
            this.FatValuesBtn = new System.Windows.Forms.Button();
            this.bootSectorGB = new System.Windows.Forms.GroupBox();
            this.PrintBootSectorsBtn = new System.Windows.Forms.Button();
            this.showBootSectorStructureBtn = new System.Windows.Forms.Button();
            this.PrintBootSectorVals = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.openImageBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.topPnl.SuspendLayout();
            this.FatGB.SuspendLayout();
            this.bootSectorGB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(0, 129);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1299, 624);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // topPnl
            // 
            this.topPnl.Controls.Add(this.FatGB);
            this.topPnl.Controls.Add(this.bootSectorGB);
            this.topPnl.Controls.Add(this.clearBtn);
            this.topPnl.Controls.Add(this.openImageBtn);
            this.topPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPnl.Location = new System.Drawing.Point(0, 0);
            this.topPnl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topPnl.Name = "topPnl";
            this.topPnl.Size = new System.Drawing.Size(1656, 129);
            this.topPnl.TabIndex = 2;
            // 
            // FatGB
            // 
            this.FatGB.Controls.Add(this.fatTablesBtn);
            this.FatGB.Controls.Add(this.FatTableBtn);
            this.FatGB.Controls.Add(this.FatDirectoryStructureBtn);
            this.FatGB.Controls.Add(this.FatValuesBtn);
            this.FatGB.Location = new System.Drawing.Point(735, 15);
            this.FatGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FatGB.Name = "FatGB";
            this.FatGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FatGB.Size = new System.Drawing.Size(476, 103);
            this.FatGB.TabIndex = 80;
            this.FatGB.TabStop = false;
            this.FatGB.Text = "FAT";
            // 
            // fatTablesBtn
            // 
            this.fatTablesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.fatTablesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fatTablesBtn.FlatAppearance.BorderSize = 0;
            this.fatTablesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fatTablesBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatTablesBtn.ForeColor = System.Drawing.Color.White;
            this.fatTablesBtn.Location = new System.Drawing.Point(8, 57);
            this.fatTablesBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fatTablesBtn.Name = "fatTablesBtn";
            this.fatTablesBtn.Size = new System.Drawing.Size(227, 37);
            this.fatTablesBtn.TabIndex = 77;
            this.fatTablesBtn.Text = "Fat Tables";
            this.fatTablesBtn.UseVisualStyleBackColor = false;
            this.fatTablesBtn.Click += new System.EventHandler(this.fatTablesBtn_Click);
            // 
            // FatTableBtn
            // 
            this.FatTableBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.FatTableBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FatTableBtn.FlatAppearance.BorderSize = 0;
            this.FatTableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FatTableBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FatTableBtn.ForeColor = System.Drawing.Color.White;
            this.FatTableBtn.Location = new System.Drawing.Point(241, 15);
            this.FatTableBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FatTableBtn.Name = "FatTableBtn";
            this.FatTableBtn.Size = new System.Drawing.Size(227, 37);
            this.FatTableBtn.TabIndex = 76;
            this.FatTableBtn.Text = "Entries";
            this.FatTableBtn.UseVisualStyleBackColor = false;
            this.FatTableBtn.Click += new System.EventHandler(this.FatTableBtn_Click);
            // 
            // FatDirectoryStructureBtn
            // 
            this.FatDirectoryStructureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.FatDirectoryStructureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FatDirectoryStructureBtn.FlatAppearance.BorderSize = 0;
            this.FatDirectoryStructureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FatDirectoryStructureBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FatDirectoryStructureBtn.ForeColor = System.Drawing.Color.White;
            this.FatDirectoryStructureBtn.Location = new System.Drawing.Point(8, 15);
            this.FatDirectoryStructureBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FatDirectoryStructureBtn.Name = "FatDirectoryStructureBtn";
            this.FatDirectoryStructureBtn.Size = new System.Drawing.Size(227, 37);
            this.FatDirectoryStructureBtn.TabIndex = 75;
            this.FatDirectoryStructureBtn.Text = "Structure";
            this.FatDirectoryStructureBtn.UseVisualStyleBackColor = false;
            this.FatDirectoryStructureBtn.Click += new System.EventHandler(this.FatDirectoryStructureBtn_Click);
            // 
            // FatValuesBtn
            // 
            this.FatValuesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.FatValuesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FatValuesBtn.FlatAppearance.BorderSize = 0;
            this.FatValuesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FatValuesBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FatValuesBtn.ForeColor = System.Drawing.Color.White;
            this.FatValuesBtn.Location = new System.Drawing.Point(241, 57);
            this.FatValuesBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FatValuesBtn.Name = "FatValuesBtn";
            this.FatValuesBtn.Size = new System.Drawing.Size(227, 37);
            this.FatValuesBtn.TabIndex = 74;
            this.FatValuesBtn.Text = "Tree View";
            this.FatValuesBtn.UseVisualStyleBackColor = false;
            this.FatValuesBtn.Click += new System.EventHandler(this.FatValuesBtn_Click);
            // 
            // bootSectorGB
            // 
            this.bootSectorGB.Controls.Add(this.PrintBootSectorsBtn);
            this.bootSectorGB.Controls.Add(this.showBootSectorStructureBtn);
            this.bootSectorGB.Controls.Add(this.PrintBootSectorVals);
            this.bootSectorGB.Location = new System.Drawing.Point(251, 15);
            this.bootSectorGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bootSectorGB.Name = "bootSectorGB";
            this.bootSectorGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bootSectorGB.Size = new System.Drawing.Size(476, 103);
            this.bootSectorGB.TabIndex = 79;
            this.bootSectorGB.TabStop = false;
            this.bootSectorGB.Text = "Boot Sector";
            // 
            // PrintBootSectorsBtn
            // 
            this.PrintBootSectorsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.PrintBootSectorsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrintBootSectorsBtn.FlatAppearance.BorderSize = 0;
            this.PrintBootSectorsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintBootSectorsBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintBootSectorsBtn.ForeColor = System.Drawing.Color.White;
            this.PrintBootSectorsBtn.Location = new System.Drawing.Point(241, 15);
            this.PrintBootSectorsBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrintBootSectorsBtn.Name = "PrintBootSectorsBtn";
            this.PrintBootSectorsBtn.Size = new System.Drawing.Size(227, 37);
            this.PrintBootSectorsBtn.TabIndex = 76;
            this.PrintBootSectorsBtn.Text = "BootSector Table(s)";
            this.PrintBootSectorsBtn.UseVisualStyleBackColor = false;
            this.PrintBootSectorsBtn.Click += new System.EventHandler(this.PrintBootSectorsBtn_Click);
            // 
            // showBootSectorStructureBtn
            // 
            this.showBootSectorStructureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.showBootSectorStructureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showBootSectorStructureBtn.FlatAppearance.BorderSize = 0;
            this.showBootSectorStructureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showBootSectorStructureBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBootSectorStructureBtn.ForeColor = System.Drawing.Color.White;
            this.showBootSectorStructureBtn.Location = new System.Drawing.Point(8, 15);
            this.showBootSectorStructureBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showBootSectorStructureBtn.Name = "showBootSectorStructureBtn";
            this.showBootSectorStructureBtn.Size = new System.Drawing.Size(227, 37);
            this.showBootSectorStructureBtn.TabIndex = 75;
            this.showBootSectorStructureBtn.Text = "BootSector Structure";
            this.showBootSectorStructureBtn.UseVisualStyleBackColor = false;
            this.showBootSectorStructureBtn.Click += new System.EventHandler(this.showBootSectorStructureBtn_Click);
            // 
            // PrintBootSectorVals
            // 
            this.PrintBootSectorVals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.PrintBootSectorVals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrintBootSectorVals.FlatAppearance.BorderSize = 0;
            this.PrintBootSectorVals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintBootSectorVals.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintBootSectorVals.ForeColor = System.Drawing.Color.White;
            this.PrintBootSectorVals.Location = new System.Drawing.Point(241, 57);
            this.PrintBootSectorVals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrintBootSectorVals.Name = "PrintBootSectorVals";
            this.PrintBootSectorVals.Size = new System.Drawing.Size(227, 37);
            this.PrintBootSectorVals.TabIndex = 74;
            this.PrintBootSectorVals.Text = "Print BootSector vals";
            this.PrintBootSectorVals.UseVisualStyleBackColor = false;
            this.PrintBootSectorVals.Click += new System.EventHandler(this.PrintBootSectorVals_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBtn.FlatAppearance.BorderSize = 0;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.Color.White;
            this.clearBtn.Location = new System.Drawing.Point(16, 71);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(227, 37);
            this.clearBtn.TabIndex = 78;
            this.clearBtn.Text = "Clear Screen";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // openImageBtn
            // 
            this.openImageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(106)))), ((int)(((byte)(140)))));
            this.openImageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openImageBtn.FlatAppearance.BorderSize = 0;
            this.openImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openImageBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openImageBtn.ForeColor = System.Drawing.Color.White;
            this.openImageBtn.Location = new System.Drawing.Point(16, 18);
            this.openImageBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openImageBtn.Name = "openImageBtn";
            this.openImageBtn.Size = new System.Drawing.Size(227, 37);
            this.openImageBtn.TabIndex = 70;
            this.openImageBtn.Text = "Open Image (RAW)";
            this.openImageBtn.UseVisualStyleBackColor = false;
            this.openImageBtn.Click += new System.EventHandler(this.openImageBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1299, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 624);
            this.panel1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(357, 624);
            this.treeView1.TabIndex = 0;
            // 
            // fatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 753);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topPnl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fatFrm";
            this.Text = "Boot Sector";
            this.topPnl.ResumeLayout(false);
            this.FatGB.ResumeLayout(false);
            this.bootSectorGB.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel topPnl;
        private System.Windows.Forms.Button openImageBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox bootSectorGB;
        private System.Windows.Forms.Button showBootSectorStructureBtn;
        private System.Windows.Forms.Button PrintBootSectorVals;
        private System.Windows.Forms.Button PrintBootSectorsBtn;
        private System.Windows.Forms.GroupBox FatGB;
        private System.Windows.Forms.Button FatTableBtn;
        private System.Windows.Forms.Button FatDirectoryStructureBtn;
        private System.Windows.Forms.Button FatValuesBtn;
        private System.Windows.Forms.Button fatTablesBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
    }
}

