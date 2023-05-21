using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Interfaces;
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
