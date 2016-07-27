using System.Linq;

namespace GameOfLifeLibrary
{
    public static class GameOfLife
    {
        public static string GetNextGeneration(string gridText)
        {
            var numberOfRows = gridText.Count(c => c == '\n') + 1; 
            var numberOfColumns = gridText.IndexOf('\n') > -1 ? gridText.IndexOf('\n') : gridText.Length;

            var grid = new bool[numberOfColumns, numberOfRows];

            for (var index = 0; index < gridText.Length; index++)
            {
                var c = gridText[index];
                grid[index % numberOfColumns, index / (numberOfColumns + 1)] = c == '*';
            }

            var newGrid = new bool[numberOfColumns, numberOfRows];
            for (var col = 0; col < numberOfColumns; col++)
            {
                for (var row = 0; row < numberOfRows; row++)
                {
                    //newGrid[col, row] = formula of grid(col, row) and neighbors(grid(col, row))
                }
            }

            return null; // return string representation of the grid
        }
    }
}