using SudokuSolver.Models;
using SudokuSolver.Navigators;

namespace SudokuSolver.Helpers
{
    public static class FastPencil
    {
        public static void Apply(SudokuPuzzle puzzle)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    puzzle[i, j].Possiblities = PuzzleNavigator.GetPossibleValues(puzzle.Board, i, j);
        }
    }
}
