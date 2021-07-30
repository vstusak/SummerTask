using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class FileHelper
    {
        public FileType GetFileType(string sourceFileName)
        {
            var extension = Path.GetExtension(sourceFileName);
            var clearExtension = extension.Replace(".", "");

            if (Enum.TryParse(clearExtension, true, out FileType inputType))
            {
                return inputType;
            }

            throw new NotSupportedException($"Unsupported extension '{clearExtension}'");
        }

        public bool FileValidation(string fileName)
        {
            return File.Exists(fileName);
        }

        public string OpenAsString(string fileName)
        {
            if (!FileValidation(fileName))
            {
                throw new FileNotFoundException($"Input file '{fileName}' not found.");
            }

            try
            {
                using (var sourceStream = File.Open(fileName, FileMode.Open))
                using (var reader = new StreamReader(sourceStream))
                    return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WriteFile(string targetFileName, string serializedDoc)
        {
            File.WriteAllText(targetFileName, serializedDoc);
        }
    }
}
