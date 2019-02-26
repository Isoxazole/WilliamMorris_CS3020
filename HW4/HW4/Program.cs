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
            List<Video> VideoReferences = new List<Video>();
            List<Audio> AudioReferences = new List<Audio>();
            List<Image> ImageReferences = new List<Image>();
            
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

                        string[] VideoExtensions = new string[videoEnums.Length];

                        Console.WriteLine("Scanning for videos:");

                        foreach (Video.FileTypes fileType in videoEnums)
                        {
                            VideoExtensions[extensionCounter] = Enum.Parse(typeof(FileType), fileType.ToString(), true).ToString();
                            extensionCounter++;
                        }
                        GetReferencesHelper(searchDirectories, ref references, VideoExtensions);

                        CreateVideoReferences(references, videoEnums, ref VideoReferences);


                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 2:
                        searchDirectories = getSearchDirectories();
                        Array audioEnums = Enum.GetValues(typeof(Audio.FileTypes));
                        string[] AudioExtensions = new string[audioEnums.Length];

                        foreach (Audio.FileTypes fileType in audioEnums)
                        {
                            AudioExtensions[extensionCounter] = Enum.Parse(typeof(FileType), fileType.ToString(), true).ToString();
                            extensionCounter++;
                        }

                        Console.WriteLine("Scanning for videos:");

                        GetReferencesHelper(searchDirectories, ref references, AudioExtensions);

                        CreateAudioReferences(references, audioEnums, ref AudioReferences);


                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        searchDirectories = getSearchDirectories();
                        Array imageEnums = Enum.GetValues(typeof(Image.FileTypes));
                        string[] ImageExtensions = new string[imageEnums.Length];

                        foreach (Image.FileTypes fileType in imageEnums)
                        {
                            ImageExtensions[extensionCounter] = Enum.Parse(typeof(FileType), fileType.ToString(), true).ToString();
                            extensionCounter++;
                        }
                        Console.WriteLine("Scanning for videos:");


                        GetReferencesHelper(searchDirectories, ref references, ImageExtensions);
                        CreateImageReferences(references, imageEnums, ref ImageReferences);


                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;

                    case 4:
                        searchDirectories = getSearchDirectories();
                        Array allTypeEnums = Enum.GetValues(typeof(FileType));
                        string[] extensions = new string[allTypeEnums.Length];
                        
                        foreach (FileType fileType in Enum.GetValues(typeof(FileType)))
                        {
                            extensions[extensionCounter] = (fileType.ToString());
                            extensionCounter++;
                        }
                        Console.WriteLine("Scanning for all:");


                        List<string> AllReferences = new List<string>();

                        GetReferencesHelper(searchDirectories, ref AllReferences, extensions);

                        CreateVideoReferences(AllReferences, Enum.GetValues(typeof(Video.FileTypes)), ref VideoReferences);
                        CreateAudioReferences(AllReferences, Enum.GetValues(typeof(Audio.FileTypes)), ref AudioReferences);
                        CreateImageReferences(AllReferences, Enum.GetValues(typeof(Image.FileTypes)), ref ImageReferences);

                        Console.WriteLine("\nFinished scanning. . . Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 5:
                        //access video library
                        LibraryControl(VideoReferences);


                        break;
                    case 6:
                        //access audio library
                        PrintLibrary(AudioReferences);

                        break;
                    case 7:
                        //access image library
                        PrintLibrary(ImageReferences);

                        break;
                    case 8:

                        break;

                    
                }

            }//While loop


        }//Main

        private static void LibraryControl<T>(List<T> References) where T: Media<T>
        {
            T[] array = PrintLibrary(References);
            PrintLibraryMenu();
            int userInput = 0; 
            while (userInput != 7)
            {
                
                userInput = int.Parse(Console.ReadLine());
                switch(userInput)
                {
                    case 1:
                        References = References.OrderBy(t => t.File.Name).ToList();
                        break;
                    case 2:
                        References = References.OrderBy(t => t.FileType).ToList();
                        break;
                    case 3:
                        References = References.OrderBy(t => t.DateAdded).ToList();
                        PrintLibrary(References);
                        break;
                    case 4:
                        Console.WriteLine("What is the index of the file you want to touch? (not inappropriately of course)");
                        int touchUserInput = int.Parse(Console.ReadLine());
                        if (touchUserInput > References.Count() || touchUserInput <= 0)
                        {
                            Console.WriteLine("You have entered an index out of range");
                        }
                        else
                        {
                            File.SetLastAccessTime(References[touchUserInput + 1].Path.ToString(), DateTime.Now);
                            Console.WriteLine("You have touched the file");
                        }

                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("What is the index of the file you want to remove?");
                        int removeUserInput = int.Parse(Console.ReadLine());
                        References.RemoveAt(removeUserInput);
                        break;
                    case 6:

                        break;
                    case 7:

                        break;

                }
            }
        }

        private static T[] PrintLibrary<T> (List<T> References) where T : Media<T>
        {
            T[] fileArray = new T[References.Count];
            int counter = 1;
            if (References.Any())
            {
                foreach (T file in References)
                {
                    fileArray[counter] = file;
                    Console.WriteLine("|{0}| {1} \n\t |{2}|{3}| \n", counter, file.File.Name, file.FileType.ToString(), file.DateAdded.ToString());
                    counter++;
                }
                
            }
            else
            {
                Console.WriteLine("Library is empty");
            }
            return fileArray;
        }
        
        private static void CreateAudioReferences(List<string> references, Array audioEnums, ref List<Audio> AudioReferences)
        {
            foreach (string reference in references)
            {
                string refExtension = reference.Substring(reference.Length - 3);
                FileInfo refFileInfo = new FileInfo(reference);
                foreach (Audio.FileTypes fileType in audioEnums)
                {
                    if (refExtension.ToLower() == fileType.ToString().ToLower())
                    {
                        AudioReferences.Add(new Audio(reference, refFileInfo, (FileType)Enum.Parse(typeof(FileType), fileType.ToString(), true), MediaType.Audio, refFileInfo.LastAccessTime));
                    }

                }

            }
        }
        private static void CreateVideoReferences(List<string> references, Array videoEnums, ref List<Video> VideoReferences)
        {
            foreach (string reference in references)
            {
                string refExtension = reference.Substring(reference.Length - 3);
                FileInfo refFileInfo = new FileInfo(reference);
                foreach (Video.FileTypes fileType in videoEnums)
                {
                    if (refExtension.ToLower() == fileType.ToString().ToLower())
                    {
                        VideoReferences.Add(new Video(reference, refFileInfo, (FileType)Enum.Parse(typeof(FileType), fileType.ToString(), true), MediaType.Video, refFileInfo.LastAccessTime));
                    }

                }
                

            }
        }
        private static void CreateImageReferences(List<string> references, Array imageEnums, ref List<Image> ImageReferences)
        {
            foreach (string reference in references)
            {
                string refExtension = reference.Substring(reference.Length - 3);
                FileInfo refFileInfo = new FileInfo(reference);
                foreach (Image.FileTypes fileType in imageEnums)
                {
                    if (refExtension.ToLower() == fileType.ToString().ToLower())
                    {
                        ImageReferences.Add(new Image(reference, refFileInfo, (FileType)Enum.Parse(typeof(FileType), fileType.ToString(), true), MediaType.Image, refFileInfo.LastAccessTime));
                    }

                }

            }
        }


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

        private static void PrintLibraryMenu()
        {
            string dashes = "-------------------------------------";
            Console.WriteLine(dashes + dashes);
            Console.WriteLine("1. Sort by name. \n" +
                "2. Sort by file extension. \n" +
                "3. Sort by date last accessed.\n" +
                "4. Touch file.\n" +
                "5. Remove file.\n" +
                "6. Use file.\n" +
                "7. Back to main menu.");
            Console.WriteLine(dashes + dashes);
        }


        private static void PrintMenu()
        {
            string dashes = "-------------------------------------";
            Console.WriteLine(dashes + dashes);
            Console.WriteLine("1. Scan for videos (MP4, AVI). \n" +
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
        public enum FileTypes{ MP4, AVI };
        
        
        public Video(string Path, FileInfo File, FileType FileType, MediaType MediaType, DateTime DateAdded) : 
            base (Path, File, FileType, MediaType, DateAdded)
        {
            
        }
    }

    public class Audio : Media<Audio>
    {
        public enum FileTypes { MP3, WAV };
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
