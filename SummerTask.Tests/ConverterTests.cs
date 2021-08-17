using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask.Tests
{
    public class ConverterTests
    {
        private static string JsonInString => "{\"Title\":\"Document Title\",\"Text\":\"Main text of document\"}";
        private static string XmlInString => "<Root>\r\n <Title>Document Title</Title>\r\n <Text>Main text of document</Text>\r\n</Root>";
        public MockRepository MockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock};

        [Test]
        public void Test1()
        {
            //Arrange
            var _mockFileReader = MockRepository.Create<IFileReader>();
            _mockFileReader.Setup(fr => fr.Read(It.IsAny<string>())).Returns(XmlInString);

            var _mockFileWriter = MockRepository.Create<FileWriter>();
            var _mockParserFactory = MockRepository.Create<ParserFactory>();
            var _mockSerializerFactory = MockRepository.Create<ISerializerFactory>();
            _mockSerializerFactory.Setup(mp => mp.LoadSerializer(It.IsAny<string>())).Returns(new JsonSerializer());

            var unitUnderTest = new Converter(_mockFileReader.Object, _mockFileWriter.Object, _mockParserFactory.Object, _mockSerializerFactory.Object);
            //var folder = Path.GetTempPath();
            var input = "input.xml";
            var output = "output.json";

            //Act
            unitUnderTest.Convert(input, output);

            //Assert
            //var result = File.ReadAllText(output);
            //Assert.AreEqual(JsonInString, result);
        }
    }
}
