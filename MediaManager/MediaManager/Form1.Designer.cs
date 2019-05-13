namespace MediaManager
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
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.GridMusicFiles = new System.Windows.Forms.DataGridView();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonSaveChanges = new System.Windows.Forms.Button();
            this.RadioButtonEdit = new System.Windows.Forms.RadioButton();
            this.RadioButtonDownload = new System.Windows.Forms.RadioButton();
            this.LabelDisplayMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridMusicFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 12);
            this.textBoxURL.Multiline = true;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(608, 32);
            this.textBoxURL.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(626, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(97, 32);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // GridMusicFiles
            // 
            this.GridMusicFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridMusicFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMusicFiles.Location = new System.Drawing.Point(12, 81);
            this.GridMusicFiles.Name = "GridMusicFiles";
            this.GridMusicFiles.RowTemplate.Height = 24;
            this.GridMusicFiles.Size = new System.Drawing.Size(999, 492);
            this.GridMusicFiles.TabIndex = 2;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(729, 12);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(84, 32);
            this.ButtonSearch.TabIndex = 3;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // ButtonSaveChanges
            // 
            this.ButtonSaveChanges.Location = new System.Drawing.Point(12, 48);
            this.ButtonSaveChanges.Name = "ButtonSaveChanges";
            this.ButtonSaveChanges.Size = new System.Drawing.Size(199, 27);
            this.ButtonSaveChanges.TabIndex = 4;
            this.ButtonSaveChanges.Text = "Save Changes";
            this.ButtonSaveChanges.UseVisualStyleBackColor = true;
            this.ButtonSaveChanges.Click += new System.EventHandler(this.ButtonSaveChanges_Click);
            // 
            // RadioButtonEdit
            // 
            this.RadioButtonEdit.AutoSize = true;
            this.RadioButtonEdit.Location = new System.Drawing.Point(217, 54);
            this.RadioButtonEdit.Name = "RadioButtonEdit";
            this.RadioButtonEdit.Size = new System.Drawing.Size(114, 21);
            this.RadioButtonEdit.TabIndex = 5;
            this.RadioButtonEdit.TabStop = true;
            this.RadioButtonEdit.Text = "Edit ID3 Tags";
            this.RadioButtonEdit.UseVisualStyleBackColor = true;
            this.RadioButtonEdit.CheckedChanged += new System.EventHandler(this.RadioButtonEdit_CheckedChanged);
            // 
            // RadioButtonDownload
            // 
            this.RadioButtonDownload.AutoSize = true;
            this.RadioButtonDownload.Location = new System.Drawing.Point(337, 52);
            this.RadioButtonDownload.Name = "RadioButtonDownload";
            this.RadioButtonDownload.Size = new System.Drawing.Size(135, 21);
            this.RadioButtonDownload.TabIndex = 6;
            this.RadioButtonDownload.TabStop = true;
            this.RadioButtonDownload.Text = "Download Songs";
            this.RadioButtonDownload.UseVisualStyleBackColor = true;
            this.RadioButtonDownload.CheckedChanged += new System.EventHandler(this.RadioButtonDownload_CheckedChanged);
            // 
            // LabelDisplayMessage
            // 
            this.LabelDisplayMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LabelDisplayMessage.Location = new System.Drawing.Point(478, 58);
            this.LabelDisplayMessage.Name = "LabelDisplayMessage";
            this.LabelDisplayMessage.Size = new System.Drawing.Size(533, 20);
            this.LabelDisplayMessage.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 585);
            this.Controls.Add(this.LabelDisplayMessage);
            this.Controls.Add(this.RadioButtonDownload);
            this.Controls.Add(this.RadioButtonEdit);
            this.Controls.Add(this.ButtonSaveChanges);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.GridMusicFiles);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxURL);
            this.Name = "Form1";
            this.Text = "Audio Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridMusicFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.DataGridView GridMusicFiles;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonSaveChanges;
        private System.Windows.Forms.RadioButton RadioButtonEdit;
        private System.Windows.Forms.RadioButton RadioButtonDownload;
        private System.Windows.Forms.Label LabelDisplayMessage;
    }
}

