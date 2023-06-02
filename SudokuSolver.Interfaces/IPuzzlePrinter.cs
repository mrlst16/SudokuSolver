using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzlePrinter
    {
        string Print(SudokuPuzzle puzzle);
    }
}
