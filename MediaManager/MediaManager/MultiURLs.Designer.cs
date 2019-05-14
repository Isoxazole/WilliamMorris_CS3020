namespace MediaManager
{
    partial class MultiURLs
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxURLs = new System.Windows.Forms.TextBox();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(704, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter YouTube URLs where each URL is on its own line:";
            // 
            // TextBoxURLs
            // 
            this.TextBoxURLs.Location = new System.Drawing.Point(12, 37);
            this.TextBoxURLs.Multiline = true;
            this.TextBoxURLs.Name = "TextBoxURLs";
            this.TextBoxURLs.Size = new System.Drawing.Size(791, 410);
            this.TextBoxURLs.TabIndex = 1;
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Location = new System.Drawing.Point(722, 9);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(81, 25);
            this.ButtonSubmit.TabIndex = 2;
            this.ButtonSubmit.Text = "Submit";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // MultiURLs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 459);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.TextBoxURLs);
            this.Controls.Add(this.label1);
            this.Name = "MultiURLs";
            this.Text = "MultiURLs";
            this.Load += new System.EventHandler(this.MultiURLs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxURLs;
        private System.Windows.Forms.Button ButtonSubmit;
    }
}