using SudokuSolver.Models;

namespace SudokuSolver.Factories
{
    public class BySquarePuzzleFactory : PuzzleFactoryBase
    {
        public BySquarePuzzleFactory(PuzzleFactoryOptions options) : base(options)
        {
        }

        protected override void Seed(ref int[,] board)
        {

        }
    }
}
