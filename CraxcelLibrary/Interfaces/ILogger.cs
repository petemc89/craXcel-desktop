using System;
using System.Collections.Generic;
using System.Text;

namespace CraxcelLibrary.Interfaces
{
    public interface ILogger
    {
        public List<string> Log { get; }

        public void Add(string logMessage);

        public void Save();
    }
}
