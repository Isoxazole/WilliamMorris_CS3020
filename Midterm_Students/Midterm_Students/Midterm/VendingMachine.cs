using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class VendingMachine : IEnumerable<VendingMachineOption>
    {
        VendingMachineOption[,] options = new VendingMachineOption[5,4];

        public VendingMachine()
        {
            options[0, 0] = new Food("Jalapeno Chips", 1.25f, 11, 280, 1, 5000, true);
            options[0, 1] = new NonElectronic("Action Figure", 9.99f, 10, 6, true);
            options[0, 2] = new Electronic("BlackJack", 12.99f, 15, 11, true, Genre.Puzzle);
            options[0, 3] = new Drink("Gatorade", 1.99f, 8, 60, 16, false);
            options[1, 0] = new Food("Cookies", 1.99f, 9, 80, .8f, 0, false);
            options[1, 1] = new Food("Spicy Slim Jim", .99f, 12, 100, .7f, 1250, false);
            options[1, 2] = new Drink("Water sm", .99f, 7, 0, 12, true);
            options[1, 3] = new Drink("Water lg", 1.99f, 6, 0, 20, true);
            options[2, 0] = new NonElectronic("Deck of cards", 1.99f, 5, 3, false);
            options[2, 1] = new Electronic("Bopit", 9.99f, 3, 5, false, Genre.Puzzle);
            options[2, 2] = new Food("Donut", .99f, 8, 150, .65f, 0, false);
            options[2, 3] = new NonElectronic("Legos", 5.99f, 10, 9, true);
            options[3, 0] = new Electronic("Drone", 39.99f, 2, 16, false, Genre.Action);
            options[3, 1] = new Electronic("Tamagotchi", 6.99f, 7, 3, true, Genre.Story);
            options[3, 2] = new NonElectronic("Monopoly", 19.99f, 4, 4, false);
            options[3, 3] = new NonElectronic("Doll", 4.99f, 7, 2, false);
            options[4, 0] = new Drink("Pepsi", 1.99f, 10, 180, 12, false);
            options[4, 1] = new Electronic("RC Car", 24.99f, 2, 9, true, Genre.Action);
            options[4, 2] = new Food("Apple Sauce", 1.49f, 7, 30, .1f, 0, true);
            options[4, 3] = new Drink("Red Bull", 2.99f, 6, 140, 8, false);
        }

        public VendingMachineOption this[int x, int y]
        {
            get { return options[x, y]; }
        }

        public void PrintVendingMachine(List<VendingMachineOption> exclusions)
        {
            Console.WriteLine();
            Console.WriteLine("X        A              B              C              D       ");
            Console.WriteLine("Y ------------------------------------------------------------");
            for (int row = 0; row < 5; row++)
            {
                Console.Write(row + "|");
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(exclusions.Contains(options[row, col]) ? FormattedStringToFifteenCharCentered("X") : FormattedStringToFifteenCharCentered(options[row, col].ToString()));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("  ------------------------------------------------------------");
            Console.WriteLine();
        }

        private string FormattedStringToFifteenCharCentered(string s)
        {
            int count = s.Length;
            int amountNeeded = 15 - count;
            int left = amountNeeded / 2;
            return s.PadLeft(count + left).PadRight(15);
        }

        public IEnumerator GetEnumerator()
        {
            return options.GetEnumerator();
        }


        IEnumerator<VendingMachineOption> IEnumerable<VendingMachineOption>.GetEnumerator()
        {
            return options.Cast<VendingMachineOption>().GetEnumerator();
        }
    }
}
