using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuProject

{
    class SudokuBoard
    {
        public TextBox[] grid = new TextBox[81];
        public SudokuBoard()
        {
        }

        public void SetBoard(TextBox[] boxes)
        {
            grid = boxes;
        }
        public TextBox[] GetBoard()
        {
            return grid;
        }

        public SudokuBoard(SudokuBoard currBoard)
        {
            Array.Copy(currBoard.grid, grid, currBoard.getBoardLength());
        }
        //replace empty string with 0
        public int getNumber(int i)
        {
            if (grid[i].Text == "")
            {
                return 0;
            }
            else
            {
                return int.Parse(grid[i].Text);
            }
        }
        //replace 0 with empty string
        public void setNumber(int i,int num )
        {
            if (num == 0)
            {
                grid[i].Text = "";
            }
            else
            {
                grid[i].Text = num.ToString();
            }
        }

        public int getBoardLength()
        {
            return grid.Length;
        }

        public void clearBoard()
        {
            for (int i = 0; i < getBoardLength(); i++)
            {
                grid[i].Text = "";
            }
        }

    }
}
