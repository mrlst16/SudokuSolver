using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Checkers;
using SudokuSolver.Models;
using SudokuSolver.Solvers;

namespace SudokuSolver.Factories
{
    public class PuzzleSolverFactory
    {
        public static PuzzleSolver CreateAllCellsInRangeStandardStrategies
            => new PuzzleSolver(
                new PuzzleChecker(),
                new PuzzleSolverOptions()
                {
                    MaxPasses = 200
                }
            );
    }
}
