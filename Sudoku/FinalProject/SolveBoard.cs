using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    class SolveBoard
    {
        SudokuBoard solution = new SudokuBoard();

        public SolveBoard(SudokuBoard board)
        {
            bool something = SolveBoardCheck(board);
            board.SetBoard(solution.GetBoard());

            
        }
        public bool SolveBoardCheck(SudokuBoard board)
        {
            //List<int> nums = new List<int>();
            //for (int i = 0; i < board.getBoardLength(); i++)
            //{
            //    if (board.getNumber(i) == 0)
            //    {
            //        nums.Add(i);
            //    }
            //}
            int num = 0;
            return SolveSudokuBoard(board, num);
        }


        bool SolveSudokuBoard(SudokuBoard board, int num)
        {
            //base case
            if (CheckIfComplete(board)|| num == 81)
            {
                solution.SetBoard(board.GetBoard());
                return true;
            }
            int value = board.getNumber(num);
            bool isZero = value == 0;
            int nextIndex = num + 1;

            //If zero, remove and recurse
            if (!isZero)
            {
                return SolveSudokuBoard(board, nextIndex);
            }
            List<int> availableNumbers = new List<int>();
            availableNumbers = getAvailableNumbers(board, num);

            //for each available num in the list, create new board and recurse
            foreach(int availableNum in availableNumbers)
            {
                SudokuBoard newBoard = new SudokuBoard(board);
                newBoard.setNumber(num, availableNum);
                //if the result of the recursion is false, then a dead end was reached
                bool result = SolveSudokuBoard(newBoard, nextIndex);

                if (result)
                {
                    solution.SetBoard(board.GetBoard());
                    return true;
                }
                //if dead end reached, set that value back to 0
                newBoard.setNumber(num, 0);

            }
            return false;
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


            int colNumber = index - ((index / 9) * 9);
            //Loop through column
            for (int i = colNumber; i < 81; i += 9)
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
