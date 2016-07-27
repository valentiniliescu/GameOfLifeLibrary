using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void GetNextGenerationOnEmptyGridShouldReturnEmpty()
        {
            GameOfLife.GetNextGeneration(string.Empty).Should().BeEmpty();
        }

        [TestMethod]
        public void GetNextGenerationOnASingleLivingCellShouldReturnDeadCell()
        {
            GameOfLife.GetNextGeneration("*").Should().Be(".");
        }

        [TestMethod]
        public void GetNextGenerationOnASingleDeadCellShouldReturnDeadCell()
        {
            GameOfLife.GetNextGeneration(".").Should().Be(".");
        }
    }
}
