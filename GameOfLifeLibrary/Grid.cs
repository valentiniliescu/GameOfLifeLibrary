using JetBrains.Annotations;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        private readonly bool[,] _booleanGrid;

        public Grid()
        {
            _booleanGrid = new bool[0, 0];
        }

        public Grid([NotNull] bool[,] booleanGrid)
        {
            _booleanGrid = (bool[,])booleanGrid.Clone();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Grid;

            if (other == null || _booleanGrid.GetLength(0) != other._booleanGrid.GetLength(0) ||
                _booleanGrid.GetLength(1) != other._booleanGrid.GetLength(1))
            {
                return false;
            }

            for (var row = 0; row < _booleanGrid.GetLength(0); row++)
            {
                for (var col = 0; col < _booleanGrid.GetLength(1); col++)
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
            return 0;
        }
    }
}