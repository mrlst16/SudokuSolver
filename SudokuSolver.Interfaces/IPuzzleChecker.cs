using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleChecker
    {
        bool Check(Cell[,] board);
    }
}
