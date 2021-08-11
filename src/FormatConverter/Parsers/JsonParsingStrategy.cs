using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatConverter.Parsers
{
    public class JsonParsingStrategy : IParsingStrategy
    {
        public string Serialize(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }

        public Document Parse(string input)
        {
            throw new NotImplementedException();
        }

        public string Format => "json";
    }
}
