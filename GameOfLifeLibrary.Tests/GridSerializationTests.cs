﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GameOfLifeLibrary.Tests
{
    [TestClass]
    public class GridSerializationTests
    {
        [TestMethod]
        public void ParsingEmptyStringShouldReturn0X0Grid()
        {
            GridSerialization.Parse("").Should().Be(new Grid());
        }

        [TestMethod]
        public void ParsingOneStarCharacterShouldReturn1X1GridWithLiveCell()
        {
            var booleanGrid = new[,] { { true } };

            GridSerialization.Parse("*").Should().Be(new Grid(booleanGrid));
        }

        [TestMethod]
        public void ParsingOneDotCharacterShouldReturn1X1GridWithDeadCell()
        {
            var booleanGrid = new[,] { { false } };

            GridSerialization.Parse(".").Should().Be(new Grid(booleanGrid));
        }
    }
}