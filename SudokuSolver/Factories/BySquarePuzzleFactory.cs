using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
