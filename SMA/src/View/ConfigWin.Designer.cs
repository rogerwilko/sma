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
            ((System.ComponentModel.ISupportInitialize)(this.speedTB)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(127, 275);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(194, 53);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "STOP";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.button1_Click);
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
            this.speedTB.Scroll += new System.EventHandler(this.trackBar1_Scroll);
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
            // ConfigWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 340);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedTB);
            this.Controls.Add(this.bStart);
            this.Name = "ConfigWin";
            this.Text = "Antzz Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.speedTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TrackBar speedTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labSpeed;
    }
}