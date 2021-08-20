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
        [Test]
        public void Test1() //naming: GivenWhenThen
        {
            //Arrange
            var mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            var mockFileUtils = mockRepository.Create<FileUtils>();
            var mockParser = mockRepository.Create<IParser>();
            var mockParsingStrategyFactory = mockRepository.Create<IParsingStrategyFactory>();
            mockFileUtils.Setup(mfu => mfu.ReadFile(It.IsAny<string>())).Returns("ReadFileResult");

            var unitUnderTest = new FileConverter(mockFileUtils.Object, mockParser.Object, mockParsingStrategyFactory.Object);

            //Act
            unitUnderTest.Execute("", "");

            //Assert

        }
    }
}
