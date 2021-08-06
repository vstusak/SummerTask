namespace SummerTask.Parsers
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