using SummerTask.Writing;
using System;
using System.IO;

namespace SummerTask
{
    public class SerializerFactory 
    {
        private readonly XmlSummerSerializer _xmlSummerSerializer;
        private readonly JsonSerializer _jsonSerializer;

        public SerializerFactory(XmlSummerSerializer xmlSummerSerializer, JsonSerializer jsonSerializer)
        {
            _xmlSummerSerializer = xmlSummerSerializer;
            _jsonSerializer = jsonSerializer;
        }

        public ISerializer LoadSerializer(string targetFileName)
        {
            var fileExtension = new FileInfo(targetFileName).Extension.Trim('.');

            switch (fileExtension)
            {
                case "xml":
                    return _xmlSummerSerializer;                  
                case "json":
                    return _jsonSerializer;
                default:
                    throw new NotImplementedException($"Unsupported file extension: {fileExtension}");
            }
        }
    }
}