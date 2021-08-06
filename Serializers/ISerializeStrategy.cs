namespace SummerTask.Serializers
{
    public interface ISerializeStrategy
    {
        string Serialize(Document document);
    }
}