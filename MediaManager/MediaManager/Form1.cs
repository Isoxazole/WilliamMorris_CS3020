using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MediaManager
{
    public partial class Form1 : Form
    {
        DataGridView DataGrid;
        MusicFilesGrid filesGrid;
        public Form1()
        {
            InitializeComponent();
            DataGrid = GridMusicFiles;
            filesGrid = new MusicFilesGrid(DataGrid);
            filesGrid.dataGrid.CellValueChanged += DataGrid_CellValueChanged;
            RadioButtonEdit.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxURL.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxURL.Text))
            {
                List<string> musicFilePaths = new List<string>();
                GetMusicFiles(textBoxURL.Text, musicFilePaths);
                filesGrid.SetUpGridData(musicFilePaths);

            }
            else
            {
                MessageBox.Show("Error: Directory path is not valid, please enter a valid directory path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            filesGrid.SaveChanges();
        }

        private void RadioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            ButtonSearch.Text = "Search";
            buttonBrowse.Text = "Browse Directory";
        }

        private void RadioButtonDownload_CheckedChanged(object sender, EventArgs e)
        {
            ButtonSearch.Text = "Download";
            buttonBrowse.Text = "URLS";
            ButtonSaveChanges.Text = "Download Directory";
            //Download download = new Download(LabelDisplayMessage);
        }
    }
}
