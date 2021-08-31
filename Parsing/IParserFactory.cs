namespace SummerTask
{
    public interface IParserFactory
    {
        IParser LoadParser(string sourceFileName);
    }
}