using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleParser
    {
        SudokuPuzzle Parse(string str);
    }
}
