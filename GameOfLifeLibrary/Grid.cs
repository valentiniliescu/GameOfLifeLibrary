using System;
using JetBrains.Annotations;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        private readonly bool[,] _booleanGrid;

        public Grid()
        {
            this._booleanGrid = new bool[0,0];
        }

        public Grid([NotNull] bool[,] booleanGrid)
        {
            this._booleanGrid = booleanGrid;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Grid;
            return other != null && _booleanGrid.GetLength(0) == other._booleanGrid.GetLength(0) && _booleanGrid.GetLength(1) == other._booleanGrid.GetLength(1);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}