using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }
}
