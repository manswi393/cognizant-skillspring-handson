using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayersManagerLib.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockMapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_ValidPlayer_ReturnsPlayerObject()
        {
            // Arrange
            _mockMapper
                .Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(false);

            _mockMapper
                .Setup(x => x.AddNewPlayerIntoDb(It.IsAny<string>()));

            // Act
            var player = Player.RegisterNewPlayer("Virat", _mockMapper.Object);

            // Assert
            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo("Virat"));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }
    }
}