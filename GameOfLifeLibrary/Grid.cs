using System.Linq;

namespace GameOfLifeLibrary
{
    public class Grid
    { 
        private static readonly char RowDelimiter = '\n';

        private readonly string _gridText;

        private Grid(string text)
        {
            _gridText = text;
            NumberOfColumns = _gridText.IndexOf(RowDelimiter) > -1 ? _gridText.IndexOf(RowDelimiter) : _gridText.Length;
            NumberOfRows = _gridText != string.Empty ? _gridText.Count(c => c == RowDelimiter) + 1 : 0;
        }

        public static Grid Parse(string text)
        {
            return new Grid(text);
        }

        public int NumberOfColumns { get; }

        public int NumberOfRows { get; }

        public bool this[int column, int row] => _gridText[row *(NumberOfColumns + 1/*RowDelimiter length*/) + column] == '*';

        public override string ToString()
        {
            return _gridText;
        }

        public int GetNumberOfLivingNeighbors(int column, int row)
        {
            var offsets = new[]{-1, 0, 1};

            var neighborOffsets = offsets
                .SelectMany(c => offsets, (offsetColumn, offsetRow) => new { column = offsetColumn, row = offsetRow })
                .Where(offset => offset.column != 0 || offset.row != 0);

            var neighborCoordinates = neighborOffsets
                .Select(offset => new {column = column + offset.column, row = row + offset.row})
                .Where(coords => 0 <= coords.column && coords.column < NumberOfColumns && 0 <= coords.row && coords.row < NumberOfRows);

            var livingNeighborsCount = neighborCoordinates.Count(coords => this[coords.column, coords.row]);

            return livingNeighborsCount;
        }
    }
}