using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class Parser : IParser
    {
        private IParsingStrategy _parsingStrategy;

        public Parser()
        {
            SetParsingStrategy(new NullParsingStrategy());
        }

        public Parser(IParsingStrategy parsingStrategy)
        {
            SetParsingStrategy(parsingStrategy);
        }

        public Document Parse(string input)
        {
            return _parsingStrategy.Parse(input);
        }

        public void SetParsingStrategy(IParsingStrategy parsingStrategy)
        {
            _parsingStrategy = parsingStrategy;
        }
    }
}
