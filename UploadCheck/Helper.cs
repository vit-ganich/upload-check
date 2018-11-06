using System;
using System.Collections.Generic;
using System.IO;

namespace UploadCheck
{
    class Helper
    {
        public static string[] GetFeaturesList()
        {
            var pathToFeaturesList = ConfigReader.FeaturesList;
            var content = File.ReadAllText(pathToFeaturesList).Split('\n');
            return content;
        }

        public static void PrintResults(List<string> results)
        {
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintInfo()
        {
            Console.WriteLine("Go to the .config file to change the app settings.\n");
            Console.WriteLine($"Folder: {ConfigReader.ResultsFolder}");
        }
    }
}
