using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SummerTask.Parsers
{
    public class JsonParsingStrategy : IParsingStrategy
    {
        public Document Parse(string input)
        {
            return JsonConvert.DeserializeObject<Document>(input);
        }
    }
}
