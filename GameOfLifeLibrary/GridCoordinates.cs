namespace GameOfLifeLibrary
{
    public struct GridCoordinates
    {
        public int Column { get; }
        public int Row { get; }

        public GridCoordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}