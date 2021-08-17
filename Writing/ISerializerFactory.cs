namespace SummerTask
{
    public interface ISerializerFactory
    {
        ISerializer LoadSerializer(string targetFileName);
    }
}