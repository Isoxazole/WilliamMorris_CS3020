using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    class SolveBoard
    {
        SolveBoard()
        {

        }
        public SudokuBoard SolveBoardCheck(SudokuBoard board)
        {
            List<int> nums = new List<int>();
            for (int i = 0; i < board.getBoardLength(); i++)
            {
                if (board.getNumber(i) == 0)
                {
                    nums.Add(i);
                }
            }
            return SolveSudokuBoard(board, nums);
        }

        SudokuBoard SolveSudokuBoard(SudokuBoard board, List<int> nums)
        {
            //base case
            if (CheckIfComplete(board))
            {
                return board;
            }
            int index = nums[0];
            nums.RemoveAt(0);
            int value = board.getNumber(index);
            bool isZero = value == 0;

            //If zero, remove and recurse
            if (isZero)
            {
                nums.RemoveAt(0);
                return (SolveSudokuBoard(board, nums));
            }
            List<int> availableNumbers = new List<int>();
            availableNumbers = getAvailableNumbers(board, nums[0]);


            foreach(int num in availableNumbers)
            {
                board.setNumber(index, num);
                SudokuBoard result = SolveSudokuBoard(board, nums);

                if (CheckIfComplete(board))
                {
                    return board;
                }

                board.setNumber(index, 0);

            }
            return board;
        }//SolveSudokuBoard
    
        List<int> getAvailableNumbers(SudokuBoard board, int index)
        {
            List<int> nums = new List<int>();
            nums = Enumerable.Range(1, 9).ToList();
            int rowNumber = index / 9;
            int startRowIndex = rowNumber * 9;

            //Loop through row to get nums
            for (int i = startRowIndex; i < startRowIndex + 9; i ++)
            {
                int boardNum = board.getNumber(i);
                if (boardNum != 0)
                {
                    nums.Remove(boardNum);
                }
            }//For loop


            int colNumber = index % 9;
            //Loop through column
            for (int i = colNumber; i < 81; colNumber += 9)
            {
                int boardNum = board.getNumber(i);
                if (boardNum != 0)
                {
                    nums.Remove(boardNum);
                }
            }//Foor loop

            //check square
            int row = index / 9;
            int col = index - (row * 9);
            int boxStart = (row / 3) * 3 * 9 + (col / 3) * 3;
            int boxStartRow = boxStart / 9;
            int boxStartCol = boxStart - (boxStartRow * 9);
            for (int i = boxStartRow; i < boxStartRow + 3; i++)
            {
                for (int j = boxStartCol; j < boxStartCol + 3; j ++)
                {
                    int boardNum = board.getNumber(i * 9 + j);
                    if (boardNum != 0)
                    {
                        nums.Remove(boardNum);
                    }
                }
            }
            return nums;

        }//GetAvailableNumbers

        public bool CheckIfComplete(SudokuBoard board)
        {
            bool complete = true;
            for (int i = 0; i < board.getBoardLength(); i++)
            {
                if (board.getNumber(i) == 0)
                {
                    complete = false;
                    break;
                }
            }
            return complete;
        }
    }
}
