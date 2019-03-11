using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuSelection = 0;
            VendingMachine machine = new VendingMachine();
            do
            {
                Console.WriteLine("Please enter an integer for the option you want to select:");
                Console.WriteLine("1. Print vending machine.");
                Console.WriteLine("2. List only healthy food and drink.");
                Console.WriteLine("3. List toy options for kids under 7.");
                Console.WriteLine("4. Exit Program");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("You have entered an invalid entry!\n");
                    continue;
                }

                List<VendingMachineOption> exclusions = new List<VendingMachineOption>();

                switch (menuSelection)
                {
                    case 1:
                        machine.PrintVendingMachine(new List<VendingMachineOption>());
                        break;
                    case 2:

                        exclusions = machine.Where(t => !(t is Consumable && (t as Consumable)?.CalorieCount <= 100)).ToList();
                        machine.PrintVendingMachine(exclusions);
                        break;
                    case 3:


                        exclusions = machine.Where(t => !(t is NonElectronic || t is Electronic && (t as NonElectronic)?.AgeRequirement < 7 || (t as Electronic)?.AgeRequirement < 7)).ToList();
                        machine.PrintVendingMachine(exclusions);
                        break;
                    case 4:
                        Console.WriteLine("Thankyou for using this program!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("The number you have entered is not valid!\n");
                        continue;
                }
            } while (menuSelection != 4);
        }

        static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
