using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace MediaManager
{
    public partial class Form1 : Form
    {
        DataGridView DataGridEditID3;
        MusicFilesGrid filesGrid;
        List<string> multiURLs;
        bool multipleURLs = false;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DownloadedSongs");
        public Form1()
        {
            InitializeComponent();
            DataGridEditID3 = GridMusicFiles;
            filesGrid = new MusicFilesGrid(DataGridEditID3);
            filesGrid.dataGrid.CellValueChanged += DataGrid_CellValueChanged;
            RadioButtonEdit.Checked = true;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (RadioButtonEdit.Checked)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBoxURL.Text = folderDlg.SelectedPath;
                    Environment.SpecialFolder root = folderDlg.RootFolder;
                }
            }
            else
            {
                MultiURLs newForm = new MultiURLs();
                newForm.ShowDialog();
                multiURLs = newForm.urls;
                multipleURLs = true;
                textBoxURL.Text = "Multiple URLs selected";


            }

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (RadioButtonEdit.Checked && Directory.Exists(textBoxURL.Text))
            {
                List<string> musicFilePaths = new List<string>();
                GetMusicFiles(textBoxURL.Text, musicFilePaths);
                filesGrid.SetUpGridData(musicFilePaths);

            }
            else if (RadioButtonEdit.Checked)
            {
                MessageBox.Show("Error: Directory path is not valid, please enter a valid directory path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (multipleURLs)
                {
                    List<string> songs = new List<string>();
                    Download download = new Download(LabelDisplayMessage, multiURLs, path);
                    download.StartDownload(LabelDisplayMessage);
                    GetMusicFiles(path, songs);
                    SpinWait.SpinUntil(() => download.CheckDownload());
                    while (!download.CheckDownload())
                    {
                        download.CheckDownload();
                    }
                    filesGrid.SetUpGridData(songs);
                    RadioButtonEdit.Checked = true;
                    RadioButtonEdit_CheckedChanged(sender, e);
                }
                else if (textBoxURL.Text  != "")
                {
                    List<string> oneSong = new List<string>();
                    oneSong.Add(textBoxURL.Text);
                    Download download = new Download(LabelDisplayMessage, oneSong, path);
                    download.StartDownload(LabelDisplayMessage);
                    List<string> song = new List<string>();
                    GetMusicFiles(path, song);
                    SpinWait.SpinUntil(() => download.CheckDownload());
                    filesGrid.SetUpGridData(song);
                    RadioButtonEdit.Checked = true;
                    RadioButtonEdit_CheckedChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Error: Please Enter a YouTube URL to get started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }//ButtonSearch_Click


        private void GetMusicFiles(string sourcePath, List<string> musicFilePaths)
        {
            string[] fileExtensions = new string[] {"mp3", "wav" };
            foreach (string file in Directory.GetFiles(sourcePath))
            {
                for (int i = 0; i < fileExtensions.Length; i++)
                {
                    if (file.ToLower().EndsWith(fileExtensions[i]))
                    {
                        FileInfo f = new FileInfo(file);
                        musicFilePaths.Add(f.FullName);
                        Console.WriteLine("Found file " + Path.GetFileName(file) + " in " + Path.GetDirectoryName(file));
                    }
                }//for loop

            }//foreach loop

            foreach (DirectoryInfo directory in new DirectoryInfo(sourcePath).GetDirectories())
            {
                GetMusicFiles(directory.FullName, musicFilePaths);

            }
        }

        private void DataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            filesGrid.dataGrid.Rows[e.RowIndex].Cells[8].Value = "True";
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            if (RadioButtonEdit.Checked)
            {
                filesGrid.SaveChanges();
            }
            else
            {
                GetDownloadDirectory newForm = new GetDownloadDirectory(path);
                newForm.ShowDialog();
                path = newForm.path;
            }
            
        }

        private void RadioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            ButtonSearch.Text = "Search";
            buttonBrowse.Text = "Browse Directory";
            ButtonSaveChanges.Text = "Save Changes";
        }

        private void RadioButtonDownload_CheckedChanged(object sender, EventArgs e)
        {
            ButtonSearch.Text = "Download";
            buttonBrowse.Text = "URLS";
            ButtonSaveChanges.Text = "Download Directory";
        }
    }
}
