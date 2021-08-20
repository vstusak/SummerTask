namespace FormatConverter.Parsers
{
    public interface IParsingStrategyFactory
    {
        IParsingStrategy GetParsingStrategy(string sourceFileName);
    }
}