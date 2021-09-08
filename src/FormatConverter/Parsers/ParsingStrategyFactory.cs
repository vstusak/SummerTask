﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FormatConverter.Parsers
{
    public class ParsingStrategyFactory : IParsingStrategyFactory
    {
        private readonly IList<IParsingStrategy> _parsingStrategies;

        public ParsingStrategyFactory(IList<IParsingStrategy> parsingStrategies)
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