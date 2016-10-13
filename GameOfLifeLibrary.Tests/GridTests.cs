using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void ParsingEmptyStringShouldReturn0X0Grid()
        {
            Grid.Parse("").Should().Be(new Grid());
        }

        [TestMethod]
        public void ParsingOneStarCharacterShouldReturn1X1GridWithLiveCell()
        {
            var booleanGrid = new[,] { { true } };

            Grid.Parse("*").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingOneDotCharacterShouldReturn1X1GridWithDeadCell()
        {
            var booleanGrid = new[,] { { false } };

            Grid.Parse(".").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingOneLineShouldReturn1XnGrid()
        {
            var booleanGrid = new[,] { { true, false } };

            Grid.Parse("*.").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingMultipleLinesShouldReturnAGrid()
        {
            var booleanGrid = new[,] { { true, false }, { false, true } };

            Grid.Parse("*.\n.*").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void EmptyGridToStringShouldReturnEmptyString()
        {
            new Grid().ToString().Should().BeEmpty();
        }

        [TestMethod]
        public void GridToStringShouldReturnString()
        {
            var booleanGrid = new[,] { { true, false }, { false, true } };

            new Grid(booleanGrid).ToString().Should().Be("*.\n.*");
        }

        [TestMethod]
        public void GridGetLiveCellNeighborCount()
        {
            var booleanGrid = new[,] { { true, false }, { false, true } };

            new Grid(booleanGrid).GetLiveCellNeighborCount(0, 0).Should().Be(1);
        }

        [TestMethod]
        public void GridGetNextGeneration()
        {
            Grid.Parse("***\n.**").GetNextGeneration().ToString().Should().Be("*.*\n*.*");
        }
    }
}
