using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HW4
{
    public enum FileType { WAV, MP3, MP4, AVI, MOV, PNG, JPG }
    public enum MediaType { Audio, Video, Image }

    class Program
    {



        static void Main(string[] args)
        {

            int userInput = 0;
            List<string> searchDirectories = new List<string>();
            List<string> references = new List<string>();
            while (userInput != 8)
            {
                PrintMenu();

                Console.WriteLine("Input: ");
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        
                        searchDirectories = getSearchDirectories();

                        string[] videoExtensions = new string[Enum.GetValues(typeof(Video.FileTypes)).Length];
                        int extensionCounter = 0;
                        foreach (FileType fileType in Enum.GetValues(typeof(Video.FileTypes)))
                        {
                            videoExtensions[extensionCounter] = fileType.ToString();
                        }
                        
        
                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, videoExtensions);
                        }

                        List<Video> videoReferences = new List<Video>();
                        foreach (string reference in references)
                        {
                            string refExtension = reference.Substring(reference.Length - 3);
                            FileInfo refFileInfo = new FileInfo(reference);
                            foreach (FileType extension in Enum.GetValues(typeof(FileType)))
                            {
                                if (refExtension.ToLower() == extension.ToString())
                                {
                                    videoReferences.Add(new Video(reference, refFileInfo, extension, MediaType.Video, refFileInfo.LastAccessTime));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid file!");
                                }
                            }
                            
                        }
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 2:
                        searchDirectories = getSearchDirectories();
                        string mp3 = FileType.MP3.ToString();
                        string wav = FileType.WAV.ToString();
                        string[] audioExtensions = { mp3, wav };
                        Console.WriteLine("Scanning for videos:");

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, audioExtensions);
                        }

                        List<Video> AudioReferences = new List<Video>();
                        foreach (string reference in references)
                        {
                            string refExtension = reference.Substring(reference.Length - 3);
                            FileInfo refFileInfo = new FileInfo(reference);
                            if (refExtension == mp3)
                            {
                                AudioReferences.Add(new Video(reference, refFileInfo, FileType.MP3, MediaType.Video, refFileInfo.LastAccessTime));
                            }
                            else if (refExtension == wav)
                            {
                                AudioReferences.Add(new Video(reference, refFileInfo, FileType.WAV, MediaType.Video, refFileInfo.LastAccessTime));
                            }
                            else
                            {
                                Console.WriteLine("Invalid file!");
                            }

                        }
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        searchDirectories = getSearchDirectories();
                        string png = FileType.PNG.ToString();
                        string jpg = FileType.JPG.ToString();
                        string[] imageExtensions = { png, jpg };
                        Console.WriteLine("Scanning for videos:");

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, imageExtensions);
                        }

                        List<Video> ImageReferences = new List<Video>();
                        foreach (string reference in references)
                        {
                            string refExtension = reference.Substring(reference.Length - 3);
                            FileInfo refFileInfo = new FileInfo(reference);
                            if (refExtension == png)
                            {
                                ImageReferences.Add(new Video(reference, refFileInfo, FileType.PNG, MediaType.Video, refFileInfo.LastAccessTime));
                            }
                            else if (refExtension == jpg)
                            {
                                ImageReferences.Add(new Video(reference, refFileInfo, FileType.JPG, MediaType.Video, refFileInfo.LastAccessTime));
                            }
                            else
                            {
                                Console.WriteLine("Invalid file!");
                            }

                        }
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;

                    case 4:
                        searchDirectories = getSearchDirectories();
                        string[] extensions = new string[Enum.GetValues(typeof(FileType)).Length];
                        int counter = 0;
                        foreach (FileType fileType in Enum.GetValues(typeof(FileType)))
                        {
                            extensions[counter] = (fileType.ToString());
                            counter++;
                        }
                        Console.WriteLine("Scanning for all:");

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, extensions);
                        }

                        List<Video> AllReferences = new List<Video>();
                        foreach (string reference in references)
                        {
                            string refExtension = reference.Substring(reference.Length - 3);
                            FileInfo refFileInfo = new FileInfo(reference);

                            foreach (string extension in extensions)
                            {
                                if (refExtension == extension)
                                {
                                    AllReferences.Add()
                                }
                            }
                            if (refExtension == mp3)
                            {
                                AllReferences.Add(new Video(reference, refFileInfo, FileType.MP3, MediaType.Video, refFileInfo.LastAccessTime));
                            }
                            else if (refExtension == wav)
                            {
                                AudioReferences.Add(new Video(reference, refFileInfo, FileType.WAV, MediaType.Video, refFileInfo.LastAccessTime));
                            }
                            else
                            {
                                Console.WriteLine("Invalid file!");
                            }

                        }
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;

                    
                }

            }//While loop


        }//Main

        //Recursively copies all of the files with the specified extension in the specified directory to the destination directory where the executable is
        private static void GetReferences(string sourcePath, ref List<string> references, string[] fileExtensions)
        {

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                for (int i = 0; i < fileExtensions.Length; i++)
                {
                    if (file.ToLower().EndsWith(fileExtensions[i].ToLower()))
                    {
                        Console.WriteLine("{0} found - {1}", fileExtensions[i], Path.GetDirectoryName(file));
                        references.Add(file);
                    }
                }//for loop

            }//foreach loop

            foreach (DirectoryInfo directory in new DirectoryInfo(sourcePath).GetDirectories())
            {
                GetReferences(directory.FullName, ref references, fileExtensions);

            }


        }//CopyFiles method


        private static void PrintMenu()
        {
            string dashes = "-------------------------------------";
            Console.WriteLine(dashes + dashes);
            Console.WriteLine(" 1.Scan for videos (MP4, AVI). \n" +
                "2. Scan for audio (MP3, WAV). \n" +
                "3. Scan for images (PNG, JPG).\n" +
                "4. Scan for all.\n" +
                "5. Access video library.\n" +
                "6. Access audio library.\n" +
                "7. Access image library.\n" +
                "8. Close program.");
            Console.WriteLine(dashes + dashes);
        }

        private static List<string> getSearchDirectories()
        {
            string userInput = "";
            List<string> searchDirectories = new List<string>();
            while (userInput.ToLower() != "go")
            {
                Console.WriteLine("Please input a full directory path that you want to scan:");
                userInput = Console.ReadLine();
                if (Directory.Exists(userInput))
                {
                    searchDirectories.Add(userInput);
                    Console.WriteLine("Path added to scan options. \n");
                    Console.WriteLine("Type GO to run scan. Or. . .");
                }
                else
                {
                    Console.WriteLine("Path does not exists, verify you have entered a valid path!");
                }
            }//While loop

            return searchDirectories;
            
        }
    }




    public abstract class Media<T> : IEnumerable<T>
    {
        string Path { get; set; }
        FileInfo File { get; set; }
        FileType FileType { get; set; }
        MediaType MediaType { get; set; }
        DateTime DateAdded { get; set; }

        List<T> mediaList = new List<T>();

        public Media(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded)
        {
            this.Path = Path;

        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }



    public class Video : Media<Video>
    {
        public enum FileTypes{ MP4, WAV };
        
        
        public Video(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded) : 
            base (Path, File, FileType, MediaType, DateAdded)
        {
            
        }
    }

    public class Audio : Media<Audio>
    {
        public Audio(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded) :
    base(Path, File, FileType, MediaType, DateAdded)
        {

        }

    }

    public class Image : Media<Image>
    {
        public Image(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded) :
    base(Path, File, FileType, MediaType, DateAdded)
        {

        }

    }

}
