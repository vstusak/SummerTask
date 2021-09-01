namespace FormatConverter
{
    public interface IFileConverter
    {
        void Execute(string sourceFileName, string targetFileName);
    }
}