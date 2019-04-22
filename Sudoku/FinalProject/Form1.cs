using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int nCount = 9;
        int nWidth = 35;
        int nHeight = 35;
        int spaceFactor = 5;
        TextBox[] tbNums = new System.Windows.Forms.TextBox[81];
        private void Form1_Load(object sender, EventArgs e)
        {

            //Create the text boxes

            

            

            for (int index = 0; index < nCount * nCount; index++)

            {
                tbNums[index] = new TextBox();
                tbNums[index].Multiline = true;
            }



            //loop through rows
            for (int index2 = 0; index2 < nCount; index2++)
            {


                //loop through columns
                for (int index = 0; index < nCount; index++)

                {
                    int newIndex = index2 * nCount + index;
                    int xPos = index * nWidth + 10 + spaceFactor * index;
                    int yPos = index2 * nHeight + 10 + spaceFactor * index2;

                    tbNums[newIndex].Location = new Point(xPos, yPos);

                    tbNums[newIndex].Name = "textBox" + newIndex.ToString();

                    tbNums[newIndex].Size = new Size(nWidth, nHeight);

                    tbNums[newIndex].TabIndex = newIndex;


                    int dividerWidth = 5;
                    int dividerLength = nCount * nHeight + (nCount - 1) * spaceFactor;

                    if (newIndex % 3 == 0 && newIndex < 9 && newIndex != 0)
                    {
                        CreateDivider(xPos, yPos,dividerWidth, dividerLength, true);
                        CreateDivider(yPos, xPos,dividerLength, dividerWidth, false);
                    }

                }//For Loop columns
            }//For loop  Rows



            for (int index = 0; index < nCount * nCount; index++)

            {

                this.Controls.Add(tbNums[index]);

            }

        }//Form1_Load method



        public void CreateDivider(int xPos, int yPos, int dividerWidth, int dividerLength, bool isRow)
        {
            Label divider = new Label();
            
            divider.BackColor = Color.Black;
            divider.Text = "";
            divider.BorderStyle = BorderStyle.Fixed3D;
            divider.AutoSize = false;
            divider.Size = new Size(dividerWidth, dividerLength);
            divider.BringToFront();
            Controls.Add(divider);

            if (isRow)
            {
                divider.Location = new Point(xPos - 5, yPos);
            }
            else
            {
                divider.Location = new Point(xPos, yPos - 5);
            }
        }//CreateDivider method

        private void ButtonLoadPreloaded_Click(object sender, EventArgs e)
        {

        }
        private void ButtonCheck_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {

        }

        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            SudokuBoard board = new SudokuBoard(tbNums);
            BoardGenerator generator = new BoardGenerator();
            generator.generateBoard(board);
        }
    }
}
