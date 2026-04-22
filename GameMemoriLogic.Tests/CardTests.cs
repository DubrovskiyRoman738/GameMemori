using Xunit;
using GameMemoriLogic;

namespace GameMemoriLogic.Tests
{
    public class CardTests
    {
        [Fact]
        public void Card_Constructor_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var card = new Card(1, 5);

            // Assert
            Assert.Equal(1, card.Id);
            Assert.Equal(5, card.PairId);
            Assert.False(card.IsFlipped);
            Assert.False(card.IsMatched);
        }

        [Fact]
        public void Card_IsFlipped_ShouldBeSettable()
        {
            // Arrange
            var card = new Card(1, 1);

            // Act
            card.IsFlipped = true;

            // Assert
            Assert.True(card.IsFlipped);
        }

        [Fact]
        public void Card_IsMatched_ShouldBeSettable()
        {
            // Arrange
            var card = new Card(1, 1);

            // Act
            card.IsMatched = true;

            // Assert
            Assert.True(card.IsMatched);
        }
    }
}