using System;
using System.Collections.Generic;
using System.Linq;
using SummerTask.Serializers;

namespace SummerTask
{
    public class SerializeStrategyFactory : ISerializeStrategyFactory
    {
        //private readonly XmlSerializerStrategy _xmlSerializerStrategy;
        //private readonly JsonSerializerStrategy _jsonSerializerStrategy;
        //private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<ISerializeStrategy> _serializeStrategies;

        //public SerializeStrategyFactory(
        //    XmlSerializerStrategy xmlSerializerStrategy,
        //    JsonSerializerStrategy jsonSerializerStrategy)
        //{
        //    _xmlSerializerStrategy = xmlSerializerStrategy;
        //    _jsonSerializerStrategy = jsonSerializerStrategy;
        //}

        public SerializeStrategyFactory(
            IList<ISerializeStrategy> serializeStrategies)
        {
            _serializeStrategies = serializeStrategies;
        }

        // NOT TODO - do not inject service provider, because you will expose all implementations in container
        //public SerializeStrategyFactory(
        //    IServiceProvider serviceProvider)
        //{
        //    _serviceProvider = serviceProvider;
        //}

        public ISerializeStrategy GetStrategy(FileType inputType)
        {
            return _serializeStrategies
                .First(strategy => strategy.FileType == inputType);
            //switch (inputType)
            //{
            //    case FileType.Xml:
            //        //return _serviceProvider.GetService<XmlSerializerStrategy>();
            //        return _serializeStrategies.FirstOrDefault(strategy => strategy.FileType == FileType.Xml);

            //    case FileType.Json:
            //        return _jsonSerializerStrategy;

            //    case FileType.Html:
            //        throw new NotImplementedException();

            //    default:
            //        throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            //}
        }
    }
}