namespace SudokuSolver.Models
{
    public class SudokuPuzzle
    {
        private int[,] _board = new int[9, 9];

        public SudokuPuzzle(int[,] board)
        {
            _board = board;
        }
    }
}