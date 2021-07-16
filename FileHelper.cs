using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public static class FileHelper
    {
        public static InputType GetFileType(string sourceFileName)
        {
            var extension = Path.GetExtension(sourceFileName);
            var clearExtension = extension.Replace(".", "");

            if (Enum.TryParse(clearExtension, true, out InputType inputType))
            {
                return inputType;
            }

            throw new NotSupportedException($"Unsupported extension '{clearExtension}'");
        }

        public static bool FileValidation(string fileName)
        {
            return File.Exists(fileName);
        }

        public static string OpenAsString(string fileName)
        {
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
    }
}
