using SummerTask.Serializers;

namespace SummerTask
{
    public interface ISerializeStrategyFactory
    {
        ISerializeStrategy GetStrategy(FileType inputType);
    }
}