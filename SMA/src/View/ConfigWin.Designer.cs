namespace SMA.src.View
{
    partial class ConfigWin
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
            this.bStart = new System.Windows.Forms.Button();
            this.speedTB = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labCols = new System.Windows.Forms.Label();
            this.labRows = new System.Windows.Forms.Label();
            this.bReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colsTB = new System.Windows.Forms.TrackBar();
            this.rowsTB = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.speedTB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colsTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsTB)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 370);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(458, 53);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "STOP";
            this.bStart.UseVisualStyleBackColor = true;
            // 
            // speedTB
            // 
            this.speedTB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.speedTB.Location = new System.Drawing.Point(127, 46);
            this.speedTB.Maximum = 100;
            this.speedTB.Name = "speedTB";
            this.speedTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.speedTB.Size = new System.Drawing.Size(279, 45);
            this.speedTB.SmallChange = 10;
            this.speedTB.TabIndex = 1;
            this.speedTB.TickFrequency = 10;
            this.speedTB.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Framerate";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSpeed.Location = new System.Drawing.Point(421, 46);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(22, 16);
            this.labSpeed.TabIndex = 3;
            this.labSpeed.Text = "10";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labCols);
            this.groupBox1.Controls.Add(this.labRows);
            this.groupBox1.Controls.Add(this.bReset);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.colsTB);
            this.groupBox1.Controls.Add(this.rowsTB);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 249);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // labCols
            // 
            this.labCols.AutoSize = true;
            this.labCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCols.Location = new System.Drawing.Point(409, 86);
            this.labCols.Name = "labCols";
            this.labCols.Size = new System.Drawing.Size(29, 16);
            this.labCols.TabIndex = 10;
            this.labCols.Text = "100";
            // 
            // labRows
            // 
            this.labRows.AutoSize = true;
            this.labRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRows.Location = new System.Drawing.Point(409, 35);
            this.labRows.Name = "labRows";
            this.labRows.Size = new System.Drawing.Size(29, 16);
            this.labRows.TabIndex = 5;
            this.labRows.Text = "100";
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(307, 196);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(135, 35);
            this.bReset.TabIndex = 9;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rows";
            // 
            // colsTB
            // 
            this.colsTB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colsTB.Location = new System.Drawing.Point(115, 86);
            this.colsTB.Maximum = 200;
            this.colsTB.Minimum = 5;
            this.colsTB.Name = "colsTB";
            this.colsTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colsTB.Size = new System.Drawing.Size(279, 45);
            this.colsTB.SmallChange = 10;
            this.colsTB.TabIndex = 6;
            this.colsTB.TickFrequency = 10;
            this.colsTB.Value = 100;
            // 
            // rowsTB
            // 
            this.rowsTB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rowsTB.Location = new System.Drawing.Point(115, 35);
            this.rowsTB.Maximum = 200;
            this.rowsTB.Minimum = 5;
            this.rowsTB.Name = "rowsTB";
            this.rowsTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rowsTB.Size = new System.Drawing.Size(279, 45);
            this.rowsTB.SmallChange = 10;
            this.rowsTB.TabIndex = 5;
            this.rowsTB.TickFrequency = 10;
            this.rowsTB.Value = 100;
            // 
            // ConfigWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedTB);
            this.Controls.Add(this.bStart);
            this.Name = "ConfigWin";
            this.Text = "Antzz Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.speedTB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colsTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TrackBar speedTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar colsTB;
        private System.Windows.Forms.TrackBar rowsTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label labCols;
        private System.Windows.Forms.Label labRows;
    }
}