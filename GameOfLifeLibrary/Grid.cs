using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        private const int LiveCellNeighbourCountLowerBound = 2;
        private const int LiveCellNeighbourCountUpperBound = 3;
        private const int EmptySlotNeighbourCountLowerBound = 3;
        private const int EmptySlotNeighbourCountUpperBound = 3;

        public readonly IEnumerable<Coordinates> CellCoordinates;

        private Grid(IEnumerable<Coordinates> cellCoordinates)
        {
            CellCoordinates = cellCoordinates;
        }

        public Grid(params Coordinates[] cellCoordinates) : this((IEnumerable<Coordinates>)cellCoordinates)
        {

        }

        public IEnumerable<Coordinates> NeighborsCoordinates => CellCoordinates.SelectMany(coordinates => coordinates.Neighbors).Except(CellCoordinates).Distinct();

        public Grid GetNextGeneration()
        {
            var cellsThatContinueToLive = CellCoordinates.Where(DoesLiveCellContinueToLive);
            var emptySlotsThatBecomeAlive = NeighborsCoordinates.Where(DoesEmptySlotBecomeAlive);

            var newCellCoordinates = cellsThatContinueToLive.Union(emptySlotsThatBecomeAlive);

            return new Grid(newCellCoordinates);
        }

        private bool DoesEmptySlotBecomeAlive(Coordinates coordinates)
        {
            var cellNeigbourCount = CellNeigbourCount(coordinates);
            return EmptySlotNeighbourCountLowerBound <= cellNeigbourCount && cellNeigbourCount <= EmptySlotNeighbourCountUpperBound;
        }

        private bool DoesLiveCellContinueToLive(Coordinates coordinates)
        {
            var cellNeigbourCount = CellNeigbourCount(coordinates);
            return LiveCellNeighbourCountLowerBound <= cellNeigbourCount && cellNeigbourCount <= LiveCellNeighbourCountUpperBound;
        }

        private int CellNeigbourCount(Coordinates coordinates)
        {
            return coordinates.Neighbors.Intersect(CellCoordinates).Count();
        }
    }
}