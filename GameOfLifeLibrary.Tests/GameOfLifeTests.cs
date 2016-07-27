using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void GetNextGenerationShouldReturnEmptyForEmptyGrid()
        {
            GameOfLife.GetNextGeneration(string.Empty).Should().BeEmpty();
        }

        [TestMethod]
        public void GetNextGenerationShouldReturnDeadCellForASingleLivingCell()
        {
            GameOfLife.GetNextGeneration("*").Should().Be(".");
        }
    }
}
