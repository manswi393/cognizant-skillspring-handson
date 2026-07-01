using NUnit.Framework;
using Moq;
using MagicFilesLib;
using System.Collections.Generic;

namespace MagicFilesLib.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _mockExplorer;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockExplorer = new Mock<IDirectoryExplorer>();
        }

        [Test]
        public void GetFiles_ReturnsExpectedFileList()
        {
            // Arrange
            var file1 = "file.txt";
            var file2 = "file2.txt";

            _mockExplorer
                .Setup(x => x.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { file1, file2 });

            // Act
            var result = _mockExplorer.Object.GetFiles("C:\\dummyPath");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Does.Contain(file1));
            Assert.That(result, Does.Contain(file2));
        }
    }
}