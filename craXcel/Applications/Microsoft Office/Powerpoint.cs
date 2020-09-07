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
    public class Powerpoint : OfficeApplication
    {
        internal override string XML_BASE_DIR => "ppt";
        private string PRESENTATION_XML_FILEPATH => Path.Combine(XML_BASE_DIR, "presentation.xml");
        private List<string> PresentationTagNames { get; }

        public Powerpoint(string filepath) : base(filepath) 
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
