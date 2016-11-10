using System;

namespace GameOfLifeLibrary
{
    public class Coordinates
    {
        private readonly int _row;
        private readonly int _column;

        public Coordinates[] Neighbors => new Coordinates[0];

        public Coordinates(int row, int column)
        {
            _row = row;
            _column = column;
        }

        private bool Equals(Coordinates other)
        {
            return _row == other._row && _column == other._column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Coordinates) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_row*397) ^ _column;
            }
        }
    }
}