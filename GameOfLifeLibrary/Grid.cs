using System;
using System.Linq;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        public readonly Coordinates[] CellCoordinates;

        public Grid(Coordinates[] cellCoordinates)
        {
            CellCoordinates = cellCoordinates;
        }

        public Coordinates[] CellsAndNeighborsCoordinates => CellCoordinates.SelectMany(coordinates => coordinates.NeighborsAndItself).ToArray();
    }
}