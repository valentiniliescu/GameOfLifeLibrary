using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GridSerializationTests
    {
        [TestMethod]
        public void ParsingEmptyStringShouldReturn0X0Grid()
        {
            GridSerialization.Parse("").Should().Be(new Grid());
        }

        [TestMethod]
        public void ParsingOneStarCharacterShouldReturn1X1GridWithLiveCell()
        {
            var booleanGrid = new[,] { { true } };

            GridSerialization.Parse("*").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingOneDotCharacterShouldReturn1X1GridWithDeadCell()
        {
            var booleanGrid = new[,] { { false } };

            GridSerialization.Parse(".").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingOneLineShouldReturn1XnGrid()
        {
            var booleanGrid = new[,] { { true, false } };

            GridSerialization.Parse("*.").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingMultipleLinesShouldReturnAGrid()
        {
            var booleanGrid = new[,] { { true, false }, { false, true } };

            GridSerialization.Parse("*.\n.*").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void EmptyGridToStringShouldReturnEmptyString()
        {
            GridSerialization.ToString(new Grid()).Should().BeEmpty();
        }

        [TestMethod]
        public void GridToStringShouldReturnString()
        {
            var booleanGrid = new[,] { { true, false }, { false, true } };

            GridSerialization.ToString(new Grid(booleanGrid)).Should().Be("*.\n.*");
        }
    }
}
