namespace SummerTask
{
    public interface IFileWriter
    {
        void Write(string targetFileName, string serializedDoc);
    }
}