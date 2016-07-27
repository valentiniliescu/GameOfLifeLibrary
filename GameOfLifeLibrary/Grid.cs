namespace GameOfLifeLibrary
{
    public class Grid
    {
        public static Grid Parse(string text)
        {
            return new Grid();
        }

        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }

        public bool this[int column, int row]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}