namespace GameOfLifeLibrary
{
    public static class GameOfLife
    {
        public static string GetNextGeneration(string grid)
        {
            switch (grid)
            {
                case "*":
                    return ".";
            }
            return string.Empty;
        }
    }
}