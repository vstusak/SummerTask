using System;

namespace SummerTask.Parsers
{
    public class DefaultParsingStrategy : IParsingStrategy
    {
        public Document Parse(string input)
        {
            throw new Exception("Parsing strategy was not set before use");
        }
    }
}