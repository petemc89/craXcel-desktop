using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace craXcel
{
    class Word : OfficeApplication
    {
        internal override string XML_BASE_DIR => "word";
        private string SETTINGS_XML_FILEPATH => Path.Combine(XML_BASE_DIR, "settings.xml");
        private List<string> SettingsTagNames { get; } 

        public Word(string filepath) : base(filepath) 
        {
            SettingsTagNames = new List<string>()
            {
                "w:writeProtection",
                "w:documentProtection"
            };
        }

        internal override void RemoveApplicationSpecificProtection()
        {
            RemoveSettingsProtection();
        }

        private void RemoveSettingsProtection()
        {
            var xmlFilePath = Path.Combine(TempDirectory.FullName, SETTINGS_XML_FILEPATH);

            RemoveXMLElementsByTagNames(xmlFilePath, SettingsTagNames);
        }
    }
}
