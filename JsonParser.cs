using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class JsonParser
    {
        public string Serialize(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }
    }
}
