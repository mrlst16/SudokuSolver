using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            bool result = _checker.Check(MockPuzzleFactory.SolvedPuzzle);
            Assert.True(result);
        }

        [Fact]
        public void PuzzleI7J2Missing()
        {
            bool result = _checker.Check(MockPuzzleFactory.PuzzleI7J2Missing);
            Assert.False(result);
        }
    }
}
