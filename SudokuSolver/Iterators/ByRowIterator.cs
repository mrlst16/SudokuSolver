using SudokuSolver.Interfaces;

namespace SudokuSolver.Iterators
{
    public class ByRowIterator : IPuzzleIterator
    {
        public void Iterate(ref int[,] board, Action<int[,], int, int, int> action)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    action(board, i, j, board[i, j]);
        }
    }
}
