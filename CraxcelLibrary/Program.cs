using craXcel;
using CraxcelLibrary.Applications;
using System;
using System.Collections.Generic;
using System.Text;
using static CraxcelLibrary.Enums;

namespace CraxcelLibrary
{
    public static class Program
    {
        public static bool Main(string filePath, string outputFolder)
        {
            try
            {
                ILockedFile lockedFile;

                var fileValidator = new FileValidator(filePath);

                switch (fileValidator.IdentifyApplication())
                {
                    case SupportedApplication.MicrosoftExcel:
                        lockedFile = new Excel(fileValidator.File.FullName);
                        break;
                    case SupportedApplication.MicrosoftPowerpoint:
                        lockedFile = new Powerpoint(fileValidator.File.FullName);
                        break;
                    case SupportedApplication.MicrosoftWord:
                        lockedFile = new Word(fileValidator.File.FullName);
                        break;
                    default:
                        return false;
                }

                lockedFile.Unlock();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
