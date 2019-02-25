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
                int extensionCounter = 0;

                Console.WriteLine("Input: ");
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        
                        searchDirectories = getSearchDirectories();
                        Array videoEnums = Enum.GetValues(typeof(Video.FileTypes));

                        string[] videoExtensions = new string[videoEnums.Length];

                        Console.WriteLine("Scanning for videos:");

                        foreach (FileType fileType in videoEnums)
                        {
                            videoExtensions[extensionCounter] = fileType.ToString();
                            extensionCounter++;
                        }
                        //List<Video> VideoReferences = new List<Video>();

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, videoExtensions);
                        }

                        
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 2:
                        searchDirectories = getSearchDirectories();
                        Array audioEnums = Enum.GetValues(typeof(Audio.FileTypes));
                        string[] AudioExtensions = new string[audioEnums.Length];

                        foreach (FileType fileType in audioEnums)
                        {
                            AudioExtensions[extensionCounter] = fileType.ToString();
                            extensionCounter++;
                        }
                        List<Video> AudioReferences = new List<Video>();
                        Console.WriteLine("Scanning for videos:");

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, AudioExtensions);
                        }

                        foreach (string reference in references)
                        {
                            string refExtension = reference.Substring(reference.Length - 3);
                            FileInfo refFileInfo = new FileInfo(reference);
                            foreach (FileType fileType in audioEnums)
                            {
                                if (refExtension.ToLower() == fileType.ToString().ToLower())
                                {
                                    AudioReferences.Add(new Video(reference, refFileInfo, fileType, MediaType.Video, refFileInfo.LastAccessTime));
                                }

                            }

                        }

                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        searchDirectories = getSearchDirectories();
                        Array imageEnums = Enum.GetValues(typeof(Image.FileTypes));
                        string[] ImageExtensions = new string[imageEnums.Length];

                        foreach (FileType fileType in imageEnums)
                        {
                            ImageExtensions[extensionCounter] = fileType.ToString();
                            extensionCounter++;
                        }
                        Console.WriteLine("Scanning for videos:");

                        List<Video> ImageReferences = new List<Video>();

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref references, ImageExtensions);
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

                        List<string> AllVideoReferences = new List<string>();
                        List<string> AllAudioReferences = new List<string>();
                        List<string> AllImageReferences = new List<string>();

                        GetReferencesHelper(searchDirectories, ref AllVideoReferences, extensions);
                        GetReferencesHelper(searchDirectories, ref AllAudioReferences, extensions);
                        GetReferencesHelper(searchDirectories, ref AllImageReferences, extensions);


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

        private static void GetReferencesHelper(List<string> directories, ref List<string> savedReferences, string[] extensions )
        {
            foreach (string directory in directories)
            {
                GetReferences(directory, ref savedReferences, extensions);
            }
        }

        //Recursively copies all of the files with the specified extension in the specified directory to the destination directory where the executable is
        private static void GetReferences (string sourcePath, ref List<string> references, string[] fileExtensions)
        {

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                foreach (string extension in fileExtensions)
                {
                    if (file.ToLower().EndsWith(extension.ToLower()))
                    {
                        Console.WriteLine("{0} found - {1}", extension, Path.GetDirectoryName(file));
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
            Console.WriteLine("1.Scan for videos (MP4, AVI). \n" +
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
                else if (userInput.ToLower() == "go")
                {
                    break;
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
        public string Path { get; set; }
        public FileInfo File { get; set; }
        public FileType FileType { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime DateAdded { get; set; }

        List<T> mediaList = new List<T>();

        public Media(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded)
        {
            this.Path = Path;
            this.File = File;
            this.FileType = FileType;
            this.MediaType = MediaType;
            this.DateAdded = DateAdded;

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
        public enum FileTypes { MP3, AVI };
        public Audio(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded) :
    base(Path, File, FileType, MediaType, DateAdded)
        {

        }

    }

    public class Image : Media<Image>
    {
        public enum FileTypes { JPG, PNG };
        public Image(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded) :
    base(Path, File, FileType, MediaType, DateAdded)
        {

        }

    }

}
