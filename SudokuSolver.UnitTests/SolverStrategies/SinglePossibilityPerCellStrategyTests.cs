using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;
using SudokuSolver.SolverStrategies;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.SolverStrategies
{
    public class SinglePossibilityPerCellStrategyTests
    {
        private SinglePossibilityPerCellStrategy _strategy => new();

        [Fact]
        public void PuzzleI7J2Missing_SomethingFound()
        {
            SudokuAnalytics analytics = new();
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle, ref analytics, true);
            Assert.True(result);
        }

        [Fact]
        public void PuzzleI7J2Missing_8Expected()
        {
            SudokuAnalytics analytics = new();
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;
            bool result = _strategy.Cycle(puzzle, ref analytics, true);
            Cell cell = puzzle[7, 2];
            Assert.Equal(8, cell.Value);
        }
    }
}
