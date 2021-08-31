using Moq;
using NUnit.Framework;
using SummerTask.Parsers;
using SummerTask.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask.Tests
{
    [TestFixture]
    public class DocumentConvertertTests
    {
        private MockRepository _mockRepository;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock};
        }

        [Test]
        public void Test1()
        {
            //Arrange
            //var mockFileHelper = new Mock<FileHelper>();
            var mockFileHelper = _mockRepository.Create<IFileHelper>();
            mockFileHelper.Setup(mfh => mfh.GetFileType(It.IsAny<string>())).Returns(FileType.Xml);
            var mockParser = _mockRepository.Create<IParser>();
            var mockSerializer = _mockRepository.Create<ISerializer>();
            var mockSerializerStrategyFactory = _mockRepository.Create<ISerializeStrategyFactory>();
            var unitUnderTest = new DocumentConverter(mockFileHelper.Object,mockParser.Object,mockSerializer.Object,mockSerializerStrategyFactory.Object);
            //Act
            unitUnderTest.Convert("",""); 
            //Assert
        }
    }
}
