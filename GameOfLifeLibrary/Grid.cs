namespace GameOfLifeLibrary
{
    public class Grid
    {
        private string _gridText;

        public static Grid Parse(string text)
        {
            return new Grid { _gridText = text };
        }

        public int NumberOfColumns
        {
            get
            {
                return _gridText.Length;
            }
        }

        public int NumberOfRows
        {

            get
            {
                return _gridText.Length;
            }
        }

        public bool this[int column, int row]
        {
            get
            {
                return _gridText[0] == '*';
            }
        }
    }
}