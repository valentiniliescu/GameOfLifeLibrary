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
                .SelectMany(c => offsets, (offsetColumn, offsetRow) => new GridCoordinates(offsetColumn, offsetRow))
                .Where(offset => offset.Column != 0 || offset.Row != 0);

            var neighborCoordinates = neighborOffsets
                .Select(offset => new GridCoordinates(column + offset.Column, row + offset.Row))
                .Where(gridCoordinates => 0 <= gridCoordinates.Column && gridCoordinates.Column < NumberOfColumns && 0 <= gridCoordinates.Row && gridCoordinates.Row < NumberOfRows);

            var livingNeighborsCount = neighborCoordinates.Count(gridCoordinates => this[gridCoordinates.Column, gridCoordinates.Row]);

            return livingNeighborsCount;
        }
    }
}