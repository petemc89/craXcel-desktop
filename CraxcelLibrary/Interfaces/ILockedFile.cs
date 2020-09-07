using System.IO;

namespace craXcel
{
    public interface ILockedFile
    {
        public FileInfo LockedFile { get; }

        /// <summary>
        /// Unlocks the specified file, saving a copy to the original directory with a "craXcel" suffix.
        /// </summary>
        public void Unlock();
    }
}
