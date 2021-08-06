using Newtonsoft.Json;

namespace SummerTask.Serializers
{
    public class JsonSerializerStrategy : ISerializeStrategy
    {
        public string Serialize(Document document)
        {
            var serializedDoc = JsonConvert.SerializeObject(document);
            return serializedDoc;
        }
    }
}