namespace FormatConverter
{
    public interface IFileUtils
    {
        string ReadFile(string sourceFileName);
        void WriteFile(string targetFileName, string serializedDoc);
    }
}