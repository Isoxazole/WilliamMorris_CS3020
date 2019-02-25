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

                        string[] videoExtensions = new string[Enum.GetValues(typeof(Video.FileTypes)).Length];

                        Console.WriteLine("Scanning for videos:");

                        foreach (FileType fileType in Enum.GetValues(typeof(Video.FileTypes)))
                        {
                            videoExtensions[extensionCounter] = fileType.ToString();
                            extensionCounter++;
                        }
                        List<Video> VideoReferences = new List<Video>();

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref VideoReferences, videoExtensions);
                        }

                        
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 2:
                        searchDirectories = getSearchDirectories();
                        string[] AudioExtensions = new string[Enum.GetValues(typeof(Audio.FileTypes)).Length];

                        foreach (FileType fileType in Enum.GetValues(typeof(Audio.FileTypes)))
                        {
                            AudioExtensions[extensionCounter] = fileType.ToString();
                            extensionCounter++;
                        }
                        List<Video> AudioReferences = new List<Video>();
                        Console.WriteLine("Scanning for videos:");

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref AudioReferences, AudioExtensions);
                        }

                        
                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        searchDirectories = getSearchDirectories();
                        string[] ImageExtensions = new string[Enum.GetValues(typeof(Image.FileTypes)).Length];

                        foreach (FileType fileType in Enum.GetValues(typeof(Video.FileTypes)))
                        {
                            ImageExtensions[extensionCounter] = fileType.ToString();
                            extensionCounter++;
                        }
                        Console.WriteLine("Scanning for videos:");

                        List<Video> ImageReferences = new List<Video>();

                        foreach (string directory in searchDirectories)
                        {
                            GetReferences(directory, ref ImageReferences, ImageExtensions);
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

                        List<Video> AllVideoReferences = new List<Video>();
                        List<Audio> AllAudioReferences = new List<Audio>();
                        List<Image> AllImageReferences = new List<Image>();

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

        private static void GetReferencesHelper<T>(List<string> directories, ref List<T> savedReferences, string[] extensions ) where T: Media<T>
        {
            foreach (string directory in directories)
            {
                GetReferences(directory, ref savedReferences, extensions);
            }
        }

        //Recursively copies all of the files with the specified extension in the specified directory to the destination directory where the executable is
        private static void GetReferences<T> (string sourcePath, ref List<T> references, string[] fileExtensions) where T : Media<T>
        {

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                foreach (string extension in fileExtensions)
                {
                    if (file.ToLower().EndsWith(extension.ToLower()))
                    {
                        Console.WriteLine("{0} found - {1}", extension, Path.GetDirectoryName(file));
                        T obj = (T)Activator.CreateInstance(typeof(T));
                        string path = Path.GetDirectoryName(file);
                        FileInfo varFile = new FileInfo(file);
                        FileType varFileType = (FileType)Enum.Parse(typeof(FileType), extension);
                        MediaType varMediaType = (MediaType)Enum.Parse(typeof(MediaType), typeof(T).ToString());
                        DateTime varDateAdded = obj.File.LastAccessTime;

                        obj.Path = path;
                        obj.File = varFile;
                        obj.FileType = varFileType;
                        obj.MediaType = varMediaType;
                        obj.DateAdded = varDateAdded;
                            
                        
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
