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
            SetStrategy(new DefaultParsingStrategy());
        }

        public Parser(IParsingStrategy parsingStrategy)
        {
            SetStrategy(parsingStrategy);
        }

        public Document ParseDocument(string input)
        {
            return _parsingStrategy.Parse(input);
        }

        public void SetStrategy(IParsingStrategy strategy)
        {
            _parsingStrategy = strategy ?? new DefaultParsingStrategy();
        }
    }
}
