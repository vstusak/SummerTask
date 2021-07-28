namespace SummerTask
{
    public interface IParsingStrategy
    {
        Document Parse(string input);
    }
}