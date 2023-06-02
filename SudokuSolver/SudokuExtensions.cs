using SudokuSolver.Models;

namespace SudokuSolver
{
    public static class SudokuExtensions
    {
        private static readonly char[] AcceptedIntChars = new char[]
        {
            '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public static bool IsInRange(this int x)
            => x is >= 1 and <= 9;

        public static bool IsInRange(this Cell cell)
            => cell.Value.IsInRange();

        public static bool IsInRange(this char chr)
            => AcceptedIntChars.Contains(chr);
    }
}
