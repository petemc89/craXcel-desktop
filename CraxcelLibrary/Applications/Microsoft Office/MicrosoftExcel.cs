using System.Collections.Generic;
using System.IO;

namespace craXcel
{
    /// <summary>
    /// Class for unlocking a Microsoft Office Excel application.
    /// </summary>
    internal class MicrosoftExcel : MicrosoftOffice
    {
        internal override string XML_ROOT_DIR => "xl";
        private string WORKBOOK_XML_FILEPATH => Path.Combine(XML_ROOT_DIR, "workbook.xml");
        private string WORKSHEET_XML_DIR => Path.Combine(XML_ROOT_DIR, "worksheets");

        private List<string> WorkbookTagNames { get; }
        private List<string> WorksheetTagNames { get; }

        public MicrosoftExcel(string filepath) : base(filepath) 
        {
            WorkbookTagNames = new List<string>()
            {
                "fileSharing",
                "workbookProtection",
            };

            WorksheetTagNames = new List<string>()
            {
                "sheetProtection"
            };
        }

        internal override void RemoveApplicationSpecificProtection()
        {
            RemoveWorkbookProtection();

            RemoveWorksheetProtection();
        }

        private void RemoveWorkbookProtection()
        {
            var xmlFilePath = Path.Combine(TempProcessingDir.FullName, WORKBOOK_XML_FILEPATH);

            RemoveXMLElementsByTagNames(xmlFilePath, WorkbookTagNames);
        }

        private void RemoveWorksheetProtection()
        {
            var sheetDir = new DirectoryInfo(Path.Combine(TempProcessingDir.FullName, WORKSHEET_XML_DIR));

            foreach (var file in sheetDir.GetFiles())
            {
                var xmlFilePath = Path.Combine(TempProcessingDir.FullName, WORKSHEET_XML_DIR, file.Name);

                RemoveXMLElementsByTagNames(xmlFilePath, WorksheetTagNames);
            }
        }
    }
}
