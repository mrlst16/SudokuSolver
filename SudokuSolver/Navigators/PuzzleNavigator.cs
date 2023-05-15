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

        //public int[,] GetSquareOfPosition(int i, int j)
        //{
        //    if (i is >= 0 and <= 2)
        //    {
        //        switch (j)
        //        {
        //            case >= 0 and <= 2:
        //                return _puzzle.Board.GetSquare(0, 2, 0, 2);
        //            case >= 3 and <= 5:
        //                return _puzzle.Board.GetSquare(0, 2, 3, 5);
        //            case >= 6 and <= 8:
        //                return _puzzle.Board.GetSquare(0, 2, 6, 8);
        //        }
        //    }
        //    if (i is >= 3 and <= 5)
        //    {
        //        switch (j)
        //        {
        //            case >= 0 and <= 2:
        //                return _puzzle.Board.GetSquare(3, 5, 0, 2);
        //            case >= 3 and <= 5:
        //                return _puzzle.Board.GetSquare(3, 5, 3, 5);
        //            case >= 6 and <= 8:
        //                return _puzzle.Board.GetSquare(3, 5, 6, 8);
        //        }

        //    }
        //    if (i is >= 6 and <= 8)
        //    {
        //        switch (j)
        //        {
        //            case >= 0 and <= 2:
        //                return _puzzle.Board.GetSquare(6, 8, 0, 2);
        //            case >= 3 and <= 5:
        //                return _puzzle.Board.GetSquare(6, 8, 3, 5);
        //            case >= 6 and <= 8:
        //                return _puzzle.Board.GetSquare(6, 8, 6, 8);
        //        }
        //    }

        //    return j switch
        //    {
        //        >= 0 and <= 2 => _puzzle.Board
        //    };

        //    return null;
        //}

        public int[,] GetSquareOfPosition(int i, int j)
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

        public static implicit operator PuzzleNavigator(SudokuPuzzle puzzle)
            => new PuzzleNavigator(puzzle);

        public static implicit operator PuzzleNavigator(int[,] board)
            => new PuzzleNavigator(board);
    }
}