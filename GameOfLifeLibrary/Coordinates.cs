using System;
using System.Linq;

namespace GameOfLifeLibrary
{
    public class Coordinates
    {
        private readonly int _row;
        private readonly int _column;

        public Coordinates[] Neighbors => new[]
        {
            new Coordinates(_row - 1, _column - 1),
            new Coordinates(_row - 1, _column),
            new Coordinates(_row - 1, _column + 1),
            new Coordinates(_row, _column - 1),
            new Coordinates(_row, _column + 1),
            new Coordinates(_row + 1, _column - 1),
            new Coordinates(_row + 1, _column),
            new Coordinates(_row + 1, _column + 1)
        };

        public Coordinates[] NeighborsAndItself => Neighbors.Union(new[] { this }).ToArray();

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
            return Equals((Coordinates)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_row * 397) ^ _column;
            }
        }

        public override string ToString()
        {
            return $"({_row}, {_column})";
        }
    }
}