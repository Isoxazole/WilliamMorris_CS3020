namespace CollisionDetection
{
    partial class Form1
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
            this.CollisionMap = new System.Windows.Forms.PictureBox();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.NumSquaresLabel = new System.Windows.Forms.Label();
            this.CalcTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CollisionMap)).BeginInit();
            this.SuspendLayout();
            // 
            // CollisionMap
            // 
            this.CollisionMap.Location = new System.Drawing.Point(12, 12);
            this.CollisionMap.Name = "CollisionMap";
            this.CollisionMap.Size = new System.Drawing.Size(600, 577);
            this.CollisionMap.TabIndex = 0;
            this.CollisionMap.TabStop = false;
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Location = new System.Drawing.Point(619, 16);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(109, 13);
            this.FPSLabel.TabIndex = 1;
            this.FPSLabel.Text = "Frames per second = ";
            // 
            // NumSquaresLabel
            // 
            this.NumSquaresLabel.AutoSize = true;
            this.NumSquaresLabel.Location = new System.Drawing.Point(619, 29);
            this.NumSquaresLabel.Name = "NumSquaresLabel";
            this.NumSquaresLabel.Size = new System.Drawing.Size(83, 13);
            this.NumSquaresLabel.TabIndex = 2;
            this.NumSquaresLabel.Text = "Num Squares = ";
            // 
            // CalcTimeLabel
            // 
            this.CalcTimeLabel.AutoSize = true;
            this.CalcTimeLabel.Location = new System.Drawing.Point(618, 42);
            this.CalcTimeLabel.Name = "CalcTimeLabel";
            this.CalcTimeLabel.Size = new System.Drawing.Size(124, 13);
            this.CalcTimeLabel.TabIndex = 3;
            this.CalcTimeLabel.Text = "Total Calculation Time = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 601);
            this.Controls.Add(this.CalcTimeLabel);
            this.Controls.Add(this.NumSquaresLabel);
            this.Controls.Add(this.FPSLabel);
            this.Controls.Add(this.CollisionMap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CollisionMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CollisionMap;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.Label NumSquaresLabel;
        private System.Windows.Forms.Label CalcTimeLabel;
    }
}

