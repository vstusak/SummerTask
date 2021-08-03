using Newtonsoft.Json;

namespace SummerTask
{
    public class JsonParser : IParser
    {
        public Document Parse(string input)
        {
            return JsonConvert.DeserializeObject<Document>(input);
        }
    }
}