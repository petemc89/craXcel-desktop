using craXcel.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CraxcelLibrary.Enums;
using static System.Environment;

namespace CraxcelLibrary
{
    public static class ApplicationSettings
    {
        /// <summary>
        /// The application name.
        /// </summary>
        public static readonly string APP_NAME = "craXcel";

        /// <summary>
        /// The directory where unlocked files and logs are saved to.
        /// </summary>
        public static DirectoryInfo CRAXCEL_DIR { get { return GetCraxcelDir(); } }

        public static DirectoryInfo LOG_DIR { get { return GetLogDir(); } }

        /// <summary>
        /// The directory where file operations are performed.
        /// </summary>
        public static DirectoryInfo TEMP_DIR { get { return GetTempDir(); } }

        /// <summary>
        /// The applications, defined by their file extensions, supported by craXcel.
        /// </summary>
        public static Dictionary<string, SupportedApplication> SUPPORTED_APPLICATIONS { get; } = new Dictionary<string, SupportedApplication>()
        {
            { ".docm", SupportedApplication.MicrosoftWord },
            { ".docx", SupportedApplication.MicrosoftWord },
            { ".pptm", SupportedApplication.MicrosoftPowerpoint },
            { ".pptx", SupportedApplication.MicrosoftPowerpoint },
            { ".xlsm", SupportedApplication.MicrosoftExcel },
            { ".xlsx", SupportedApplication.MicrosoftExcel },
        };

        /// <summary>
        /// Gets the users personal directory where the application will save unlocked files and logs to, creating it if neccessary.
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo GetCraxcelDir()
        {
            string userPersonalFolder = GetFolderPath(SpecialFolder.Personal);

            string craxcelFolder = Path.Combine(userPersonalFolder, APP_NAME);

            var dir = new DirectoryInfo(craxcelFolder);

            FileUtilities.CreateDirectoryIfNotExists(dir);

            return dir;
        }

        /// <summary>
        /// Gets the temporary directory where the application will perform it's processing. 
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo GetTempDir()
        {
            string userTempFolder = Path.GetTempPath();

            string craxcelTempFolder = Path.Combine(userTempFolder, APP_NAME);

            var dir = new DirectoryInfo(craxcelTempFolder);

            FileUtilities.CreateDirectoryIfNotExists(dir);

            return dir;
        }

        /// <summary>
        /// Gets the directory where user logs will be saved.
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo GetLogDir()
        {
            var logPath = Path.Combine(CRAXCEL_DIR.FullName, "Logs");

            var dir = new DirectoryInfo(logPath);

            FileUtilities.CreateDirectoryIfNotExists(dir);

            return dir;
        }
    }

}
