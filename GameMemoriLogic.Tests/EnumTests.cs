using Xunit;
using GameMemoriLogic;

namespace GameMemoriLogic.Tests
{
    public class EnumTests
    {
        [Fact]
        public void GameMode_ShouldHaveCorrectValues()
        {
            // Assert
            Assert.Equal(0, (int)GameMode.Solo);
            Assert.Equal(1, (int)GameMode.OneVsOne);
            Assert.Equal(2, (int)GameMode.FourPlayers);
        }

        [Fact]
        public void BoardSize_ShouldHaveCorrectCardCounts()
        {
            // Assert
            Assert.Equal(2, (int)BoardSize.Small2x2);
            Assert.Equal(8, (int)BoardSize.Small2x4);
            Assert.Equal(16, (int)BoardSize.Medium4x4);
            Assert.Equal(32, (int)BoardSize.Large4x8);
            Assert.Equal(64, (int)BoardSize.ExtraLarge8x8);
        }
    }
}