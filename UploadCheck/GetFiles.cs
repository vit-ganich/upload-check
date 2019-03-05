using System;
using System.Collections.Generic;
using System.IO;

namespace UploadCheck
{
    class GetFiles
    {
        public static List<string> GetResultsList(string folder, string extension)
        {
            var filesInFolder = new List<string>();

            filesInFolder.AddRange(Directory.GetFiles(folder, extension));

            if (filesInFolder.Count == 0)
            {
                Console.WriteLine($"Folder {folder} is empty.");
            }
            return filesInFolder;
        }

        public static List<string> ChromeResults()
        {
            var folder = ConfigReader.ChromeResultsPath;
            var ext = $"*{ConfigReader.FilesExtension}";
            return GetResultsList(folder, ext);
        }

        public static List<string> IEResults()
        {
            var folder = ConfigReader.IEResultsPath;
            var ext = $"*{ConfigReader.FilesExtension}";
            return GetResultsList(folder, ext);
        }

        public static List<string> Screenshots()
        {
            var folder = ConfigReader.ScreenShotsPath;
            var ext = $"*{ConfigReader.ScreenShotsExtension}";
            return GetResultsList(folder, ext);
        }
    }
}
