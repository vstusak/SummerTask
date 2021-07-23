using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class SerializerFactory
    {
        public ISerializer GetSerializer(FileType inputType)
        {
            switch (inputType)
            {
                case FileType.Xml:
                    throw new NotImplementedException();
                case FileType.Json:
                    return new JsonSerializer();
                case FileType.Html:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}
