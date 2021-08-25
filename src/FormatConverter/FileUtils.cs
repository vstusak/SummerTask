using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatConverter
{
    public class FileUtils : IFileUtils
    {
        public string ReadFile(string sourceFileName)
        {
            ValidatePath(sourceFileName);

            using (FileStream sourceStream = File.Open(sourceFileName, FileMode.Open))  // use factory or strategy pattern to open different formats of document
            using (var reader = new StreamReader(sourceStream))
            {
                return reader.ReadToEnd(); // load data with the use of buffer
            }

        }

        private void ValidatePath(string sourceFileName)
        {
            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException();
            }
        }

        public void WriteFile(string targetFileName, string serializedDoc)
        {
            using (var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(targetStream))
                sw.Write(serializedDoc);
        }
    }
}
