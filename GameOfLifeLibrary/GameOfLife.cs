namespace GameOfLifeLibrary
{
    public static class GameOfLife
    {
        public static string GetNextGeneration(string gridText)
        {
            return Grid.Parse(gridText).GetNextGeneration().ToString();
        }
    }
}