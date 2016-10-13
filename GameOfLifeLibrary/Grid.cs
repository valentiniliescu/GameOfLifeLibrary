using System;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        private const char NewLineCharacter = '\n';
        private const char LiveCellCharacter = '*';
        private const char DeadCellCharacter = '.';

        private readonly bool[,] _booleanGrid;

        private bool this[int row, int col] => _booleanGrid[row, col];
        private int NumberOfRows => _booleanGrid.GetLength(0);
        private int NumberOfColumns => _booleanGrid.GetLength(1);

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

        [NotNull, Pure]
        public static Grid Parse([NotNull] string input)
        {
            if (input == String.Empty)
            {
                return new Grid();
            }
            else
            {
                var rows = input.Split(new[] { NewLineCharacter }, StringSplitOptions.RemoveEmptyEntries);
                var booleanGrid = new bool[rows.Length, rows[0].Length];

                for (var row = 0; row < booleanGrid.GetLength(0); row++)
                {
                    var booleanRow = rows[row].Select(c => c == LiveCellCharacter).ToArray();
                    for (var col = 0; col < booleanGrid.GetLength(1); col++)
                    {
                        booleanGrid[row, col] = booleanRow[col];
                    }
                }
                return new Grid(booleanGrid);
            }
        }

        [Pure]
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var row = 0; row < NumberOfRows; row++)
            {
                for (var col = 0; col < NumberOfColumns; col++)
                {
                    sb.Append(this[row, col] ? LiveCellCharacter : DeadCellCharacter);
                }
                sb.Append(NewLineCharacter);
            }

            if (sb.Length > 0)
            {
                sb.Length--;
            }

            return sb.ToString();
        }

        public Grid GetNextGeneration()
        {
            var nextGenerationBooleanGrid = new bool[NumberOfRows, NumberOfColumns];

            for (var row = 0; row < NumberOfRows; row++)
            {
                for (var col = 0; col < NumberOfColumns; col++)
                {
                    nextGenerationBooleanGrid[row, col] = DetermineNextGenerationCell(_booleanGrid[row, col], GetLiveCellNeighborCount(row, col));
                }
            }

            return new Grid(nextGenerationBooleanGrid);
        }

        private bool DetermineNextGenerationCell(bool liveCell, int liveCellNeighborCount)
        {
            return (liveCell && 2 <= liveCellNeighborCount && liveCellNeighborCount <= 3) ||
                (!liveCell && liveCellNeighborCount == 3);
        }
    }
}