namespace GameOfLifeLibrary
{
    public class Grid
    { 
        public Grid(int rows, int columns)
        {
            
        }

        public override bool Equals(object obj)
        {
            var other = obj as Grid;
            return other != null;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}