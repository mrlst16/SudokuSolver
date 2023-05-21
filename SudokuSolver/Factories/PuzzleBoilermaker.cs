using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Factories
{
    public static class PuzzleBoilermaker
    {
        public enum PuzzleFactoryStrategy
        {
            ByRow = 1,
            DiagonalCross = 2
        }

        public static IPuzzleFactory Get(
            PuzzleFactoryStrategy strategy,
            PuzzleFactoryOptions options = null
        )
        {
            options ??= new PuzzleFactoryOptions()
            {
                TotalTries = 100,
                TriesPerSquare = 100,
                IsComplete = board => false
            };
            return strategy switch
            {
                PuzzleFactoryStrategy.ByRow => new ByRowPuzzleFactory(options),
                PuzzleFactoryStrategy.DiagonalCross => new DiagonalCrossPuzzleFactory(options)
            };
        }
    }
}
