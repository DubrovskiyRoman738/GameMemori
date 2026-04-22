using Xunit;
using GameMemoriLogic;

namespace GameMemoriLogic.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_Constructor_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var player = new Player("TestPlayer");

            // Assert
            Assert.Equal("TestPlayer", player.Name);
            Assert.Equal(0, player.Score);
            Assert.Equal(30, player.TimeLeft);
            Assert.False(player.IsActive);
        }

        [Fact]
        public void Player_Name_ShouldBeChangeable()
        {
            // Arrange
            var player = new Player("OldName");

            // Act
            player.Name = "NewName";

            // Assert
            Assert.Equal("NewName", player.Name);
        }

        [Fact]
        public void Player_Score_ShouldBeChangeable()
        {
            // Arrange
            var player = new Player("TestPlayer");

            // Act
            player.Score = 50;

            // Assert
            Assert.Equal(50, player.Score);
        }

        [Fact]
        public void Player_TimeLeft_ShouldBeChangeable()
        {
            // Arrange
            var player = new Player("TestPlayer");

            // Act
            player.TimeLeft = 15;

            // Assert
            Assert.Equal(15, player.TimeLeft);
        }

        [Fact]
        public void Player_IsActive_ShouldBeChangeable()
        {
            // Arrange
            var player = new Player("TestPlayer");

            // Act
            player.IsActive = true;

            // Assert
            Assert.True(player.IsActive);
        }
    }
}