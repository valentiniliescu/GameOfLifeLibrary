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

        public IEnumerable<Coordinates> NeighborsCoordinates => CellCoordinates.SelectMany(coordinates => coordinates.Neighbors).Except(CellCoordinates).Distinct();

        public Grid GetNextGeneration()
        {
            var cellsThatContinueToLive =
                CellCoordinates.Where(
                    c =>
                        1 < c.Neighbors.Intersect(CellCoordinates).Count() &&
                        c.Neighbors.Intersect(CellCoordinates).Count() < 4);
            var cellsThatBecomeAlive =
                NeighborsCoordinates.Where(
                    c =>
                        2 < c.Neighbors.Intersect(CellCoordinates).Count() &&
                        c.Neighbors.Intersect(CellCoordinates).Count() < 4);

            return new Grid(cellsThatContinueToLive.Union(cellsThatBecomeAlive));
        }
    }
}