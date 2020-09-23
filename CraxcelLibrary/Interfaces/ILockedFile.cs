using System.IO;

namespace craXcel
{
    /// <summary>
    /// LockedFile Interface that should be implemented by all application specific classes.
    /// </summary>
    public interface ILockedFile
    {
        /// <summary>
        /// The file to be unlocked.
        /// </summary>
        public FileInfo LockedFile { get; }

        /// <summary>
        /// Unlocks the specified file, saving a copy to a folder defined by the application's settings.
        /// </summary>
        public void Unlock();
    }
}
