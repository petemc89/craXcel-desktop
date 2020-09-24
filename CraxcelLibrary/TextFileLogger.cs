using CraxcelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace CraxcelLibrary
{
    /// <summary>
    /// Basic logger, writing lines to a list of strings and then outputting that list to a text file.
    /// </summary>
    public class TextFileLogger : ILogger
    {
        public List<string> Log { get; } = new List<string>();

        public FileInfo LogFile { get; }

        public TextFileLogger()
        {
            var dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"log_{dateTime}.txt";

            var logPath = Path.Combine(ApplicationSettings.LOG_DIR.FullName, fileName);

            LogFile = new FileInfo(logPath);
        }

        /// <summary>
        /// Adds the string to the log collection.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Add(string logMessage)
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            string fullLogMessage = $"[{dateTime}] {logMessage}";

            Log.Add(fullLogMessage);
        }

        /// <summary>
        /// Saves the log collection.
        /// </summary>
        public void Save()
        {
            TextWriter tw = new StreamWriter(LogFile.FullName);

            foreach (var item in Log)
            {
                tw.WriteLine(item);
            }

            tw.Close();
        }
    }
}
