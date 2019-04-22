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
        public TextBox[] grid;

        public SudokuBoard(TextBox[] boxes)
        {
            grid = boxes;
            clearBoard();
        }

        public SudokuBoard(SudokuBoard currBoard, SudokuBoard newBoard)
        {
            Array.Copy(currBoard.grid, newBoard.grid, newBoard.getBoardLength());
        }

        public int getNumber(int i)
        {
            return int.Parse(grid[i].Text);
        }
        
        public void setNumber(int i,int num )
        {
            grid[i].Text = num.ToString();
        }

        public int getBoardLength()
        {
            return grid.Length;
        }

        public void clearBoard()
        {
            for (int i = 0; i < getBoardLength(); i++)
            {
                grid[i].Text = "0";
            }
        }

    }
}
