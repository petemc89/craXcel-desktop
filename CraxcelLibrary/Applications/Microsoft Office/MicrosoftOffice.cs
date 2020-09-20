using craXcel.Utilities;
using CraxcelLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace craXcel
{
    /// <summary>
    /// Base class for Microsoft Office applications.
    /// </summary>
    public abstract class MicrosoftOffice : ILockedFile
    {
        /// <summary>
        /// The file specific by the user that requires unlocking.
        /// </summary>
        public FileInfo LockedFile { get; }

        /// <summary>
        /// The temporary directory where craXcel performs operations on the locked file to unlock it.
        /// </summary>
        internal DirectoryInfo TempProcessingDir { get; }

        /// <summary>
        /// The filename for VBA project binary files, which is consistent across all MicrosoftOffice applications.
        /// </summary>
        private const string VBA_FILENAME = "vbaProject.bin";

        /// <summary>
        /// The root directory of a MicrosoftOffice application's XML file structure, which differs with each application.
        /// </summary>
        internal abstract string XML_ROOT_DIR { get; }

        public MicrosoftOffice(string filepath)
        {            
            LockedFile = new FileInfo(filepath);

            var tempProcessingDir = Path.Combine(ApplicationSettings.TEMP_DIR.FullName, "{" + Guid.NewGuid() + "}");
            TempProcessingDir = new DirectoryInfo(tempProcessingDir);
        }

        public void Unlock()
        {
            Decompile();
            RemoveApplicationSpecificProtection();

            if (UserOptions.UnlockVBA)
            {
                RemoveVBAProtection();
            }

            Recompile();
            Clean();
        }

        /// <summary>
        /// Decompiles the locked file into the temporary directory.
        /// </summary>
        private void Decompile()
        {
            ZipFile.ExtractToDirectory(LockedFile.FullName, TempProcessingDir.FullName);
        }

        /// <summary>
        /// Recompiles all the files from the temporary directory and saves the resulting file to the original file location.
        /// </summary>
        private void Recompile()
        {
            var newFileName = LockedFile.Name.Replace(LockedFile.Extension, $"_{ApplicationSettings.APP_NAME}{LockedFile.Extension}");

            var fullUnlockedFilePath = Path.Combine(ApplicationSettings.CRAXCEL_DIR.FullName, newFileName);

            var uniqueUnlockedFilePath = FileUtilities.GetUniqueFileName(fullUnlockedFilePath);

            ZipFile.CreateFromDirectory(TempProcessingDir.FullName, uniqueUnlockedFilePath);
        }

        /// <summary>
        /// Deletes the temporary directory and all its contents.
        /// </summary>
        private void Clean()
        {
            Directory.Delete(TempProcessingDir.FullName, true);
        }

        /// <summary>
        /// Loads an XML file and removes each of the elements that corresponds to the tag names.
        /// Saves over the original file upon completion.
        /// </summary>
        /// <param name="xmlFilePath">The file path of the target XML file.</param>
        /// <param name="tagNames">The list of tag names that identify the elements to remove.</param>
        internal void RemoveXMLElementsByTagNames(string xmlFilePath, List<string> tagNames)
        {
            var fileExists = File.Exists(xmlFilePath);

            if (fileExists)
            {
                var doc = new XmlDocument();
                doc.Load(xmlFilePath);

                foreach (var tagName in tagNames)
                {
                    var nodesToRemove = new List<XmlNode>();

                    foreach (XmlNode element in doc.GetElementsByTagName(tagName))
                    {
                        nodesToRemove.Add(element);
                    }

                    foreach (XmlNode element in nodesToRemove)
                    {
                        XmlNode parentNode = element.ParentNode;
                        parentNode.RemoveChild(element);
                    }
                }

                doc.Save(xmlFilePath);
            }
        }

        /// <summary>
        /// Removes VBA Project password protection by modifying the underlying binary file.
        /// </summary>
        private void RemoveVBAProtection()
        {
            // TO-DO: Currently this states the workbook is corrupt and requires some manual steps on the users part to finish the successful unlocking, fix this.

            var filePath = Path.Combine(TempProcessingDir.FullName, XML_ROOT_DIR, VBA_FILENAME);

            var fileExists = File.Exists(filePath);

            if (fileExists)
            {
                byte[] bytes = File.ReadAllBytes(filePath);

                string hexStr = BitConverter.ToString(bytes);

                //Replaces the protection string "DPB" (44-50-42 in the hex string) with a no-protection string "DPx" (hex 44-50-78)
                string unprotectedHexStr = hexStr.Replace("44-50-42", "44-50-78");

                byte[] unprotectedBytes = ConvertStringToBytes(unprotectedHexStr);

                File.WriteAllBytes(filePath, unprotectedBytes);
            }

            byte[] ConvertStringToBytes(string stringToConvert)
            {
                var stringArray = stringToConvert.Split('-');

                byte[] byteArray = new byte[stringArray.Length];

                for (int i = 0; i < stringArray.Length; i++)
                {
                    byteArray[i] = Convert.ToByte(stringArray[i], 16);
                }

                return byteArray;
            }
        }

        /// <summary>
        /// Abstract method that should contain the application specific logic for removing the protection of the file.
        /// </summary>
        internal abstract void RemoveApplicationSpecificProtection();
    }
}
