using Common.Extensions;
using SudokuSolver.Models;

namespace SudokuSolver.Factories
{
    public class ByRowPuzzleFactory : PuzzleFactoryBase
    {
        public ByRowPuzzleFactory(
            PuzzleFactoryOptions options
            ) : base(options)
        {
        }

        protected override void Seed(ref int[,] board)
        {
            SeedByRow(ref board);
        }

        private bool CleanUp(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var row = board.GetRow(i);
                if (row.Contains(0))
                {
                    //board.SetValue();
                }
            }
            return false;
        }

    }
}
