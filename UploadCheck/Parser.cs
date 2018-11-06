using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UploadCheck
{
    class Parser
    {
        /// <summary>
        /// Method extracts feature name from the full path.
        /// Example: "..\\....\\..\\1.16-Feature_03_Oracle_Chrome_B7.7.100.1-9-8-0-0.trx" = "1.16-Feature_03"
        /// </summary>
        /// <param name="rawFileName"></param>
        /// <returns></returns>
        public static List<string> GetExtractedFeatureNames(List<string> rawFilesList)
        {
            var parsedFileNames = new List<string>();

            foreach (var fullPath in rawFilesList)
            {
                var rawFileName = GetFileNameFromFullPath(fullPath);
                // Remove the unnecessary ending
                var pattern = RegExExclude(rawFileName);
                var temp = rawFileName.Replace(pattern, "");
                temp = ReplaceSpaceWithDash(temp);

                parsedFileNames.Add(temp);
            }
            return parsedFileNames;
        }

        public static List<string> GetExtractedScreenshots(List<string> rawScreensList)
        {
            var parsedFileNames = new List<string>();

            foreach (var fullPath in rawScreensList)
            {
                var rawFileName = GetFileNameFromFullPath(fullPath);
                // Remove the unnecessary parts of the file name
                var temp = rawFileName.Replace(ConfigReader.ScreenshotsExtension, "");
                temp = temp.Replace(".feature", "");
                temp = ReplaceSpaceWithDash(temp);

                parsedFileNames.Add(temp);
            }
            return parsedFileNames;
        }

        public static string GetFileNameFromFullPath(string fullPath)
        {
            var splittedPath = fullPath.Split('\\');
            var len = splittedPath.Length;
            // Get the last item of splitted full path (file name)
            return splittedPath[len - 1];
        }

        /// <summary>
        /// Method extracts unnecessary part of feature name.
        /// Example: "1.16-Feature_03_Oracle_Chrome_B7.7.100.1-9-8-0-0.trx" = "_Oracle_Chrome_B7.7.100.1-9-8-0-0.trx"
        /// </summary>
        /// <param name="rawFileName"></param>
        /// <returns></returns>
        public static string RegExExclude(string rawFileName)
        {
            var pattern = @"_oracle_(Chrome|(IE\d\d*))_B\d\d*.\d\d*.\d\d*.\d\d*((\d\d*(.+?))|(\d\d*-\d\d*-0-\d\d*)).trx";
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = rx.Match(rawFileName);
            return match.ToString();
        }

        /// <summary>
        /// Method extracts the number of feature. Example: from "1.16-Feature_03" returns "1.16"
        /// </summary>
        /// <param name="rawFileName"></param>
        /// <returns></returns>
        public static string RegExDashExclude(string rawFileName)
        {
            Regex rx = new Regex(@"^\d\d*.\d\d\d*");
            Match match = rx.Match(rawFileName);
            return match.ToString();
        }

        /// <summary>
        /// Method replaces space with dash after the feature number
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static string ReplaceSpaceWithDash(string temp)
        {
            var pattern = RegExDashExclude(temp);
            temp = temp.Replace(pattern + " ", pattern + "-");
            return temp.Replace("_", " ");
        }
    }
}
