using System;
using System.Linq;
using JetBrains.Annotations;

namespace GameOfLifeLibrary
{
    public static class GridSerialization
    {
        [NotNull, Pure]
        public static Grid Parse([NotNull] string input)
        {
            if (input == String.Empty)
            {
                return new Grid();
            }
            else
            {
                return new Grid(new bool[,] { {input[0] == '*'} });
            }
        }
    }
}