using System;

namespace UploadCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var filesChrome = GetFiles.ChromeResults();
                var filesIE = GetFiles.IEResults();
                var filesScreenshots = GetFiles.Screenshots();

                var parsedFilesChrome = Parser.GetExtractedFeatureNames(filesChrome);
                var parsedFilesIE = Parser.GetExtractedFeatureNames(filesIE);
                var parsedFilesScreenshots = Parser.GetExtractedScreenshots(filesScreenshots);

                var missedChrome = Verifier.CheckResults(parsedFilesChrome);
                var missedIE = Verifier.CheckResults(parsedFilesIE);
                var missedScreenshots = Verifier.CheckResults(parsedFilesScreenshots);

                Helper.PrintInfo();

                Console.WriteLine("\n-------------- Missed files ------------------\n");
                Verifier.SortResults(missedChrome, missedIE);

                Console.WriteLine("\n\n-------------- Missed screenshots ------------\n");
                Helper.PrintResults(missedScreenshots);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
