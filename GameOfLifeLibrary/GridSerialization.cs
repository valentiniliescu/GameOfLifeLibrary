﻿using System;
using System.Linq;
using System.Text;
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
                var rows = input.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
                var booleanGrid = new bool[rows.Length, rows[0].Length];

                for (var row = 0; row < booleanGrid.GetLength(0); row++)
                {
                    var booleanRow = rows[row].Select(c => c == '*').ToArray();
                    for (var col = 0; col < booleanGrid.GetLength(1); col++)
                    {
                        booleanGrid[row, col] = booleanRow[col];
                    }
                }
                return new Grid(booleanGrid);
            }
        }

        [NotNull, Pure]
        public static string ToString([NotNull] Grid grid)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < grid.NumberOfRows; row++)
            {
                for (var col = 0; col < grid.NumberOfColumns; col++)
                {
                    sb.Append(grid[row, col] ? '*' : '.');
                }
                sb.Append('\n');
            }

            if (sb.Length > 0)
            {
                sb.Length--;
            }

            return sb.ToString();
        }
    }
}