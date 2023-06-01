using SudokuSolver.Models;

namespace SudokuSolver.Factories
{
    public class DiagonalCrossPuzzleFactory : PuzzleFactoryBase
    {
        public DiagonalCrossPuzzleFactory(PuzzleFactoryOptions options) : base(options)
        {
        }

        protected override void Seed(ref int[,] board)
        {
            SeedDiagonalsFromTopLeftToBottomRight(ref board);
            SeedDiagonalsFromTopRightToBottomLeft(ref board);
            SeedByRow(ref board);
        }
    }
}
