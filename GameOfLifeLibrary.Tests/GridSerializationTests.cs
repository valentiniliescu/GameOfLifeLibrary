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
            GridSerialization.Parse("").Should().Be(new Grid(0, 0));
        }
    }
}
