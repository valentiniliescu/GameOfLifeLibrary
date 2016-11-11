using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        public readonly IEnumerable<Coordinates> CellCoordinates;

        private Grid(IEnumerable<Coordinates> cellCoordinates)
        {
            CellCoordinates = cellCoordinates;
        }

        public Grid(params Coordinates[] cellCoordinates): this((IEnumerable<Coordinates>)cellCoordinates)
        {
            
        }

        public IEnumerable<Coordinates> CellsAndNeighborsCoordinates => CellCoordinates.SelectMany(coordinates => coordinates.NeighborsAndItself).Distinct();

        public Grid GetNextGeneration()
        {
            return new Grid(CellCoordinates);
        }
    }
}