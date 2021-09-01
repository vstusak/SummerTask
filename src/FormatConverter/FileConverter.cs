using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatConverter.Parsers;

namespace FormatConverter
{
    public class FileConverter : IFileConverter
    {
        private readonly IFileUtils _fileUtils;
        private readonly IParser _parser;
        private readonly IParsingStrategyFactory _parsingStrategyFactory;

        public FileConverter(IFileUtils fileUtils, IParser parser, IParsingStrategyFactory parsingStrategyFactory)
        {
            _fileUtils = fileUtils;
            _parser = parser;
            _parsingStrategyFactory = parsingStrategyFactory;
        }

        public void Execute(string sourceFileName, string targetFileName)
        {
            var input = _fileUtils.ReadFile(sourceFileName);

            var parsingStrategy = _parsingStrategyFactory.GetParsingStrategy(sourceFileName);
            _parser.SetParsingStrategy(parsingStrategy);
            var document = _parser.Parse(input);
            //var serializedDoc = _parser.Serialize(document); // save file to the correct path. Save file according to its target format

            //_fileUtils.WriteFile(targetFileName, serializedDoc);
        }
    }
}
