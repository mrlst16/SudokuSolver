using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    /// <summary>
    /// interface for a decorator to the sudoku puzzle
    /// </summary>
    public interface IPuzzleNavigator
    {
        Cell[,] GetSquareOfPosition(int i, int j);
        bool SelectionCanGoInRow(int i, int selection);
        bool SelectionCanGoInColumn(int j, int selection);
        bool SelectionCanGoInSquare(int i, int j, int selection);
    }
}
