using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask.Serializers
{
    class HtmlSerializerStrategy : ISerializeStrategy
    {
        FileType ISerializeStrategy.FileType => FileType.Html;

        string ISerializeStrategy.Serialize(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
