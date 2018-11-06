using System;
using System.Collections.Generic;

namespace UploadCheck
{
    class Verifier
    {
        public static List<string> CheckResults(List<string> filesList)
        {
            var missingFiles = new List<string>();

            var mustToHaveFiles = Helper.GetFeaturesList();

            var existingFiles = filesList;

            foreach (var file in mustToHaveFiles)
            {
                // to remove '\r' and replace dash with space
                var trimFile = file.Trim().Replace("_", " "); 
                if (!existingFiles.Contains(trimFile))
                {
                    missingFiles.Add(trimFile);
                }
            }
            return missingFiles;
        }

        public static void SortResults(List<string> missedChrome, List<string> missedIE)
        {
            
            foreach (var file in missedChrome)
            {
                if (missedIE.Contains(file))
                {
                    Console.WriteLine("|Chrome| IE | " + file);
                }
                else
                {
                    Console.WriteLine("|Chrome| -- | " + file);
                }
            }
            foreach (var file in missedIE)
            {
                if (!missedChrome.Contains(file))
                {
                    Console.WriteLine("|  --  | IE | " + file);
                }
            }
        }
    }
}
