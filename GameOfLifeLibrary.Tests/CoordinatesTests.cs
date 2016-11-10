using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void CoordinatesNeighbors()
        {
            var coordinates = new Coordinates(0, 0);

            coordinates.Neighbors.Should().BeEquivalentTo(
                new Coordinates(-1, -1),
                new Coordinates(-1, 0),
                new Coordinates(-1, 1),
                new Coordinates(0, -1),
                new Coordinates(0, 1),
                new Coordinates(1, -1),
                new Coordinates(1, 0),
                new Coordinates(1, 1)
            );
        }
    }
}