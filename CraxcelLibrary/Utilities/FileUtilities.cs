using System.IO;

namespace craXcel.Utilities
{
    public static class FileUtilities
    {
        /// <summary>
        /// Takes a path, checks whether it exists, and if it does appends a number and runs the check again. 
        /// Repeats until a unique name is found.
        /// </summary>
        /// <param name="path">The base path being checked for uniqueness.</param>
        /// <returns></returns>
        public static string GetUniqueFileName(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                    return path;

                path = Path.Combine(dir, fileName + " (" + i + ")" + fileExt);
            }
        }

        public static void CreateDirectoryIfNotExists(DirectoryInfo directory)
        {
            var exists = directory.Exists;

            if (exists == false)
            {
                directory.Create();
            }
        }
    }
}
