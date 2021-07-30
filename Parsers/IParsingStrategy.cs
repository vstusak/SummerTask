using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public interface IParsingStrategy
    {
        Document Parse(string input);
    }
}
