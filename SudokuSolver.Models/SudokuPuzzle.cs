namespace SudokuSolver.Models
{
    public class SudokuPuzzle
    {
        internal int[,] _board;
        public int[,] Board => _board;

        public SudokuPuzzle(int[,] board)
        {
            _board = board;
        }

        public static implicit operator SudokuPuzzle(int[,] board)
            => new SudokuPuzzle(board);

        public static implicit operator int[,](SudokuPuzzle puzzle)
            => puzzle._board;

        public int this[int i, int j]
        {
            get => _board[i, j];
            set => _board[i, j] = value;
        }
    }
}