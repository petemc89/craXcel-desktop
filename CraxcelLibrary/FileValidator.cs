using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using static CraxcelLibrary.Enums;

namespace CraxcelLibrary.Applications
{
    public class FileValidator
    {
        private List<string> MICROSOFT_EXCEL_EXTENSIONS { get; } = new List<string>()
        {
            ".xlsm",
            ".xlsx"
        };

        private List<string> MICROSOFT_POWERPOINT_EXTENSIONS { get; } = new List<string>()
        {
            ".pptm",
            ".pptx"
        };

        private List<string> MICROSOFT_WORD_EXTENSIONS { get; } = new List<string>()
        {
            ".docm",
            ".docx"
        };

        public FileInfo File { get; set; }

        public FileValidator(string filePath)
        {
            File = new FileInfo(filePath);
        }

        public SupportedApplication IdentifyApplication()
        {
            // TODO - This feels a bit hacky. Research other ways of achieving identifying applications associated to files.

            if (MICROSOFT_EXCEL_EXTENSIONS.Contains(File.Extension))
            {
                return SupportedApplication.MicrosoftExcel;
            }

            else if (MICROSOFT_POWERPOINT_EXTENSIONS.Contains(File.Extension))
            {
                return SupportedApplication.MicrosoftPowerpoint;
            }

            else if (MICROSOFT_WORD_EXTENSIONS.Contains(File.Extension))
            {
                return SupportedApplication.MicrosoftWord;
            }

            else
            {
                return SupportedApplication._unsupported;
            }            
        }
    }
}
