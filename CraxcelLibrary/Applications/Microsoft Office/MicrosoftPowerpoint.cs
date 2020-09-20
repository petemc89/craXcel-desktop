using System.Collections.Generic;
using System.IO;

namespace craXcel
{
    /// <summary>
    /// Class for unlocking a Microsoft Office Powerpoint application.
    /// </summary>
    public class MicrosoftPowerpoint : MicrosoftOffice
    {
        internal override string XML_ROOT_DIR => "ppt";
        private string PRESENTATION_XML_FILEPATH => Path.Combine(XML_ROOT_DIR, "presentation.xml");
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
            var xmlFilePath = Path.Combine(TempProcessingDir.FullName, PRESENTATION_XML_FILEPATH);

            RemoveXMLElementsByTagNames(xmlFilePath, PresentationTagNames);
        }

    }
}
