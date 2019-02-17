using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This program recurively copies any file extensions specified by the user in whater directories that are specfified both in the
 * config text file. The destination of the copy is in the same location as the executable. 
 */

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> searchDirectories = new List<string>();
            string[] fileExtensions = GetCopyParameters(ref searchDirectories);
            string destinationDirectory = AppDomain.CurrentDomain.BaseDirectory + "FoundFiles";


            Console.WriteLine("Running application");
            foreach (string directory in searchDirectories)
            {
                CopyFiles(directory, Path.Combine(destinationDirectory, directory.Substring(Path.GetPathRoot(directory).Length)), fileExtensions);
            }
            Console.WriteLine("Application finished");
            Console.ReadKey();

        }//Main

        //Recursively copies all of the files with the specified extension in the specified directory to the destination directory where the executable is
        private static void CopyFiles(string sourcePath, string destinationDirectory, string[] fileExtensions)
        {

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                for (int i = 0; i < fileExtensions.Length; i++)
                {
                    if (file.ToLower().EndsWith(fileExtensions[i].TrimStart('*')))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                        File.Copy(file, Path.Combine(destinationDirectory, Path.GetFileName(file)), true);
                        Console.WriteLine("Found file " + Path.GetFileName(file) + " in " + Path.GetDirectoryName(file));
                    }
                }//for loop
                
            }//foreach loop

            foreach (DirectoryInfo directory in new DirectoryInfo(sourcePath).GetDirectories())
            {
                CopyFiles(directory.FullName, Path.Combine(destinationDirectory, directory.Name), fileExtensions);

            }
            

        }//CopyFiles method

        //reads in the config text file to get the extensions and the directories to copy
        private static string[] GetCopyParameters(ref List<string> directories)
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            
            using (StreamReader sr = new StreamReader(configPath))
            {

                string line;    
                line = sr.ReadLine();
                string[] fileExtenstions = line.Split(',');
                //As long as lines remain, continue adding them
                while((line = sr.ReadLine()) != null)
                {
                    directories.Add(line);
                }
                return fileExtenstions;
            }
        }//GetCopyParameters method

    }
}
