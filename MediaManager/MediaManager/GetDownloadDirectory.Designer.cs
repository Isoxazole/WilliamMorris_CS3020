namespace MediaManager
{
    partial class GetDownloadDirectory
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
            this.TextBoxDirectory = new System.Windows.Forms.TextBox();
            this.LabelDirections = new System.Windows.Forms.Label();
            this.LabelForCurrentDownloadDirectory = new System.Windows.Forms.Label();
            this.ButtonBrowseDirectories = new System.Windows.Forms.Button();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.TextBoxCurrentDownloadDirectory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxDirectory
            // 
            this.TextBoxDirectory.Location = new System.Drawing.Point(16, 32);
            this.TextBoxDirectory.Name = "TextBoxDirectory";
            this.TextBoxDirectory.Size = new System.Drawing.Size(522, 22);
            this.TextBoxDirectory.TabIndex = 0;
            // 
            // LabelDirections
            // 
            this.LabelDirections.AutoSize = true;
            this.LabelDirections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDirections.Location = new System.Drawing.Point(12, 9);
            this.LabelDirections.Name = "LabelDirections";
            this.LabelDirections.Size = new System.Drawing.Size(526, 20);
            this.LabelDirections.TabIndex = 1;
            this.LabelDirections.Text = "Please Enter the Download Directory you wish to save your music to:";
            // 
            // LabelForCurrentDownloadDirectory
            // 
            this.LabelForCurrentDownloadDirectory.AutoSize = true;
            this.LabelForCurrentDownloadDirectory.Location = new System.Drawing.Point(12, 72);
            this.LabelForCurrentDownloadDirectory.Name = "LabelForCurrentDownloadDirectory";
            this.LabelForCurrentDownloadDirectory.Size = new System.Drawing.Size(190, 17);
            this.LabelForCurrentDownloadDirectory.TabIndex = 2;
            this.LabelForCurrentDownloadDirectory.Text = "Current Download Directory: ";
            // 
            // ButtonBrowseDirectories
            // 
            this.ButtonBrowseDirectories.Location = new System.Drawing.Point(544, 31);
            this.ButtonBrowseDirectories.Name = "ButtonBrowseDirectories";
            this.ButtonBrowseDirectories.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowseDirectories.TabIndex = 4;
            this.ButtonBrowseDirectories.Text = "Browse";
            this.ButtonBrowseDirectories.UseVisualStyleBackColor = true;
            this.ButtonBrowseDirectories.Click += new System.EventHandler(this.ButtonBrowseDirectories_Click);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Location = new System.Drawing.Point(625, 31);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(75, 23);
            this.ButtonSubmit.TabIndex = 5;
            this.ButtonSubmit.Text = "Submit";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // TextBoxCurrentDownloadDirectory
            // 
            this.TextBoxCurrentDownloadDirectory.Location = new System.Drawing.Point(12, 96);
            this.TextBoxCurrentDownloadDirectory.Name = "TextBoxCurrentDownloadDirectory";
            this.TextBoxCurrentDownloadDirectory.ReadOnly = true;
            this.TextBoxCurrentDownloadDirectory.Size = new System.Drawing.Size(721, 22);
            this.TextBoxCurrentDownloadDirectory.TabIndex = 7;
            // 
            // GetDownloadDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 130);
            this.Controls.Add(this.TextBoxCurrentDownloadDirectory);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.ButtonBrowseDirectories);
            this.Controls.Add(this.LabelForCurrentDownloadDirectory);
            this.Controls.Add(this.LabelDirections);
            this.Controls.Add(this.TextBoxDirectory);
            this.Name = "GetDownloadDirectory";
            this.Text = "GetDownloadDirectory";
            this.Load += new System.EventHandler(this.GetDownloadDirectory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxDirectory;
        private System.Windows.Forms.Label LabelDirections;
        private System.Windows.Forms.Label LabelForCurrentDownloadDirectory;
        private System.Windows.Forms.Button ButtonBrowseDirectories;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.TextBox TextBoxCurrentDownloadDirectory;
    }
}