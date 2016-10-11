using JetBrains.Annotations;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        private readonly bool[,] _booleanGrid;

        public bool this[int row, int col] => _booleanGrid[row, col];
        public int NumberOfRows => _booleanGrid.GetLength(0);
        public int NumberOfColumns => _booleanGrid.GetLength(1);

        public Grid()
        {
            _booleanGrid = new bool[0, 0];
        }

        public Grid([NotNull] bool[,] booleanGrid)
        {
            _booleanGrid = (bool[,])booleanGrid.Clone();
        }

        [Pure]
        public override bool Equals(object obj)
        {
            var other = obj as Grid;

            if (other == null || NumberOfRows != other.NumberOfRows || NumberOfColumns != other.NumberOfColumns)
            {
                return false;
            }

            for (var row = 0; row < NumberOfRows; row++)
            {
                for (var col = 0; col < NumberOfColumns; col++)
                {
                    if (_booleanGrid[row, col] != other._booleanGrid[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            // TODO: implement it
            return 0;
        }

        [Pure]
        public int GetLiveCellNeighborCount(int row, int column)
        {
            var count = 0;

            for (var currentRow = row - 1; currentRow <= row + 1; currentRow++)
            {
                for (var currentColumn = column - 1; currentColumn <= column + 1; currentColumn++)
                {
                    if (0 <= currentRow && currentRow < NumberOfRows
                        && 0 <= currentColumn && currentColumn < NumberOfColumns
                        && this[currentRow, currentColumn])
                    {
                        count++;
                    }
                }
            }

            if (this[row, column])
            {
                count--;
            }

            return count;
        }
    }
}