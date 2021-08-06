using System;
using SummerTask.Serializers;

namespace SummerTask
{
    public class SerializeStrategyFactory
    {
        public ISerializeStrategy GetStrategy(FileType inputType)
        {
            switch (inputType)
            {
                case FileType.Xml:
                    return new XmlSerializerStrategy();

                case FileType.Json:
                    return new JsonSerializerStrategy();

                case FileType.Html:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}