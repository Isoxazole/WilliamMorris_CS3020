using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{

    enum difficulty { easy, med, hard}
    class BoardGenerator
    {

        public BoardGenerator()
        {
        }

        public void generateBoard(SudokuBoard board)
        {
            VerifyBoard verify = new VerifyBoard();

            int numFill = 0;
            difficulty setting = difficulty.med;
            switch(setting)
            {
                case difficulty.hard:
                    numFill = 9;
                    break;
                case difficulty.med:
                    numFill = 17;
                    break;
                case difficulty.easy:
                    numFill = 25;
                    break;
            }

            int counter = 0;
            Random rand = new Random();
            while (counter < numFill)
            {
                int index = rand.Next(0, 81);
                int value = rand.Next(1, 10);
                if (board.getNumber(index) != 0)
                {
                    continue;
                }
                else
                {
                    board.setNumber(index, value);
                    if (verify.CheckIfSolvable(index, board))
                    {
                        counter++;
                    }
                    else
                    {
                        board.setNumber(index, 0);
                    }
                }
            }//while loop
        }//Generate Board

    }//Board Generator class
}
