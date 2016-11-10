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
            var grid = new Grid(new[] {new Coordinates(0,0)});

            grid.CellCoordinates.Should().BeEquivalentTo(new Coordinates(0, 0));
        }

        [TestMethod]
        public void GridCellsAndNeighborsCoordinates()
        {
            var grid = new Grid(new[] { new Coordinates(0, 0) });

            grid.CellsAndNeighborsCoordinates.Should().BeEquivalentTo(new Coordinates(0, 0).NeighborsAndItself);
        }
    }
}
