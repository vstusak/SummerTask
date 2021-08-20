﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask.Parsers
{
    public interface IParser
    {
        Document ParseDocument(string input);

        void SetStrategy(IParsingStrategy strategy);
    }
}