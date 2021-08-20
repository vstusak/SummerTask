namespace SummerTask
{
    public interface IFileHelper
    {
        bool FileValidation(string fileName);
        FileType GetFileType(string sourceFileName);
        string OpenAsString(string fileName);
        void WriteFile(string targetFileName, string serializedDoc);
    }
}