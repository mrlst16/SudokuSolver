using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleFactory
    {
        SudokuPuzzle Create(int[,] board);
        SudokuPuzzle Create();
    }
}