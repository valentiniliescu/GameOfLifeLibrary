using JetBrains.Annotations;

namespace GameOfLifeLibrary
{
    public static class GridSerialization
    {
        [NotNull, Pure]
        public static Grid Parse([NotNull] string input)
        {
            return new Grid();
        }
    }
}