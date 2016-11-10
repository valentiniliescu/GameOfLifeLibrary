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

            grid.CellCoordinates.Should().HaveCount(1);
            grid.CellCoordinates[0].Should().Be(new Coordinates(0, 0));
        }
    }
}
