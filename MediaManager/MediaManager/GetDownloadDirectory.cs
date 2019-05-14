using System;
using System.Windows.Forms;
using System.IO;

namespace MediaManager
{
    public partial class GetDownloadDirectory : Form
    {
        public string path;
        public GetDownloadDirectory(string path)
        {
            InitializeComponent();
            this.path = path;
            TextBoxCurrentDownloadDirectory.ScrollBars = ScrollBars.Both;
            TextBoxCurrentDownloadDirectory.WordWrap = false;
            TextBoxCurrentDownloadDirectory.Text = path;
        }

        private void GetDownloadDirectory_Load(object sender, EventArgs e)
        {
            TextBoxDirectory.ScrollBars = ScrollBars.Horizontal;
            TextBoxDirectory.WordWrap = false;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TextBoxDirectory.Text))
            {
                path = TextBoxDirectory.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Error: Directory path is not valid, please enter a valid directory path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBrowseDirectories_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                TextBoxDirectory.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
