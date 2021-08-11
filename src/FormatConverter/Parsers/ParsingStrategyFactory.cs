using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FormatConverter.Parsers
{
    public class ParsingStrategyFactory
    {
        private readonly IEnumerable<IParsingStrategy> _parsingStrategies;

        public ParsingStrategyFactory(IEnumerable<IParsingStrategy> parsingStrategies)
        {
            _parsingStrategies = parsingStrategies;
        }
        public IParsingStrategy GetParsingStrategy(string sourceFileName)
        {
            var extension = new FileInfo(sourceFileName).Extension.Trim('.');
            return _parsingStrategies.FirstOrDefault(ps =>
                       string.Compare(ps.Format, extension, StringComparison.InvariantCultureIgnoreCase) == 0) ??
                   new NullParsingStrategy();
        }
    }
}