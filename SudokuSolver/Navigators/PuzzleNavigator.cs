using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using System.Linq;

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
            => i switch
            {
                >= 0 and <= 2
                    => j switch
                    {
                        >= 0 and <= 2 => _puzzle.Board.GetSquare(0, 2, 0, 2),
                        >= 3 and <= 5 => _puzzle.Board.GetSquare(0, 2, 3, 5),
                        >= 6 and <= 8 => _puzzle.Board.GetSquare(0, 2, 6, 8)
                    },
                >= 3 and <= 5
                    => j switch
                    {
                        >= 0 and <= 2 => _puzzle.Board.GetSquare(3, 5, 0, 2),
                        >= 3 and <= 5 => _puzzle.Board.GetSquare(3, 5, 3, 5),
                        >= 6 and <= 8 => _puzzle.Board.GetSquare(3, 5, 6, 8)
                    },
                >= 6 and <= 8
                    => j switch
                    {
                        >= 0 and <= 2 => _puzzle.Board.GetSquare(6, 8, 0, 2),
                        >= 3 and <= 5 => _puzzle.Board.GetSquare(6, 8, 3, 5),
                        >= 6 and <= 8 => _puzzle.Board.GetSquare(6, 8, 6, 8)
                    }
            };

        public bool SelectionCanGoInRow(int i, int selection)
            => !_puzzle.Board.GetRow(i).Contains(x=> x == selection);

        public bool SelectionCanGoInColumn(int j, int selection)
            => !_puzzle.Board
                .GetColumn(j)
                .Contains(x=>  x==selection);

        public bool SelectionCanGoInSquare(int i, int j, int selection)
            => !GetSquareOfPosition(i, j)
                .Flatten()
                .Contains(x=> x == selection);

        public static implicit operator PuzzleNavigator(SudokuPuzzle puzzle)
            => new PuzzleNavigator(puzzle);

        public static implicit operator PuzzleNavigator(int[,] board)
            => new PuzzleNavigator(board);

        public static implicit operator PuzzleNavigator(Cell[,] board)
            => new PuzzleNavigator(board);
    }
}