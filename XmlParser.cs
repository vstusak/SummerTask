using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SummerTask
{
    public class XmlParser
    {
        private const string Title = "title";
        private const string Text = "text";

        public Document Parse(string input)
        {
            var xmlDocument = XDocument.Parse(input); // validate file content before parsing it
            return new Document
            {
                Title = xmlDocument.Root.Element(Title).Value,
                Text = xmlDocument.Root.Element(Text).Value
            };
        }
    }
}
