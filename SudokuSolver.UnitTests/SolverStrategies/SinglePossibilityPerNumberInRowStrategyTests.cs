using SudokuSolver.Models;
using SudokuSolver.SolverStrategies;
using SudokuSolver.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.UnitTests.SolverStrategies
{
    public class SinglePossibilityPerNumberInRowStrategyTests
    {
        private SinglePossibilityPerNumberInRowStrategy _strategy => new();

        [Fact]
        public void PuzzleI7J2Missing_SomethingFound()
        {
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle);
            Assert.True(result);
        }

        [Fact]
        public void PuzzleI7J2Missing_8Expected()
        {
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle);
            Cell cell = puzzle[7, 2];
            Assert.Equal(8, cell.Value);
        }
    }
}
