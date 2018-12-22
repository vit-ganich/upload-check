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
            var folder = $"{ConfigReader.ResultsFolder}\\Chrome\\";
            var ext = $"*{ConfigReader.FilesExtension}";
            return GetResultsList(folder, ext);
        }

        public static List<string> IEResults()
        {
            var folder = $"{ConfigReader.ResultsFolder}\\IE\\";
            var ext = $"*{ConfigReader.FilesExtension}";
            return GetResultsList(folder, ext);
        }

        public static List<string> Screenshots()
        {
            var folder = $"{ConfigReader.ResultsFolder}";
            var ext = $"*{ConfigReader.ScreenshotsExtension}";
            return GetResultsList(folder, ext);
        }
    }
}
