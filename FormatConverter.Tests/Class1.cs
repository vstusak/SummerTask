using FormatConverter.Parsers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatConverter.Tests
{
    public class FileConverterTests
    {
        private static string XmlInString => "<Root>\r\n <Title>Document Title</Title>\r\n <Text>Main text of document</Text>\r\n</Root>";
        private static string JsonInString => "{\"Title\":\"Document Title\",\"Text\":\"Main text of document\"}";

        [Test]
        public void FileConverter_Execute_CallsAllDependenciesNeeded() //naming: GivenWhenThen
        {
            //Arrange
            var mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            var mockFileUtils = mockRepository.Create<IFileUtils>();
            mockFileUtils.Setup(mfu => mfu.ReadFile(It.IsAny<string>())).Returns(XmlInString);
            mockFileUtils.Setup(mfu=>mfu.WriteFile(It.IsAny<string>(),It.IsAny<string>())).Verifiable();

            var mockParser = mockRepository.Create<IParser>();

            mockParser.Setup(mp => mp.SetParsingStrategy(It.IsAny<IParsingStrategy>())).Verifiable();
            mockParser.Setup(mp => mp.Parse(It.IsAny<string>())).Returns(new Document());

            var mockParsingStrategyFactory = mockRepository.Create<IParsingStrategyFactory>();
            mockParsingStrategyFactory.Setup(mps => mps.GetParsingStrategy(It.IsAny<string>()))
                .Returns(new XmlParsingStrategy());

            var unitUnderTest = new FileConverter(mockFileUtils.Object, mockParser.Object, mockParsingStrategyFactory.Object);

            //Act
            unitUnderTest.Execute("", "");

            //Assert
            mockParser.Verify(mp=> mp.SetParsingStrategy(It.IsAny<IParsingStrategy>()),Times.Once);
            mockFileUtils.Verify(mfu => mfu.WriteFile(It.IsAny<string>(), It.IsAny<string>()),Times.Once);
        }
    }
}
