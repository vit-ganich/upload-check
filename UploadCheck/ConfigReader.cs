using System.Configuration;

namespace UploadCheck
{
    class ConfigReader
    {
        public static string FeaturesList
        {
            get { return ConfigurationManager.AppSettings["FeaturesListPath"]; }
        }
        //public static string ResultsFolder
        //{
        //    get { return ConfigurationManager.AppSettings["ResultsFolder"];}
        //}
        public static string ChromeResultsPath
        {
            get { return ConfigurationManager.AppSettings["ChromeResultsPath"]; }
        }
        public static string IEResultsPath
        {
            get { return ConfigurationManager.AppSettings["IEResultsPath"]; }
        }
        public static string ScreenShotsPath
        {
            get { return ConfigurationManager.AppSettings["ScreenShotsPath"]; }
        }
        public static string FilesExtension
        {
            get { return ConfigurationManager.AppSettings["FilesExtension"]; }
        }
        public static string ScreenShotsExtension
        {
            get { return ConfigurationManager.AppSettings["ScreenShotsExtension"]; }
        }
    }
}
