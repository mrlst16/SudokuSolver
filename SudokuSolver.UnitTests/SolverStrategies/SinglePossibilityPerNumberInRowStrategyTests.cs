using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;
using SudokuSolver.SolverStrategies;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.SolverStrategies
{
    public class SinglePossibilityPerNumberInRowStrategyTests
    {
        private SinglePossibilityPerNumberInRowStrategy _strategy => new();

        [Fact]
        public void PuzzleI7J2Missing_SomethingFound()
        {
            SudokuAnalytics analytics = new();
            SudokuPuzzle puzzle = MockPuzzle.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle, ref analytics, true);
            Assert.True(result);
        }

        [Fact]
        public void PuzzleI7J2Missing_8Expected()
        {
            SudokuAnalytics analytics = new();
            SudokuPuzzle puzzle = MockPuzzle.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle, ref analytics, true);
            Cell cell = puzzle[7, 2];
            Assert.Equal(8, cell.Value);
        }


        [Fact]
        public void Test()
        {
            SudokuAnalytics analytics = new();
            SudokuPuzzle puzzle = MockPuzzle.EasyLevelPuzzle1After11Moves;
            bool result = _strategy.Cycle(puzzle, ref analytics, true);
            Cell cell = puzzle[8, 7];
            Assert.Equal(2, cell.Value);
        }
    }
}
