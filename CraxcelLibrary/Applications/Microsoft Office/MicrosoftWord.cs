using System.Collections.Generic;
using System.IO;

namespace craXcel
{
    public class MicrosoftWord : MicrosoftOffice
    {
        internal override string XML_BASE_DIR => "word";
        private string SETTINGS_XML_FILEPATH => Path.Combine(XML_BASE_DIR, "settings.xml");
        private List<string> SettingsTagNames { get; } 

        public MicrosoftWord(string filepath) : base(filepath) 
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
