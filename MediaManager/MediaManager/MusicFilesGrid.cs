using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MediaManager
{
    class MusicFilesGrid
    {
        public DataGridView dataGrid;
        Dictionary<string, TagLib.File> savedMusicFiles;
        public MusicFilesGrid(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
            SetUpDataGridView();
        }

        public void SetUpGridData(List<string> musicFiles)
        {
            savedMusicFiles = new Dictionary<string, TagLib.File>();
            int counter = 0;
            foreach (string musicPath in musicFiles)
            {
                TagLib.File f = TagLib.File.Create(musicPath);
                string fileName = Path.GetFileName(f.Name);
                string performer = getValueofArray(f.Tag.Performers);
                string genre = getValueofArray(f.Tag.Genres);
                string[] row = {
                    counter.ToString(), fileName.Substring(0,fileName.Length - 4), f.Tag.Title, performer, f.Tag.Album, f.Tag.Year.ToString(),
                f.Tag.Comment, genre, "False"};
                dataGrid.Rows.Add(row);
                savedMusicFiles.Add(row[0], f);
                counter++;
            }
        }
        private string getValueofArray(string[] array)
        {
            if (array.Length == 0)
            {
                return "";
            }
            else
            {
                return array[0];
            }
        }


        private void SetUpDataGridView()
        {
            dataGrid.ColumnCount = 9;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGrid.GridColor = Color.Black;
            dataGrid.RowHeadersVisible = false;
            dataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGrid.AllowUserToAddRows = false;

            dataGrid.Columns[0].Name = "ID";
            dataGrid.Columns[1].Name = "File Name";
            dataGrid.Columns[2].Name = "Title";
            dataGrid.Columns[3].Name = "Artist";
            dataGrid.Columns[4].Name = "Album";
            dataGrid.Columns[5].Name = "Year";
            dataGrid.Columns[6].Name = "Comment";
            dataGrid.Columns[7].Name = "Genre";
            dataGrid.Columns[8].Name = "Edited";

        }

        public void SaveChanges()
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {

                if (row.Cells[8].Value.ToString() == "True")
                {
                    string index = row.Cells[0].Value.ToString();
                    TagLib.File file = savedMusicFiles[index];
                    
                    file.Tag.Title = (row.Cells[2].Value + "").ToString();
                    file.Tag.Performers = new string[1] { (row.Cells[3].Value + "").ToString() };
                    file.Tag.Album = (row.Cells[4].Value + "").ToString();
                    bool success = uint.TryParse(row.Cells[5].Value.ToString(), out uint year);
                    if (success)
                    {
                        file.Tag.Year = year;
                    }
                    else
                    {
                        MessageBox.Show("Error: The year you have entered is not valid for the file id: " + index + ", please change the year to a valid number and save again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    
                    file.Tag.Comment = (row.Cells[6].Value + "").ToString();

                    file.Tag.Genres = new string[1] { (row.Cells[7].Value + "").ToString() };
                    try
                    {
                        file.Save();
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Error: File to save not found! Please try saving again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    string extension = file.Name.Substring(file.Name.Length - 4);
                    if (file.Name != row.Cells[1].Value.ToString())
                    {
                        File.Move(file.Name, Path.Combine(Path.GetDirectoryName(file.Name), row.Cells[1].Value.ToString() + extension));
                    }
                    
                    row.Cells[8].Value = "False";
                    
                }

            }//foreach loop
        }//SaveChanges method

    }

}
