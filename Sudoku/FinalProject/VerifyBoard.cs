using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    class VerifyBoard
    {
        Dictionary<string,bool> rowDict = new Dictionary<string, bool>();
        Dictionary<string, bool> colDict = new Dictionary<string, bool>();
        Dictionary<string, bool> squareDict = new Dictionary<string, bool>();
        public VerifyBoard()
        {

            rowDict = InitializeDict();
            colDict = InitializeDict();
            squareDict = InitializeDict();
        }

        private Dictionary<string, bool> InitializeDict()
        {
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            for (int i = 0; i < 9; i++)
            {
                dict.Add(i.ToString(), false);
            }
            return dict;
        }



        public bool CheckIfSolvable(int index, SudokuBoard board)
        {
            return (CheckUniqueRow(index, board) && CheckUniqueColumn(index, board) && CheckUniqueSquare(index, board));
        }

        bool CheckUniqueRow(int index, SudokuBoard board)
        {
            int[] nums = new int[9];
            int lowerBound = GetBound(index, -1);
            int upperBound = GetBound(index, 1);
            int rowNumber = upperBound / 9;

            //if (rowDict[(lowerBound / 9).ToString()])
            //{
            //    return true;
            //}
            int counter = 0;
            for (int j = lowerBound; j < upperBound; j++)
            {
                nums[counter] = board.getNumber(j);
                counter++;
            }

            bool returnValue = nums.Length == nums.Where(t => t == 0).ToArray().Length + nums.Where(t => t != 0).Distinct().ToArray().Length;
            //rowDict[rowNumber.ToString()] = returnValue;
            return returnValue;
        }// CheckUniqueRow

        int GetBound(int index, int direction)
        {
            while (index % 9 != 0 && index != 0)
            {
                index += direction;
            }
            return index;
        }//GetBound

        bool CheckUniqueColumn(int index, SudokuBoard board)
        {
            int[] nums = new int[9];
            int columnNumber = index % 9;
            //if (colDict[columnNumber.ToString()])
            //{
            //    return true;
            //}
            int counter = 0;
            for (int i = index % 9; i < board.getBoardLength(); i += 9)
            {
                nums[counter] = board.getNumber(i);
                counter++;
            }

            bool returnValue = nums.Length == nums.Where(t => t == 0).ToArray().Length + nums.Where(t => t != 0).Distinct().ToArray().Length;
            //colDict[columnNumber.ToString()] = returnValue;
            return returnValue;
            
        }// CheckUniqueColumn

        bool CheckUniqueSquare(int index, SudokuBoard board)
        {
            int row = index / 9;
            int col = index - (row * 9);
            int boxStart = (row / 3) * 3 * 9 + (col / 3) * 3;
            int boxStartRow = boxStart / 9;
            int boxStartCol = boxStart - (boxStartRow * 9);
            int[] nums = new int[9];

            //if (squareDict[(boxStartRow / 3 * 3 + boxStartCol / 3).ToString()])
            //{
            //    return true;
            //}

            int newIndex = 0;
            int counter = 0;
            for (int i = boxStartRow; i < boxStartRow + 3; i ++)
            {
                for (int j = boxStartCol; j < boxStartCol + 3; j++)
                {
                    newIndex = i * 9 + j;
                    nums[counter] = board.getNumber(newIndex);
                    counter++;
                }//Inside for loop
            }//outside for loop

            bool returnValue = nums.Length == nums.Where(t => t == 0).ToArray().Length + nums.Where(t => t != 0).Distinct().ToArray().Length;
            //squaredict[boxstart.tostring()] = returnvalue;
            return returnValue;

        }//CheckingUniqueSquare
    }
}
