using System.Collections.Generic;
using System.IO;

namespace craXcel
{
    /// <summary>
    /// Class for unlocking a Microsoft Office Word application.
    /// </summary>
    public class MicrosoftWord : MicrosoftOffice
    {
        internal override string XML_ROOT_DIR => "word";
        private string SETTINGS_XML_FILEPATH => Path.Combine(XML_ROOT_DIR, "settings.xml");
        private List<string> SettingsTagNames { get; } 

        public MicrosoftWord(string filepath) : base(filepath) 
        {
            SettingsTagNames = new List<string>()
            {
                "writeProtection",
                "documentProtection",
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
            var xmlFilePath = Path.Combine(TempProcessingDir.FullName, SETTINGS_XML_FILEPATH);

            RemoveXMLElementsByTagNames(xmlFilePath, SettingsTagNames);
        }
    }
}
