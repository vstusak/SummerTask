using Newtonsoft.Json;

namespace SummerTask.Serializers
{
    public class JsonSerializeStrategy : ISerializeStrategy
    {
        public FileType FileType => FileType.Json;

        public string Serialize(Document document)
        {
            var serializedDoc = JsonConvert.SerializeObject(document);
            return serializedDoc;
        }
    }
}