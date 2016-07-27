using System.Linq;

namespace GameOfLifeLibrary
{
    public class Grid
    {
        private string _gridText;
        private static readonly char RowDelimiter = '\n';

        public static Grid Parse(string text)
        {
            return new Grid { _gridText = text };
        }

        public int NumberOfColumns
        {
            get
            {
                return _gridText.IndexOf(RowDelimiter) > -1 ? _gridText.IndexOf(RowDelimiter) : _gridText.Length;
            }
        }

        public int NumberOfRows
        {

            get
            {
                return _gridText != string.Empty ? _gridText.Count(c => c == RowDelimiter) + 1 : 0;
            }
        }

        public bool this[int column, int row]
        {
            get
            {
                return _gridText[row *(NumberOfColumns + 1/*RowDelimiter length*/) + column] == '*';
            }
        }
    }
}