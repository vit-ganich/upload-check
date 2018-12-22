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
            Console.WriteLine("\n\n-------------- Missed screenshots ------------\n");
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

        public static void UpdateConsole()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("Press ENTER to update information...");
            Console.ReadLine();
            Console.Clear();
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Updated: {0}", DateTime.Now.TimeOfDay);
            Console.WriteLine("------------------------------------\n");
        }
    }
}
