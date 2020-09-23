using System;
using System.Collections.Generic;
using System.Text;

namespace CraxcelLibrary.Interfaces
{
    /// <summary>
    /// Logger interface, to allow expansion into using different types of logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// A collection of all the log messages added so far.
        /// </summary>
        public List<string> Log { get; }

        /// <summary>
        /// Add a new log message to the log.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Add(string logMessage);

        /// <summary>
        /// Saves the collection of log messages.
        /// </summary>
        public void Save();
    }
}
