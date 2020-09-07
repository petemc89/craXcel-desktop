using craXcel.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Remoting;

namespace craXcel
{
    class Excel : OfficeApplication
    {
        internal override string XML_BASE_DIR => "xl";
        private string WORKBOOK_XML_FILEPATH => Path.Combine(XML_BASE_DIR, "workbook.xml");
        private string WORKSHEET_XML_DIR => Path.Combine(XML_BASE_DIR, "worksheets");

        private List<string> WorkbookTagNames { get; }
        private List<string> WorksheetTagNames { get; }

        public Excel(string filepath) : base(filepath) 
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
            var xmlFilePath = Path.Combine(TempDirectory.FullName, WORKBOOK_XML_FILEPATH);

            RemoveXMLElementsByTagNames(xmlFilePath, WorkbookTagNames);
        }

        private void RemoveWorksheetProtection()
        {
            var sheetDir = new DirectoryInfo(Path.Combine(TempDirectory.FullName, WORKSHEET_XML_DIR));

            foreach (var file in sheetDir.GetFiles())
            {
                var xmlFilePath = Path.Combine(TempDirectory.FullName, WORKSHEET_XML_DIR, file.Name);

                RemoveXMLElementsByTagNames(xmlFilePath, WorksheetTagNames);
            }
        }
    }
}
