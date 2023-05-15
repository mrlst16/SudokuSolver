using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    /// <summary>
    /// interface for a decorator to the sudoku puzzle
    /// </summary>
    public interface IPuzzleNavigator
    {
        int[,] GetSquareOfPosition(int i, int j);
    }
}
