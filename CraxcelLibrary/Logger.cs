using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CraxcelLibrary
{
    /// <summary>
    /// Basic logger, writing lines to a list of strings and then outputting that list to a text file.
    /// </summary>
    public class Logger
    {
        public List<string> Log { get; } = new List<string>();

        private FileInfo LogFile { get; }

        public Logger()
        {
            var dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"log_{dateTime}.txt";

            var logPath = Path.Combine(ApplicationSettings.LOG_DIR.FullName, fileName);

            LogFile = new FileInfo(logPath);
        }

        public void Add(string logMessage)
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            string fullLogMessage = $"[{dateTime}] {logMessage}";

            Log.Add(fullLogMessage);
        }

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
