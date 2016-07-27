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

        [TestMethod]
        public void Parse2X2Grid()
        {
            var grid = Grid.Parse("*.\n.*");
            grid.NumberOfColumns.Should().Be(2);
            grid.NumberOfRows.Should().Be(2);
            grid[0, 0].Should().BeTrue();
            grid[1, 0].Should().BeFalse();
            grid[0, 1].Should().BeFalse();
            grid[1, 1].Should().BeTrue();
        }

        [TestMethod]
        public void Parse3X1Grid()
        {
            var grid = Grid.Parse("*.*");
            grid.NumberOfColumns.Should().Be(3);
            grid.NumberOfRows.Should().Be(1);
            grid[0, 0].Should().BeTrue();
            grid[1, 0].Should().BeFalse();
            grid[2, 0].Should().BeTrue();
        }

        [TestMethod]
        public void Parse1X3Grid()
        {
            var grid = Grid.Parse("*\n.\n*");
            grid.NumberOfColumns.Should().Be(1);
            grid.NumberOfRows.Should().Be(3);
            grid[0, 0].Should().BeTrue();
            grid[0, 1].Should().BeFalse();
            grid[0, 2].Should().BeTrue();
        }

        [TestMethod]
        public void Parse3X2Grid()
        {
            var grid = Grid.Parse("*.*\n***");
            grid.NumberOfColumns.Should().Be(3);
            grid.NumberOfRows.Should().Be(2);
            grid[0, 0].Should().BeTrue();
            grid[1, 0].Should().BeFalse();
            grid[2, 0].Should().BeTrue();
            grid[0, 1].Should().BeTrue();
            grid[1, 1].Should().BeTrue();
            grid[2, 1].Should().BeTrue();
        }
    }
}