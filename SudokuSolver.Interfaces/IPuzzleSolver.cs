using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleSolver
    {
        SudokuPuzzle Solve(SudokuPuzzle puzzle);
    }
}
