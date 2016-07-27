using System.Linq;

namespace GameOfLifeLibrary
{
    public class Grid
    { 
        private static readonly char RowDelimiter = '\n';

        private readonly string _gridText;

        private Grid(string text)
        {
            _gridText = text;
            NumberOfColumns = _gridText.IndexOf(RowDelimiter) > -1 ? _gridText.IndexOf(RowDelimiter) : _gridText.Length;
            NumberOfRows = _gridText != string.Empty ? _gridText.Count(c => c == RowDelimiter) + 1 : 0;
        }

        public static Grid Parse(string text)
        {
            return new Grid(text);
        }

        public int NumberOfColumns { get; }

        public int NumberOfRows { get; }

        public bool this[int column, int row] => _gridText[row *(NumberOfColumns + 1/*RowDelimiter length*/) + column] == '*';
    }
}