using craXcel;
using CraxcelLibrary.Interfaces;
using System.Collections.Generic;
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
        /// Main entry point from the UI.
        /// </summary>
        /// <param name="filePaths">The file paths of those files being unlocked.</param>
        /// <returns>The number of successfully unlocked files.</returns>
        public static int UnlockFiles(List<string> filePaths, ILogger logger = null)
        {
            if (logger == null)
            {
                logger = new TextFileLogger();
            }

            logger.Add($"craXcel started");
            logger.Add($"{filePaths.Count} files selected");

            int filesUnlocked = 0;

            foreach (var filePath in filePaths)
            {
                var file = new FileInfo(filePath);

                try
                {
                    SupportedApplication application = IdentifyApplication(file);

                    ILockedFile lockedFile = CreateLockedFileInstance(file, application);

                    lockedFile.Unlock();

                    filesUnlocked++;

                    logger.Add($"Successfully unlocked: {file.Name} ({file.FullName})");
                }
                catch
                {
                    logger.Add($"Failed to unlock: {file.Name} ({file.FullName})");
                }
            }

            logger.Add($"{filesUnlocked}/{filePaths.Count} files unlocked");
            logger.Add("craXcel finished");

            logger.Save();

            return filesUnlocked;
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
