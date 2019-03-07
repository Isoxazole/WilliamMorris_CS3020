using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQProblems;
using System.IO;
using System.Linq;

namespace LINQProblems_Test_Cases
{
    [TestClass]
    public class LINQProblems_Test_Cases
    {
        [TestMethod]
        public void FindStringsInAThatArentInB_Test()
        {
            List<string> a = new List<string>() { "r", "y", "a", "n" };
            List<string> b = new List<string>() { "d", "a", "r", "r", "a", "s" };
            List<string> result = new List<string>();

            for (int i = 0; i < a.Count; i++)
            {
                int exists = 0;
                for (int j = 0; j < b.Count; j++)
                {
                    if (b[j] == a[i])
                    {
                        exists = 1;
                    }
                }
                if (exists == 0)
                {
                    result.Add(a[i]);
                }
            }
            
            try
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Assert.AreEqual(result[i], Program.FindStringsInAThatArentInB()[i]);
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetStraightAStudents_Test()
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

            foreach (Student s in students)
            {
                if (s.MathGrade >= 90.0
                    && s.HistoryGrade >= 90.0
                    && s.ScienceGrade >= 90.0
                    && s.EnglishGrade >= 90.0)
                    a_students.Add(s);
            }

            try
            {
                for (int i = 0; i < a_students.Count; i++)
                {
                    Assert.AreEqual(a_students[i].StudentID, Program.GetStraightAStudents()[i].StudentID);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DetermineWhichItemWasMostProfitable_Test()
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
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemPrice * items[i].NumberOfSales > highestEarner.ItemPrice * highestEarner.NumberOfSales)
                {
                    highestEarner = items[i];
                }
            }

            Item otherHighest = Program.DetermineWhichItemWasMostProfitable();
            Assert.AreEqual(highestEarner.ItemName, otherHighest.ItemName);
            Assert.AreEqual(highestEarner.ItemPrice, otherHighest.ItemPrice);
            Assert.AreEqual(highestEarner.NumberOfSales, otherHighest.NumberOfSales);
        }

        [TestMethod]
        public void QueryPhoneBookEntries_Test()
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


            results.Add("Name", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.Name == "Josh Jackson")
                    results["Name"].Add(entry);
            }

            results.Add("LastName", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.LastName == "Jones")
                    results["LastName"].Add(entry);
            }

            results.Add("City", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.City == "Colorado Springs")
                    results["City"].Add(entry);
            }

            results.Add("PhoneAreaCode", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.PhoneNumber.Substring(0, 3) == "617")
                    results["PhoneAreaCode"].Add(entry);
            }

            Dictionary<string, List<PhoneBookEntry>> mainResults = Program.QueryPhoneBookEntries();

            try
            {
                Assert.AreEqual(results["Name"][0].Name, mainResults["Name"][0].Name);
                Assert.AreEqual(results["LastName"][2].LastName, mainResults["LastName"][2].LastName);
                Assert.AreEqual(results["City"][1].City, mainResults["City"][1].City);
                Assert.AreEqual(results["PhoneAreaCode"][1].PhoneNumber.Substring(0, 3), mainResults["PhoneAreaCode"][1].PhoneNumber.Substring(0, 3));
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAllPNG_Test()
        {
            List<FileInfo> testFiles = GetAllPNG(@"C:\Users\Ryan\Pictures\").OrderBy(t => t.Name).ToList();
            List<FileInfo> otherFiles = Program.GetAllPNG(@"C:\Users\Ryan\Pictures\");

            for(int i = 0; i < testFiles.Count; i++)
            {
                Assert.AreEqual(testFiles[i].Name, otherFiles[i].Name);
            }

            List<FileInfo> GetAllPNG(string path)
            {
                /* Hints for this problem:
                 * new DirectoryInfo(path).EnumerateDirectories("*", SearchOption.AllDirectories);
                 * directory.EnumerateFiles("*.png")
                 */

                List<FileInfo> files = new List<FileInfo>();
                foreach (DirectoryInfo directory in new DirectoryInfo(path).GetDirectories())
                {
                    files.AddRange(GetAllPNG(directory.FullName));
                }

                foreach (FileInfo file in new DirectoryInfo(path).GetFiles("*.png"))
                {
                    files.Add(file);
                }
                return files;
            }
        }

        [TestMethod]
        public void GetFibonacciNumbers()
        {
            List<int> input = new List<int>();
            for (int i = 1; i < 40; i += 5)
                input.Add(i);
            List<int> results = new List<int>();

            foreach (int i in input)
            {
                results.Add(Fibonacci(i));
            }

            //Local function for recursive search
            int Fibonacci(int i)
            {
                if (i == 1 || i == 2)
                    return 1;
                return Fibonacci(i - 1) + Fibonacci(i - 2);
            }

            List<int> linqResults = Program.GetFibonacciNumbers();
            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual(results[i], linqResults[i]);
            }
        }

        [TestMethod]
        public void SumPrimes_Test()
        {
            int primeSum = 0;
            for (int i = 2; i < 1000; i++)
            {
                bool isPrime = true;
                for (int c = 2; c < i; c++)
                {
                    if (i % c == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime == true)
                {
                    primeSum += i;
                }
            }
            Assert.AreEqual(primeSum, Program.SumPrimes());
        }
    }
}
