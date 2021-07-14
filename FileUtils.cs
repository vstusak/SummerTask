using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class FileUtils
    {
        public string OpenFile(string sourceFileName)
        {
            FileStream sourceStream = File.Open(sourceFileName, FileMode.Open); // use factory or strategy pattern to open different formats of document
            var reader = new StreamReader(sourceStream);
            return reader.ReadToEnd(); // load data with the use of buffer
        }
    }
}
