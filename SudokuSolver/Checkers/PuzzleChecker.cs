using Common.Extensions;
using SudokuSolver.Interfaces;

namespace SudokuSolver.Checkers
{
    public class PuzzleChecker : IPuzzleChecker
    {
        public bool Check(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                int[] row = board.GetRow(i);
                if (!row.IsUnique()) return false;

                int[] column = board.GetColumn(i);
                if (!column.IsUnique()) return false;

                int[,] square = GetSquare(board, i);
                if (!square.IsUnique()) return false;
            }

            return true;
        }

        private int[,] GetSquare(int[,] board, int i) => i switch
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
