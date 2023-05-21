using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Navigators;

namespace SudokuSolver.Factories
{
    public abstract class PuzzleFactoryBase : IPuzzleFactory
    {
        protected readonly PuzzleFactoryOptions _options;

        protected PuzzleFactoryBase(
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

        public virtual SudokuPuzzle Create()
        {
            int[,] board = new int[9, 9];
            int iterations = 0;
            while (
                (iterations < _options.TotalTries)
                && (!_options?.IsComplete(board) ?? false)
                )
            {
                Seed(ref board);
                iterations++;
            }

            return Create(board);
        }

        protected abstract void Seed(ref int[,] board);

        protected virtual int GenerateNumber(PuzzleNavigator navigator, int i, int j)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int selection = random.Next(1, 10);
            int counter = 0;

            while (
                counter < _options.TriesPerSquare
                &&
                (
                    !navigator.SelectionCanGoInRow(i, selection)
                    || !navigator.SelectionCanGoInColumn(j, selection)
                    || !navigator.SelectionCanGoInSquare(i, j, selection)
                )
            )
            {
                selection = random.Next(1, 10);
                counter++;
            }

            if (counter >= _options.TriesPerSquare)
                selection = 0;

            return selection;
        }

        protected virtual void SeedByRow(ref int[,] board)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    int currentValue = board[i, i];
                    if (currentValue < 0 || currentValue >= 9)
                        continue;
                    board[i, j] = GenerateNumber(board, i, j);
                }
        }

        protected virtual void SeedDiagonalsFromTopLeftToBottomRight(ref int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                int currentValue = board[i, i];
                if (currentValue < 0 || currentValue > 9)
                    continue;
                board[i, i] = GenerateNumber(board, i, i);
            }
        }

        protected virtual void SeedDiagonalsFromTopRightToBottomLeft(ref int[,] board)
        {
            for (int i = 8; i > 0; i--)
            {
                int currentValue = board[i, i];
                if (currentValue < 0 || currentValue >= 9)
                    continue;
                board[i, i] = GenerateNumber(board, i, i);
            }
        }
    }
}
