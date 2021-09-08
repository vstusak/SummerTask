using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatConverter.Parsers
{
    public class HtmlParsingStrategy : IParsingStrategy
    {
        private const string TitleTag = "Title";
        private const string TextTag = "Body";

        public string Serialize(Document document)
        {
            throw new NotImplementedException();
        }

        public Document Parse(string input)
        {
                var documentTitle = GetTextInTag(TitleTag, input);
                var documentText = GetTextInTag(TextTag, input);

                return new Document {Title = documentTitle, Text = documentText};
        }

        public string Format => "html";

        private string GetTextInTag(string tag, string text)
        {
            var startTag = $"<{tag}​​​>";
            var endTag = $"</{tag}​​​>";

            var startIndex = text.IndexOf(startTag, StringComparison.InvariantCultureIgnoreCase);
            var endIndex = text.LastIndexOf(endTag, StringComparison.InvariantCultureIgnoreCase);
            if (!AreIndexesValid(startIndex, endIndex)) throw new Exception("HtmlDocumentMisMatch");
            var length = endIndex - (startIndex + startTag.Length);
            return text.Substring(startIndex + startTag.Length, length);
        }

        private bool AreIndexesValid(int startIndex, int endIndex)
        {
            return startIndex != -1 && endIndex != -1 && startIndex < endIndex;
        }
        
    }
}
