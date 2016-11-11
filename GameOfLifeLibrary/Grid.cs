using System;
using System.Collections.Generic;
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

        public IEnumerable<Coordinates> CellsAndNeighborsCoordinates => CellCoordinates.SelectMany(coordinates => coordinates.NeighborsAndItself).Distinct();

        public Grid GetNextGeneration()
        {
            return new Grid(new Coordinates[0]);
        }
    }
}