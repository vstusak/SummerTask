using System;

namespace SummerTask.Serializers
{
    public class DefaultSerializeStrategy : ISerializeStrategy
    {
        public string Serialize(Document document)
        {
            throw new Exception("Serialize strategy was not set before use");
        }
    }
}