using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void GridConstructorShouldInitializeCellsCoordinates()
        {
            var grid = new Grid(new Coordinates(0, 0));

            grid.CellCoordinates.Should().BeEquivalentTo(new Coordinates(0, 0));
        }

        [TestMethod]
        public void SingleCellGridCellsAndNeighborsCoordinates()
        {
            var grid = new Grid(new Coordinates(0, 0));

            grid.CellsAndNeighborsCoordinates.Should().BeEquivalentTo(
                new Coordinates(-1, -1),
                new Coordinates(-1, 0),
                new Coordinates(-1, 1),
                new Coordinates(0, -1),
                new Coordinates(0, 0),
                new Coordinates(0, 1),
                new Coordinates(1, -1),
                new Coordinates(1, 0),
                new Coordinates(1, 1)
            );
        }

        [TestMethod]
        public void MultipleCellsGridCellsAndNeighborsCoordinates()
        {
            var grid = new Grid(new Coordinates(0, 0), new Coordinates(1, 1));

            grid.CellsAndNeighborsCoordinates.Should().BeEquivalentTo(
                new Coordinates(-1, -1),
                new Coordinates(-1, 0),
                new Coordinates(-1, 1),
                new Coordinates(0, -1),
                new Coordinates(0, 0),
                new Coordinates(0, 1),
                new Coordinates(1, -1),
                new Coordinates(1, 0),
                new Coordinates(1, 1),
                new Coordinates(2, 0),
                new Coordinates(2, 1),
                new Coordinates(2, 2),
                new Coordinates(1, 2),
                new Coordinates(0, 2)
            );
        }

        [TestMethod]
        public void EmptyGridGetNextGenerationShouldReturnEmptyGrid()
        {
            var grid = new Grid();

            grid.GetNextGeneration().CellCoordinates.Should().BeEmpty();
        }

        [TestMethod]
        public void GridWithFourCellsClusterGetNextGenerationShouldStayTheSame()
        {
            var cellCoordinates = new[]
            {
                new Coordinates(0, 1),
                new Coordinates(0, 0),
                new Coordinates(1, 0),
                new Coordinates(1, 1)
            };

            var grid = new Grid(cellCoordinates);

            grid.GetNextGeneration().CellCoordinates.Should().BeEquivalentTo(cellCoordinates);
        }

        [TestMethod]
        public void GridWithOneCellGetNextGenerationShouldReturnEmptyGrid()
        {
            var grid = new Grid(new Coordinates(0, 0));

            grid.GetNextGeneration().CellCoordinates.Should().BeEmpty();
        }
    }
}
