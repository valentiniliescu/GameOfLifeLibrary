using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void EmptyStringShouldParseToEmptyGrid()
        {
            var grid = Grid.Parse(string.Empty);
            grid.NumberOfColumns.Should().Be(0);
            grid.NumberOfRows.Should().Be(0);
        }

        [TestMethod]
        public void SingleCharStringShouldParseTo1X1Grid()
        {
            var grid = Grid.Parse("*");
            grid.NumberOfColumns.Should().Be(1);
            grid.NumberOfRows.Should().Be(1);
            grid[0, 0].Should().BeTrue();
        }
    }
}