using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void GridContructorShouldNotThrow()
        {
            Action a = () => new Grid(new[] {
                new Coordinates(0,0)
            });

            a.ShouldNotThrow();
        }
    }
}
