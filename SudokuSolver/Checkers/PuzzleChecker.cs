using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Checkers
{
    public class PuzzleChecker : IPuzzleChecker
    {
        public bool Check(Cell[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                Cell[] row = board.GetRow(i);
                if (
                    !row.HasUniqueValues()
                    || row.Any(x => x <= 0 || x > 9)
                )
                    return false;

                Cell[] column = board.GetColumn(i);
                if (
                    !column.HasUniqueValues()
                    || column.Any(x => x <= 0 || x > 9)
                )
                    return false;

                Cell[,] square = GetSquare(board, i);
                if (
                    !square.IsUnique()
                    || square.Flatten().Any(x => x <= 0 || x > 9)
                )
                    return false;
            }

            return true;
        }

        private Cell[,] GetSquare(Cell[,] board, int i) => i switch
        {
            0 => board.GetSquare(0, 2, 0, 2),
            1 => board.GetSquare(0, 2, 3, 5),
            2 => board.GetSquare(0, 2, 6, 8),
            3 => board.GetSquare(3, 5, 0, 2),
            4 => board.GetSquare(3, 5, 3, 5),
            5 => board.GetSquare(3, 5, 6, 8),
            6 => board.GetSquare(6, 8, 0, 2),
            7 => board.GetSquare(6, 8, 3, 5),
            8 => board.GetSquare(6, 8, 6, 8)
        };
    }
}
