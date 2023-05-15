using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Navigators;

namespace SudokuSolver.Factories
{
    public class PuzzleFactory : IPuzzleFactory
    {

        public PuzzleFactoryOptions _options;

        public PuzzleFactory(
            PuzzleFactoryOptions options
            )
        {
            _options = options;
        }

        public SudokuPuzzle Create(int[,] board)
        {
            if (board == null)
                throw new ArgumentNullException("The board cannot be null");
            if (board.GetLength(0) != 9
               || board.GetLength(1) != 9)
                throw new ArgumentException("Dimensions must be 9 by 9");
            return new SudokuPuzzle(board);
        }

        public SudokuPuzzle Create()
        {
            int[,] board = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    board[i, j] = GenerateNumber(board, i, j);

            return Create(board);
        }

        private int GenerateNumber(PuzzleNavigator navigator, int i, int j)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int selection = random.Next(0, 10);
            int counter = 0;

            while (
                counter < _options.TriesPerSquare
                && !navigator.SelectionCanGoInRow(i, selection)
                && !navigator.SelectionCanGoInColumn(j, selection)
                && !navigator.SelectionCanGoInSquare(i, j, selection)
                )
            {
                selection = random.Next(0, 10);
                counter++;
            }

            if (counter >= _options.TriesPerSquare)
                throw new Exception("Cannot generate number here");

            return selection;
        }
    }
}
