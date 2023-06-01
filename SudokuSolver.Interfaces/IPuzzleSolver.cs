using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleSolver
    {
        SudokuAnalytics Solve(SudokuPuzzle puzzle);
    }
}
