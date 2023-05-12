namespace SudokuSolver.Models
{
    public class SudokuPuzzle
    {
        internal int[,] _board;

        public SudokuPuzzle(int[,] board)
        {
            _board = board;
        }

        public static implicit operator SudokuPuzzle(int[,] board)
            => new SudokuPuzzle(board);

        public static implicit operator int[,](SudokuPuzzle puzzle)
            => puzzle._board;
    }
}