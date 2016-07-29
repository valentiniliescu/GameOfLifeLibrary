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

        //TODO: add invalid parsing tests
        //TODO: add invalid column and row tests

        [TestMethod]
        public void GridToStringShouldReturnInputString()
        {
            var gridText = "*.*\n***";
            Grid.Parse(gridText).ToString().Should().Be(gridText);
        }

        [TestMethod]
        public void NumberOfLivingNeighborsInTheCenter()
        {
            var grid = Grid.Parse("***\n***\n***");

            grid.GetNumberOfLivingNeighbors(1, 1).Should().Be(8);
        }

        [TestMethod]
        public void NumberOfLivingNeighborsInTheCorners()
        {
            var grid = Grid.Parse("***\n.**\n*.*");

            grid.GetNumberOfLivingNeighbors(0, 0).Should().Be(2);
            grid.GetNumberOfLivingNeighbors(2, 0).Should().Be(3);
            grid.GetNumberOfLivingNeighbors(0, 2).Should().Be(1);
            grid.GetNumberOfLivingNeighbors(2, 2).Should().Be(2);
        }

        [TestMethod]
        public void LiveCellWithTooFewLiveNeighborsDies()
        {
            var grid = Grid.Parse("***\n.**\n*.*");
            grid.GetNextGeneration(0, 2).Should().BeFalse();
        }

        [TestMethod]
        public void LiveCellWithTooManyLiveNeighborsDies()
        {
            var grid = Grid.Parse(".**\n***");
            grid.GetNextGeneration(1, 0).Should().BeFalse();
        }

        [TestMethod]
        public void LiveCellWithSomeLiveNeighborsSurvives()
        {
            var grid = Grid.Parse(".*.\n***");
            grid.GetNextGeneration(1, 0).Should().BeTrue();
            grid.GetNextGeneration(0, 1).Should().BeTrue();
        }

        [TestMethod]
        public void DeadCellWithTooFewLiveNeighborsStaysDead()
        {
            var grid = Grid.Parse("..\n**");
            grid.GetNextGeneration(0, 0).Should().BeFalse();
        }

        [TestMethod]
        public void DeadCellWithTooManyLiveNeighborsStaysDead()
        {
            var grid = Grid.Parse("*.*\n*.*");
            grid.GetNextGeneration(1, 0).Should().BeFalse();
        }
    }
}