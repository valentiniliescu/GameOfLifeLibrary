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

        public bool this[int column, int row] => this[new GridCoordinates(column, row)];

        public bool this[GridCoordinates coordinates] => _gridText[coordinates.Row * (NumberOfColumns + 1/*RowDelimiter length*/) + coordinates.Column] == '*';

        public override string ToString()
        {
            return _gridText;
        }

        public int GetNumberOfLivingNeighbors(int column, int row)
        {
            return GetNumberOfLivingNeighbors(new GridCoordinates(column, row));
        }

        public int GetNumberOfLivingNeighbors(GridCoordinates coordinates)
        {
            var offsets = new[]{-1, 0, 1};

            var neighborOffsets = offsets
                .SelectMany(c => offsets, (offsetColumn, offsetRow) => new GridCoordinates(offsetColumn, offsetRow))
                .Where(offset => offset.Column != 0 || offset.Row != 0);

            var neighborCoordinates = neighborOffsets
                .Select(offset => new GridCoordinates(coordinates.Column + offset.Column, coordinates.Row + offset.Row))
                .Where(AreInBounds);

            var livingNeighborsCount = neighborCoordinates.Count(gridCoordinates => this[gridCoordinates]);

            return livingNeighborsCount;
        }

        private bool AreInBounds(GridCoordinates gridCoordinates)
        {
            return 0 <= gridCoordinates.Column && gridCoordinates.Column < NumberOfColumns && 
                0 <= gridCoordinates.Row && gridCoordinates.Row < NumberOfRows;
        }

        public bool GetNextGeneration(int column, int row)
        {
            return GetNextGeneration(new GridCoordinates(column, row));
        }

        public bool GetNextGeneration(GridCoordinates coordinates)
        {
            var liveNeighborsCount = GetNumberOfLivingNeighbors(coordinates);

            return 
                (this[coordinates] && liveNeighborsCount >= 2 && liveNeighborsCount <= 3) ||
                (!this[coordinates] && liveNeighborsCount == 3);
        }
    }
}