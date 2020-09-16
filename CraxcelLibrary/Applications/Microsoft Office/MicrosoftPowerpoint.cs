using System.Collections.Generic;
using System.IO;

namespace craXcel
{
    public class MicrosoftPowerpoint : MicrosoftOffice
    {
        internal override string XML_BASE_DIR => "ppt";
        private string PRESENTATION_XML_FILEPATH => Path.Combine(XML_BASE_DIR, "presentation.xml");
        private List<string> PresentationTagNames { get; }

        public MicrosoftPowerpoint(string filepath) : base(filepath) 
        {
            PresentationTagNames = new List<string>()
            {
                "p:modifyVerifier"
            };
        }

        internal override void RemoveApplicationSpecificProtection()
        {
            RemovePresentationProtection();
        }

        private void RemovePresentationProtection()
        {
            var xmlFilePath = Path.Combine(TempDirectory.FullName, PRESENTATION_XML_FILEPATH);

            RemoveXMLElementsByTagNames(xmlFilePath, PresentationTagNames);
        }

    }
}
