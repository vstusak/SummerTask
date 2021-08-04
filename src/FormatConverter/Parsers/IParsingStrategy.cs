namespace FormatConverter.Parsers
{
    public interface IParsingStrategy
    {
        Document Parse(string input);
    }
}