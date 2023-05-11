using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Factories
{
    public class PuzzleFactory : IPuzzleFactory
    {
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
            throw new NotImplementedException();
        }
    }
}
