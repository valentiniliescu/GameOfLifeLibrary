using System;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        public readonly Coordinates[] CellCoordinates;

        public Grid(Coordinates[] cellCoordinates)
        {
            CellCoordinates = cellCoordinates;
        }
    }
}