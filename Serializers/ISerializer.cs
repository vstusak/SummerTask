namespace SummerTask.Serializers
{
    public interface ISerializer
    {
        string SerializeDocument(Document document);

        void SetStrategy(ISerializeStrategy getSerializer);
    }
}