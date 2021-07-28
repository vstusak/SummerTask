using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    class FileConverter
    {
        private readonly FileUtils _fileUtils;
        private readonly IParser _parser;
        private readonly JsonParser _jsonParser;

        public FileConverter(FileUtils fileUtils, IParser parser, JsonParser jsonParser)
        {
            _fileUtils = fileUtils;
            _parser = parser;
            _jsonParser = jsonParser;
        }

        public void Execute(string sourceFileName, string targetFileName)
        {
            var input = _fileUtils.ReadFile(sourceFileName);

            //var document = _xmlParser.Parse(input);
            //TODO set parsing strategy
            var document = _parser.Parse(input);
            var serializedDoc = _jsonParser.Serialize(document); // save file to the correct path. Save file according to its target format

            _fileUtils.WriteFile(targetFileName, serializedDoc);
        }
    }
}
