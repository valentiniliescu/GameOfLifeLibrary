using System;

namespace GameOfLifeLibrary
{
    public class Coordinates
    {
        public readonly int Row;
        public readonly int Column;

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}