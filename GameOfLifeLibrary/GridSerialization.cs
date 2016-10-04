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
                var booleanLineArray = input.Select(c => c == '*').ToArray();
                var booleanGrid = new bool[1, booleanLineArray.Length];
                for (var col = 0; col < booleanGrid.GetLength(1); col++)
                {
                    booleanGrid[0, col] = booleanLineArray[col];
                }
                return new Grid(booleanGrid);
            }
        }
    }
}