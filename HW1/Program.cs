using System;
using System.Linq;


namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            String caseSwitch = "";

            //Loop until user enters option 5
            while (userInput != 5)
            {
                PrintMenu();
                Console.WriteLine("Please enter an input");
                
                //Readline returns a string
                caseSwitch = Console.ReadLine();

                //convert  string to int for switch case
                userInput = int.Parse(caseSwitch);
                
                //switch case for functions
                switch (userInput)
                {
                    case 1:
                        ConvertFtoC();
                        break;
                    case 2:
                        CalcSphereVol();
                        break;
                    case 3:
                        PrintMultVal();
                        break;
                    case 4:
                        CheckPalindrome();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using this program. Terminating gracefully...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You have entered an incorrect key. Please try again...");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }//while loop
            


        }//Main

        //print menu of program
        static void PrintMenu()
        {
            string dashes = "------------------------------";
            Console.WriteLine(dashes + dashes);
            Console.WriteLine("Enter the following to perform an action");
            Console.WriteLine("1. Calculate Fahrenheit to Celsius.");
            Console.WriteLine("2. Calculate volume of a sphere.");
            Console.WriteLine("3. Prints all values <= n that are multiples of 3 or 5");
            Console.WriteLine("4. Check to see if string is palindrome.");
            Console.WriteLine("5. Exit the program");
            Console.WriteLine(dashes + dashes);
        }//printMenu method

        //asks user for input (fahrenheit) and converts to celsius
        static void ConvertFtoC()
        {
            float userInput;
            float converted;
            Console.WriteLine("Please enter a value (float) for fahrenheit:");
            userInput = float.Parse(Console.ReadLine());

            converted = (userInput - 32) * (float)5 / 9;

            Console.WriteLine("{0} degrees fahrenheit is {1} degrees celsius", userInput, converted);

        }//ConvertFtoC method

        //asks user for input and calculated volume of a sphere
        static void CalcSphereVol()
        {
            double pi = Math.PI;
            double sphereVol = 0;
            float userRadius = 0;

            Console.WriteLine("Please enter the radius (float) of your sphere:");

            userRadius = Int32.Parse(Console.ReadLine());

            sphereVol = (double)4 / 3 * pi * Math.Pow(userRadius,3);
            Console.WriteLine("Your sphere's volume is {0}", sphereVol);

        }//CalcSphereVol method

        //Prints all values <= n that are multiples of 3 or 5
        static void PrintMultVal()
        {
            int userInput = 0;

            Console.WriteLine("Please enter a maximum value (integer) to check for multiples:");

            userInput = Int32.Parse(Console.ReadLine());

            for (int i = 0; i <= userInput; i++)
            {
                if (i % 3 ==0 || i % 5 ==0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Printing completed...");


        }//PrintMultVal method

        //check if user's entered string is a palindrome or not
        static void CheckPalindrome()
        {
            string userInput = "";

            Console.WriteLine("Please enter a string to check if it is a palindrome or not:");

            userInput = Console.ReadLine();

            if (userInput.SequenceEqual(userInput.Reverse()))
            {
                Console.WriteLine("{0} is a palindrome.", userInput);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome", userInput);
            }

        }//CheckPalindrome method

    }//Program class
}//namespace HW1
