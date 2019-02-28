using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Program
    {
        //Given an integer n, this program finds the closest integer (not including itself) 
        //which is both palindromic and a prime number. Closest being the smallest absolute difference
        //between the input and found integer.
        static void Main(string[] args)
        {



            Console.WriteLine("With no Linq " + NearestPalindromicAndPrimeNoLinq("123456789"));
            Console.WriteLine("With Linq " + NearestPalindromicAndPrimeYesLinq("123456789"));

            Console.ReadKey();
        }
        //loop until palindrome prime found
        static string NearestPalindromicAndPrimeNoLinq(string n)
        {
            long num = long.Parse(n);
            for (long i = 1; ; i++)
            {
                if (isPalindromeNoLinq(num - i) && isPrimeNoLinq(num - i))
                {
                    return (num - i).ToString();
                }
                if (isPalindromeNoLinq(num + i) && isPrimeNoLinq(num + i))
                {
                    return (num + i).ToString();
                }
            }
        }

        //this method takes the string, saves the first half to variable,
        //converts the string to an array, reverses the array, then creates
        //a new string and takes the first half (now really the the last half backwards)
        //and returns true or false if the two halfs are the same.
        static bool isPalindromeNoLinq(long num)
        {
            string stringNum = num.ToString();
            string firstHalf = stringNum.Substring(0, stringNum.Length / 2);
            char[] charArray = stringNum.ToCharArray();
            Array.Reverse(charArray);
            string temp = new string(charArray);
            string secondHalf = temp.Substring(0, stringNum.Length / 2);
            return firstHalf == secondHalf;
        }

        //this method loops to check if the number is divisible by any number from 3 until
        //it's square root
        static bool isPrimeNoLinq(long num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i < boundary; i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        //this method calls methods that use linq
        static string NearestPalindromicAndPrimeYesLinq(string n)
        {
            long num = long.Parse(n);
            for (long i = 1; ; i++)
            {
                if (isPalindromeAndPrimeYesLinq(num - i))
                {
                    return (num - i).ToString();
                }
                if (isPalindromeAndPrimeYesLinq(num + i))
                {
                    return (num + i).ToString();
                }
            }
        }

        //this method returns if a number is both an palindrome and a prime number
        static bool isPalindromeAndPrimeYesLinq(long num)
        {
            //these if statements used to remove unnecessary calculations
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            //calculate if palindrome first since it's less computation and the statement
            //can short-circuit this way
            if (num.ToString().SequenceEqual(
                    num.ToString().Reverse()) && Enumerable.Range(2, (int)Math.Sqrt(num) - 1).All(
                divisor => num % divisor != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

