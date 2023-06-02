namespace SudokuSolver.Models
{
    public class SudokuPuzzle
    {
        public static SudokuPuzzle Empty => new Cell[9, 9]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        internal Cell[,] _board;
        public Cell[,] Board => _board;

        public SudokuPuzzle(Cell[,] board)
        {
            _board = board;
        }

        public SudokuPuzzle(int[,] board)
        {
            _board = new Cell[board.GetLength(0), board.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    _board[i, j] = board[i, j];
        }

        public SudokuPuzzle()
        {
            _board = Empty;
        }

        public static implicit operator SudokuPuzzle(Cell[,] board)
            => new SudokuPuzzle(board);

        public static implicit operator SudokuPuzzle(int[,] board)
            => new SudokuPuzzle(board);

        public static implicit operator Cell[,](SudokuPuzzle puzzle)
            => puzzle._board;

        public Cell this[int i, int j]
        {
            get => _board[i, j];
            set => _board[i, j] = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is SudokuPuzzle two)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        if (Board[i, j].Value != two[i, j].Value)
                            return false;

                return true;
            }

            return base.Equals(obj);
        }
    }
}