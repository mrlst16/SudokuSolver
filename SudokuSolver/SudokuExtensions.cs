using SudokuSolver.Models;

namespace SudokuSolver
{
    public static class SudokuExtensions
    {
        public static bool IsInRange(this int x)
            => x is >= 1 and <= 9;

        public static bool IsInRange(this Cell cell)
            => cell.Value.IsInRange();
    }
}
