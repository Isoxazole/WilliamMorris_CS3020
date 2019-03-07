using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQProblems
{
    public class Program
    {
        static void Main(string[] args)
        {
            FindStringsInAThatArentInB();
            GetStraightAStudents();
            DetermineWhichItemWasMostProfitable();
            QueryPhoneBookEntries();
            GetAllPNG(@"C:\Users\Ryan\Pictures\"); //NOTE: READ SUMMARY COMMENT ABOVE METHOD
            GetFibonacciNumbers();
            SumPrimes();
        }

        /// <summary>
        /// Result should equal any string in a that isn't also in b.
        /// Result = { "y", "n" }
        /// </summary>
        public static List<string> FindStringsInAThatArentInB()
        {
            List<string> a = new List<string>() { "r", "y", "a", "n" };
            List<string> b = new List<string>() { "d", "a", "r", "r", "a", "s" };
            List<string> result = new List<string>();

            //New Link method
            result = a.Except(b).ToList();
            return result;
        }

        /// <summary>
        /// Gets a subset of students that maintain all A's.
        /// Result = { 2, 6, 8 }
        /// </summary>
        public static List<Student> GetStraightAStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student(1, 87, 89, 91, 92),
                new Student(2, 90, 92, 93, 99),
                new Student(3, 87, 91, 97, 100),
                new Student(4, 86, 88, 93, 100),
                new Student(5, 86, 89, 94, 98),
                new Student(6, 93, 94, 99, 100),
                new Student(7, 87, 89, 95, 99),
                new Student(8, 91, 94, 95, 97),
                new Student(9, 85, 94, 99, 100),
                new Student(10, 85, 92, 93, 95),
            };

            List<Student> a_students = new List<Student>();

            //new Linq way
            a_students = students.Where(t => t.MathGrade >= 90.0
                    && t.HistoryGrade >= 90.0
                    && t.ScienceGrade >= 90.0
                    && t.EnglishGrade >= 90.0).ToList();
            return a_students;
        }



        /// <summary>
        /// Determines which item profited the most
        /// </summary>
        public static Item DetermineWhichItemWasMostProfitable()
        {
            List<Item> items = new List<Item>()
            {
                new Item("TV", 5, 515.15f),
                new Item("DVD Player", 10, 100.05f),
                new Item("Toy Horse", 2, 25.25f),
                new Item("Shovel", 1, 10.99f),
                new Item("Kite", 4, 5.77f),
                new Item("Stapler", 15, 5.98f),
                new Item("Pen", 25, 2.25f),
                new Item("Candy Bar", 102, 1.5f),
                new Item("DVD", 45, 20),
                new Item("Soda", 66, 1.5f),
            };

            Item highestEarner = new Item("TEMP", 0, 0);

            //New Linq way
            highestEarner = items.Aggregate((t, t2) => t.ItemPrice * t.NumberOfSales > t2.ItemPrice * t.NumberOfSales ? t : t2);
            return highestEarner;
        }

        /// <summary>
        /// Queries various things from a phone book
        /// </summary>
        public static Dictionary<string, List<PhoneBookEntry>> QueryPhoneBookEntries()
        {
            List<PhoneBookEntry> phoneBook = new List<PhoneBookEntry>()
            {
                new PhoneBookEntry("Sarah", "Jones", "1887 Flat Iron Court", "Colorado Springs", "CO", "80921", "(719) 354-1857"),
                new PhoneBookEntry("Josh", "Jones", "1887 Flat Iron Court", "Colorado Springs", "CO", "80921", "(719) 354-1855"),
                new PhoneBookEntry("Bryan", "Adams", "1665 Snowflake Lane", "Boston", "MA", "02101", "(617) 143-1566"),
                new PhoneBookEntry("John", "Smith", "4745 Meadowland Blvd", "San Diego", "CA", "22434", "(619) 354-6543"),
                new PhoneBookEntry("Josh", "Jackson", "1145 Piros Drive", "Orlando", "FL", "32789", "(407) 650-8333"),
                new PhoneBookEntry("Hannah", "Maben", "1710 Main Street", "Boston", "MA", "02101", "(617) 765-1857"),
                new PhoneBookEntry("Harrison", "James", "1010 Maple Lane", "Denver", "CO", "80014", "(720) 123-4567"),
                new PhoneBookEntry("Xavier", "Carlyle", "1552 Washington Avenue", "San Diego", "CA", "22434", "(619) 987-5465"),
                new PhoneBookEntry("Michael", "Jones", "6510 Cherry Creek Lane", "Springfield", "TX", "75853", "(361) 234-985"),
                new PhoneBookEntry("Sarah", "Smith", "1223 Mirage Drive", "Springfield", "TX", "75853", "(361) 127-5643"),
            };

            Dictionary<string, List<PhoneBookEntry>> results = new Dictionary<string, List<PhoneBookEntry>>();

            //New Linq method
            results["Name"] = (from PhoneBookEntry t in phoneBook where t.Name == "Josh Jackson" select t).ToList();
            results["LastName"] = (from PhoneBookEntry t in phoneBook where t.LastName == "Jones" select t).ToList();
            results["City"] = (from PhoneBookEntry t in phoneBook where t.City == "Colorado Springs" select t).ToList();
            results["PhoneAreaCode"] = (from PhoneBookEntry t in phoneBook where t.PhoneNumber.Substring(0, 3) == "617" select t).ToList();
            return results;
        }

        /// <summary>
        /// HW 3. Finds all jpgs in the given path
        /// 
        /// You will need to change your path in multiple locations to test this.
        /// 1. In Main of this file.
        /// 2. In GetAllPNG_Test in LINQProblems_Test_Cases.cs
        /// 
        /// PLEASE CHANGE BOTH BACK TO @"C:\Users\Ryan\Pictures\" WHEN YOU FINALIZE AND SUMBIT!!!!
        /// </summary>
        public static List<FileInfo> GetAllPNG(string path)
        {
            /* Hints for this problem:
             * new DirectoryInfo(path).EnumerateDirectories("*", SearchOption.AllDirectories);
             * directory.EnumerateFiles("*.png")
             * 
             * However, the enumerated method above might throw exceptions on files that cannot be accessed.
             * To solve this, just test on a path that you know is safe.
             */

            List<FileInfo> files = new List<FileInfo>();

            // new linq way
            files = new DirectoryInfo(path).GetFiles().Where(t => t.FullName.ToLower().EndsWith(".png")).ToList();

            return files;
        }

        /// <summary>
        /// Gets the fibonacci numbers for a list of integers
        /// </summary>
        public static List<int> GetFibonacciNumbers()
        {

            List<int> results = new List<int>();

            //new Linq method
            Enumerable.Range(0, 40).Where(s => (s - 1) % 5 == 0).ToList().ForEach(t => results.Add(fibonacci(t)));
            int fibonacci(int i) => i == 1 || i ==2 ? 1 : fibonacci(i - 1) + fibonacci(i - 2);
            
            return results;
        }

        /// <summary>
        /// Finds and sums the values of all primes between 2 and 1,000
        /// Result = 76,127
        /// </summary>
        public static int SumPrimes()
        {    
            //return new linq method
            return Enumerable.Range(2, 1000 - 1).Where(
                num => Enumerable.Range(2, (int)Math.Sqrt(num)-1).All(
                    divisor => num % divisor != 0)).Sum();
        }
    }
}
