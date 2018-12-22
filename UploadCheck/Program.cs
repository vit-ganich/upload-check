using System;

namespace UploadCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Press ENTER to update information...");
                Console.WriteLine("------------------------------------\n");
                while (true)
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

                    Verifier.SortResults(missedChrome, missedIE);

                    Helper.PrintResults(missedScreenshots);

                    Helper.UpdateConsole();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
