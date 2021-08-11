using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatConverter.Parsers
{
    public class NullParsingStrategy : IParsingStrategy
    {
        public Document Parse(string input)
        {
            throw new Exception("Parsing strategy has not been set.");
        }

        public string Format => "default";
    }
}
