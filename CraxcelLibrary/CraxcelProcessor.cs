using craXcel;
using System;
using System.IO;
using static CraxcelLibrary.Enums;

namespace CraxcelLibrary
{
    /// <summary>
    /// Main processing class of the application.
    /// </summary>
    public static class CraxcelProcessor
    {

        /// <summary>
        /// Unlocks the specified file within the option parameters set by the user.
        /// </summary>
        /// <param name="filePath">The filepath of the file to unlock.</param>
        /// <returns>Bool stating if the file was successfully unlocked.</returns>
        public static bool UnlockFile(string filePath, Logger logger)
        {
            try
            {
                var file = new FileInfo(filePath);

                SupportedApplication application = IdentifyApplication(file);

                ILockedFile lockedFile = CreateLockedFileInstance(file, application);

                lockedFile.Unlock();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static SupportedApplication IdentifyApplication(FileInfo file)
        {
            SupportedApplication application = SupportedApplication._unsupported;

            ApplicationSettings.SUPPORTED_APPLICATIONS.TryGetValue(file.Extension, out application);

            return application;
        }

        private static ILockedFile CreateLockedFileInstance(FileInfo file, SupportedApplication application)
        {
            switch (application)
            {
                case SupportedApplication.MicrosoftExcel:
                    return new MicrosoftExcel(file.FullName);
                case SupportedApplication.MicrosoftPowerpoint:
                    return new MicrosoftPowerpoint(file.FullName);
                case SupportedApplication.MicrosoftWord:
                    return new MicrosoftWord(file.FullName);
                default:
                    return null;
            }
        }
    }
}
