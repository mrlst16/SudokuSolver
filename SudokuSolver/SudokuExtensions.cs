namespace SudokuSolver
{
    public static class SudokuExtensions
    {
        public static bool IsInRange(this int x)
            => x is >= 1 and <= 9;
    }
}
