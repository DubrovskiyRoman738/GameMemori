using System;
using System.Linq;
using Xunit;
using GameMemoriLogic;

namespace GameMemoriLogic.Tests
{
    public class MemoryGameTests
    {
        [Fact]
        public void Constructor_SoloMode_ShouldCreateOnePlayer()
        {
            // Arrange & Act
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);

            // Assert
            Assert.Equal(GameMode.Solo, game.CurrentGameMode);
            Assert.Equal(BoardSize.Medium4x4, game.CurrentBoardSize);
            Assert.Single(game.Players);
            Assert.Equal("Игрок", game.Players[0].Name);
            Assert.True(game.Players[0].IsActive);
        }

        [Fact]
        public void Constructor_OneVsOneMode_ShouldCreateTwoPlayers()
        {
            // Arrange & Act
            var game = new MemoryGame(GameMode.OneVsOne, BoardSize.Medium4x4);

            // Assert
            Assert.Equal(GameMode.OneVsOne, game.CurrentGameMode);
            Assert.Equal(2, game.Players.Count);
            Assert.Equal("Игрок 1", game.Players[0].Name);
            Assert.Equal("Игрок 2", game.Players[1].Name);
            Assert.True(game.Players[0].IsActive);
            Assert.False(game.Players[1].IsActive);
        }

        [Fact]
        public void Constructor_FourPlayersMode_ShouldCreateFourPlayers()
        {
            // Arrange & Act
            var game = new MemoryGame(GameMode.FourPlayers, BoardSize.Medium4x4);

            // Assert
            Assert.Equal(GameMode.FourPlayers, game.CurrentGameMode);
            Assert.Equal(4, game.Players.Count);
            for (int i = 0; i < 4; i++)
            {
                Assert.Equal($"Игрок {i + 1}", game.Players[i].Name);
            }
            Assert.True(game.Players[0].IsActive);
        }

        [Fact]
        public void Constructor_ShouldCreatePairedCards()
        {
            // Arrange & Act
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);
            var pairs = game.Cards.GroupBy(c => c.PairId);

            // Assert
            Assert.Equal(8, pairs.Count()); // 16 cards / 2 = 8 pairs
            foreach (var pair in pairs)
            {
                Assert.Equal(2, pair.Count()); // Each pair has 2 cards
            }
        }

        [Fact]
        public void SelectCard_FirstCard_ShouldFlipCard()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);
            var cardIndex = 0;

            // Act
            game.SelectCard(cardIndex);

            // Assert
            Assert.True(game.Cards[cardIndex].IsFlipped);
            Assert.NotNull(game.FirstSelectedCard);
            Assert.Null(game.SecondSelectedCard);
            Assert.False(game.IsWaitingForMatch);
        }

        [Fact]
        public void SelectCard_SameCardTwice_ShouldNotFlipAgain()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);
            var cardIndex = 0;

            // Act
            game.SelectCard(cardIndex);
            game.SelectCard(cardIndex);

            // Assert
            Assert.True(game.Cards[cardIndex].IsFlipped);
            Assert.NotNull(game.FirstSelectedCard);
            Assert.Null(game.SecondSelectedCard);
        }

        [Fact]
        public void SelectCard_MatchingCards_ShouldMarkAsMatchedAndAddScore()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);

            var pairId = game.Cards[0].PairId;
            var firstIndex = 0;
            var secondIndex = game.Cards.FindIndex(1, c => c.PairId == pairId);

            int initialScore = game.Players[0].Score;

            // Act
            game.SelectCard(firstIndex);
            game.SelectCard(secondIndex);

            // Assert
            Assert.True(game.Cards[firstIndex].IsMatched);
            Assert.True(game.Cards[secondIndex].IsMatched);
            Assert.Equal(initialScore + 10, game.Players[0].Score);
            Assert.Null(game.FirstSelectedCard);
            Assert.Null(game.SecondSelectedCard);
            Assert.False(game.IsWaitingForMatch);
        }

        [Fact]
        public void SelectCard_NonMatchingCards_ShouldSetWaitingForMatch()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);

            var firstIndex = 0;
            var secondIndex = game.Cards.FindIndex(1, c => c.PairId != game.Cards[0].PairId);

            // Act
            game.SelectCard(firstIndex);
            game.SelectCard(secondIndex);

            // Assert
            Assert.True(game.Cards[firstIndex].IsFlipped);
            Assert.True(game.Cards[secondIndex].IsFlipped);
            Assert.NotNull(game.FirstSelectedCard);
            Assert.NotNull(game.SecondSelectedCard);
            Assert.True(game.IsWaitingForMatch);
        }

        [Fact]
        public void ResetAfterMismatch_ShouldFlipCardsBack()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);

            var firstIndex = 0;
            var secondIndex = game.Cards.FindIndex(1, c => c.PairId != game.Cards[0].PairId);

            game.SelectCard(firstIndex);
            game.SelectCard(secondIndex);

            Assert.True(game.IsWaitingForMatch);

            // Act
            game.ResetAfterMismatch();

            // Assert
            Assert.False(game.Cards[firstIndex].IsFlipped);
            Assert.False(game.Cards[secondIndex].IsFlipped);
            Assert.Null(game.FirstSelectedCard);
            Assert.Null(game.SecondSelectedCard);
            Assert.False(game.IsWaitingForMatch);
        }

        [Fact]
        public void ResetAfterMismatch_Multiplayer_ShouldSwitchPlayer()
        {
            // Arrange
            var game = new MemoryGame(GameMode.OneVsOne, BoardSize.Medium4x4);

            var firstIndex = 0;
            var secondIndex = game.Cards.FindIndex(1, c => c.PairId != game.Cards[0].PairId);

            game.SelectCard(firstIndex);
            game.SelectCard(secondIndex);

            Assert.Equal(0, game.CurrentPlayerIndex);

            // Act
            game.ResetAfterMismatch();

            // Assert
            Assert.Equal(1, game.CurrentPlayerIndex);
            Assert.False(game.Players[0].IsActive);
            Assert.True(game.Players[1].IsActive);
        }

        [Fact]
        public void CheckGameFinished_WhenAllCardsMatched_ShouldReturnTrue()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Small2x2);

            // Match all pairs
            for (int i = 0; i < game.Cards.Count; i += 2)
            {
                game.SelectCard(i);
                game.SelectCard(i + 1);
            }

            // Act & Assert
            Assert.True(game.CheckGameFinished());
        }

        [Fact]
        public void CheckGameFinished_WhenNotAllCardsMatched_ShouldReturnFalse()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Small2x2);

            // Act & Assert
            Assert.False(game.CheckGameFinished());
        }

        [Fact]
        public void GetElapsedTime_SoloMode_ShouldReturnPositiveTimeSpan()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);

            // Act
            var elapsed = game.GetElapsedTime();

            // Assert
            Assert.True(elapsed.TotalSeconds >= 0);
        }

        [Fact]
        public void GetElapsedTime_MultiplayerMode_ShouldReturnZero()
        {
            // Arrange
            var game = new MemoryGame(GameMode.OneVsOne, BoardSize.Medium4x4);

            // Act
            var elapsed = game.GetElapsedTime();

            // Assert
            Assert.Equal(TimeSpan.Zero, elapsed);
        }

        [Fact]
        public void UpdateTimer_MultiplayerMode_ShouldDecreaseTime()
        {
            // Arrange
            var game = new MemoryGame(GameMode.OneVsOne, BoardSize.Medium4x4);
            int initialTime = game.Players[0].TimeLeft;

            // Act
            game.UpdateTimer();

            // Assert
            Assert.Equal(initialTime - 1, game.Players[0].TimeLeft);
        }

        [Fact]
        public void UpdateTimer_SoloMode_ShouldNotChangeTime()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);
            int initialTime = game.Players[0].TimeLeft;

            // Act
            game.UpdateTimer();

            // Assert
            Assert.Equal(initialTime, game.Players[0].TimeLeft);
        }

        [Fact]
        public void UpdateTimer_WhenTimeLeftZero_ShouldNotGoNegative()
        {
            // Arrange
            var game = new MemoryGame(GameMode.OneVsOne, BoardSize.Medium4x4);

            for (int i = 0; i < 31; i++)
            {
                game.UpdateTimer();
            }

            // Act
            game.UpdateTimer();

            // Assert
            Assert.Equal(0, game.Players[0].TimeLeft);
        }

        [Fact]
        public void SelectCard_WhenPlayerTimeZero_ShouldSwitchPlayer()
        {
            // Arrange
            var game = new MemoryGame(GameMode.OneVsOne, BoardSize.Medium4x4);

            for (int i = 0; i < 30; i++)
            {
                game.UpdateTimer();
            }

            int initialPlayerIndex = game.CurrentPlayerIndex;

            // Act
            game.SelectCard(0);

            // Assert
            Assert.NotEqual(initialPlayerIndex, game.CurrentPlayerIndex);
        }

        [Fact]
        public void SelectCard_WhenGameFinished_ShouldNotDoAnything()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Small2x2);

            for (int i = 0; i < game.Cards.Count; i += 2)
            {
                game.SelectCard(i);
                game.SelectCard(i + 1);
            }

            Assert.True(game.IsGameFinished);

            int cardCount = game.Cards.Count;

            // Act
            game.SelectCard(0);

            // Assert
            Assert.Equal(cardCount, game.Cards.Count);
        }

        [Fact]
        public void Winner_SoloMode_AfterGameFinished_ShouldBeTheOnlyPlayer()
        {
            // Arrange
            var game = new MemoryGame(GameMode.Solo, BoardSize.Small2x2);

            for (int i = 0; i < game.Cards.Count; i += 2)
            {
                game.SelectCard(i);
                game.SelectCard(i + 1);
            }

            // Act & Assert
            Assert.NotNull(game.Winner);
            Assert.Equal(game.Players[0], game.Winner);
        }

        [Fact]
        public void Cards_ShouldBeShuffled()
        {
            // Arrange & Act
            var game1 = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);
            var game2 = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);

            var order1 = string.Join(",", game1.Cards.Select(c => c.PairId));
            var order2 = string.Join(",", game2.Cards.Select(c => c.PairId));

            if (order1 == order2)
            {
                var game3 = new MemoryGame(GameMode.Solo, BoardSize.Medium4x4);
                var order3 = string.Join(",", game3.Cards.Select(c => c.PairId));
                Assert.NotEqual(order1, order3);
            }
            else
            {
                Assert.NotEqual(order1, order2);
            }
        }
    }
}