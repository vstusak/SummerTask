using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    class DefaultParsingStrategy : IParsingStrategy
    {
        public Document Parse(string input)
        {
            throw new Exception("Strategy was not set before use"); // lepsi exception TBD
        }
    }
}
