using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SummerTask
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize(Document document)
        {
            var xmlDocument = new XDocument(
                new XElement("Root", 
                    new XElement("Title", document.Title), 
                    new XElement("Text", document.Text)
                )
            );
            
            return xmlDocument.ToString();
        }
    }
}
