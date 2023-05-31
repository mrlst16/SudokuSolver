﻿using SudokuSolver.Models;
using SudokuSolver.SolverStrategies;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.SolverStrategies
{
    public class SinglePossibilityOfNumberInSquareStrategyTests
    {

        private SinglePossibilityOfNumberInSquareStrategy _strategy => new();

        #region Tests

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

        #endregion

        #region TestData

        public static List<object[]> Data()
            => new List<object[]>()
            {
                new object[]{}
            };

        #endregion
    }
}