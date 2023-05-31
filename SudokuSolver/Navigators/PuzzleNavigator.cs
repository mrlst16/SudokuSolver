using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Navigators
{
    public class PuzzleNavigator : IPuzzleNavigator
    {
        private readonly SudokuPuzzle _puzzle;

        internal PuzzleNavigator(
            SudokuPuzzle puzzle
            )
        {
            _puzzle = puzzle;
        }

        public int this[int i, int j]
        {
            get => _puzzle[i, j];
            set => _puzzle[i, j] = value;
        }

        public Cell[,] GetSquareOfPosition(int i, int j)
            => GetSquareOfPosition(_puzzle.Board, i, j);

        public static Cell[,] GetSquareOfPosition(Cell[,] board, int i, int j)
            => i switch
            {
                >= 0 and <= 2
                    => j switch
                    {
                        >= 0 and <= 2 => board.GetSquare(0, 2, 0, 2),
                        >= 3 and <= 5 => board.GetSquare(0, 2, 3, 5),
                        >= 6 and <= 8 => board.GetSquare(0, 2, 6, 8)
                    },
                >= 3 and <= 5
                    => j switch
                    {
                        >= 0 and <= 2 => board.GetSquare(3, 5, 0, 2),
                        >= 3 and <= 5 => board.GetSquare(3, 5, 3, 5),
                        >= 6 and <= 8 => board.GetSquare(3, 5, 6, 8)
                    },
                >= 6 and <= 8
                    => j switch
                    {
                        >= 0 and <= 2 => board.GetSquare(6, 8, 0, 2),
                        >= 3 and <= 5 => board.GetSquare(6, 8, 3, 5),
                        >= 6 and <= 8 => board.GetSquare(6, 8, 6, 8)
                    }
            };

        public static int[,] GetSquareOfPosition(int[,] board, int i, int j)
            => i switch
            {
                >= 0 and <= 2
                    => j switch
                    {
                        >= 0 and <= 2 => board.GetSquare(0, 2, 0, 2),
                        >= 3 and <= 5 => board.GetSquare(0, 2, 3, 5),
                        >= 6 and <= 8 => board.GetSquare(0, 2, 6, 8)
                    },
                >= 3 and <= 5
                    => j switch
                    {
                        >= 0 and <= 2 => board.GetSquare(3, 5, 0, 2),
                        >= 3 and <= 5 => board.GetSquare(3, 5, 3, 5),
                        >= 6 and <= 8 => board.GetSquare(3, 5, 6, 8)
                    },
                >= 6 and <= 8
                    => j switch
                    {
                        >= 0 and <= 2 => board.GetSquare(6, 8, 0, 2),
                        >= 3 and <= 5 => board.GetSquare(6, 8, 3, 5),
                        >= 6 and <= 8 => board.GetSquare(6, 8, 6, 8)
                    }
            };

        public bool SelectionCanGoInRow(int i, int selection)
            => !_puzzle.Board.GetRow(i).Contains(x => x == selection);

        public bool SelectionCanGoInColumn(int j, int selection)
            => !_puzzle.Board
                .GetColumn(j)
                .Contains(x => x == selection);

        public bool SelectionCanGoInSquare(int i, int j, int selection)
            => !GetSquareOfPosition(_puzzle.Board, i, j)
                .Flatten()
                .Contains(x => x == selection);

        public static bool SelectionCanGoInSquare(Cell[,] board, int i, int j, int selection)
            => !GetSquareOfPosition(board, i, j)
                .Flatten()
                .Contains(x => x == selection);

        public static List<int> GetPossibleValues(Cell[,] board, int i, int j)
        {
            List<Cell> inUse = new List<Cell>();
            List<int> result = new List<int>();
            int cellValue = board[i, j];
            if (cellValue.IsInRange())
                return result;

            inUse.AddRange(board.GetRow(i));
            inUse.AddRange(board.GetColumn(j));
            inUse.AddRange(PuzzleNavigator.GetSquareOfPosition(board, i, j).Flatten());

            IEnumerable<int> distinctInUse = inUse.Select(x => x.Value).Distinct();

            for (int k = 1; k <= 9; k++)
                if (!distinctInUse.Contains(k))
                    result.Add(k);

            return result;
        }

        public static (int, int) PuzzleCoordinatesFromSquareList(int i, int j, int k)
            => k switch
            {
                0 => (i, j),
                1 => (i, j + 1),
                2 => (i, j + 2),
                3 => (i + 1, j),
                4 => (i + 1, j + 1),
                5 => (i + 1, j + 2),
                6 => (i + 2, j),
                7 => (i + 2, j + 1),
                8 => (i + 2, j + 2),
            };

        public static implicit operator PuzzleNavigator(SudokuPuzzle puzzle)
            => new PuzzleNavigator(puzzle);

        public static implicit operator PuzzleNavigator(int[,] board)
            => new PuzzleNavigator(board);

        public static implicit operator PuzzleNavigator(Cell[,] board)
            => new PuzzleNavigator(board);
    }
}