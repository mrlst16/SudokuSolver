﻿using SudokuSolver.Models;
using SudokuSolver.SolverStrategies;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.SolverStrategies
{
    public class SinglePossibilityOfNumberInColumnStrategyTests
    {
        private SinglePossibilityOfNumberInColumnStrategy _strategy => new();

        [Fact]
        public void PuzzleI7J2Missing_SomethingFound()
        {
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle, true);
            Assert.True(result);
        }

        [Fact]
        public void PuzzleI7J2Missing_8Expected()
        {
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle, true);
            Cell cell = puzzle[7, 2];
            Assert.Equal(8, cell.Value);
        }
    }
}