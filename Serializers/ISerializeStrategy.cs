namespace SummerTask.Serializers
{
    public interface ISerializeStrategy
    {
        FileType FileType { get; }

        string Serialize(Document document);
    }
}