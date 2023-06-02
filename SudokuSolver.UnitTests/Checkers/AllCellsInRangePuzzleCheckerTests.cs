using SudokuSolver.Checkers;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.Checkers
{
    public class AllCellsInRangePuzzleCheckerTests
    {
        private readonly AllCellsInRangePuzzleChecker _checker = new();

        [Fact]
        public void SolvedPuzzle()
        {
            bool result = _checker.Check(MockPuzzle.SolvedPuzzle);
            Assert.True(result);
        }

        [Fact]
        public void PuzzleI7J2Missing()
        {
            bool result = _checker.Check(MockPuzzle.PuzzleI7J2Missing);
            Assert.False(result);
        }
    }
}
