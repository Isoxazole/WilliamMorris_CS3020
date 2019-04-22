namespace SudokuProject
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
            this.ButtonCheck = new System.Windows.Forms.Button();
            this.ButtonSolve = new System.Windows.Forms.Button();
            this.ButtonLoadPreloaded = new System.Windows.Forms.Button();
            this.ButtonNewGame = new System.Windows.Forms.Button();
            this.TextBoxDisplayMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonCheck
            // 
            this.ButtonCheck.Location = new System.Drawing.Point(526, 12);
            this.ButtonCheck.Name = "ButtonCheck";
            this.ButtonCheck.Size = new System.Drawing.Size(154, 53);
            this.ButtonCheck.TabIndex = 88;
            this.ButtonCheck.Text = "Check";
            this.ButtonCheck.UseVisualStyleBackColor = true;
            this.ButtonCheck.Click += new System.EventHandler(this.ButtonCheck_Click);
            // 
            // ButtonSolve
            // 
            this.ButtonSolve.Location = new System.Drawing.Point(526, 93);
            this.ButtonSolve.Name = "ButtonSolve";
            this.ButtonSolve.Size = new System.Drawing.Size(154, 53);
            this.ButtonSolve.TabIndex = 89;
            this.ButtonSolve.Text = "Solve";
            this.ButtonSolve.UseVisualStyleBackColor = true;
            this.ButtonSolve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // ButtonLoadPreloaded
            // 
            this.ButtonLoadPreloaded.Location = new System.Drawing.Point(526, 168);
            this.ButtonLoadPreloaded.Name = "ButtonLoadPreloaded";
            this.ButtonLoadPreloaded.Size = new System.Drawing.Size(154, 53);
            this.ButtonLoadPreloaded.TabIndex = 90;
            this.ButtonLoadPreloaded.Text = "Load Preloaded";
            this.ButtonLoadPreloaded.UseVisualStyleBackColor = true;
            this.ButtonLoadPreloaded.Click += new System.EventHandler(this.ButtonLoadPreloaded_Click);
            // 
            // ButtonNewGame
            // 
            this.ButtonNewGame.Location = new System.Drawing.Point(526, 264);
            this.ButtonNewGame.Name = "ButtonNewGame";
            this.ButtonNewGame.Size = new System.Drawing.Size(154, 53);
            this.ButtonNewGame.TabIndex = 91;
            this.ButtonNewGame.Text = "New Game";
            this.ButtonNewGame.UseVisualStyleBackColor = true;
            this.ButtonNewGame.Click += new System.EventHandler(this.ButtonNewGame_Click);
            // 
            // TextBoxDisplayMessage
            // 
            this.TextBoxDisplayMessage.Location = new System.Drawing.Point(526, 326);
            this.TextBoxDisplayMessage.Multiline = true;
            this.TextBoxDisplayMessage.Name = "TextBoxDisplayMessage";
            this.TextBoxDisplayMessage.Size = new System.Drawing.Size(242, 138);
            this.TextBoxDisplayMessage.TabIndex = 92;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 476);
            this.Controls.Add(this.TextBoxDisplayMessage);
            this.Controls.Add(this.ButtonNewGame);
            this.Controls.Add(this.ButtonLoadPreloaded);
            this.Controls.Add(this.ButtonSolve);
            this.Controls.Add(this.ButtonCheck);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonCheck;
        private System.Windows.Forms.Button ButtonSolve;
        private System.Windows.Forms.Button ButtonLoadPreloaded;
        private System.Windows.Forms.Button ButtonNewGame;
        private System.Windows.Forms.TextBox TextBoxDisplayMessage;
    }
}

