using System.Configuration;

namespace UploadCheck
{
    class ConfigReader
    {
        public static string FeaturesList
        {
            get { return ConfigurationManager.AppSettings["FeaturesListPath"]; }
        }
        public static string ResultsFolder
        {
            get { return ConfigurationManager.AppSettings["ResultsFolder"];}
        }
        public static string FilesExtension
        {
            get { return ConfigurationManager.AppSettings["FilesExtension"]; }
        }
        public static string ScreenshotsExtension
        {
            get { return ConfigurationManager.AppSettings["ScreenshotsExtension"]; }
        }
    }
}
