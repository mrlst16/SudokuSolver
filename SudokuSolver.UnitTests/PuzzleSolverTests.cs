using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests
{
    public class PuzzleSolverTests
    {
        #region Tests

        [Theory]
        [MemberData(nameof(SolveData))]
        public static void Solve(
            SudokuPuzzle puzzle,
            SudokuPuzzle solution
        )
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            solver.Solve(puzzle);
            Assert.Equal(puzzle, solution);
        }

        [Fact]
        public void SolveMediumLevelPuzzle()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategiesHtmlPrinter;
            SudokuPuzzle puzzle = MockPuzzle.MediumLevelPuzzle1;

            SudokuAnalytics result = solver.Solve(puzzle);

            Assert.Equal(puzzle, MockPuzzle.MediumLevelPuzzle1Solution);
        }

        [Fact]
        public void SolveHardLevelPuzzle()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzle.HardLevelPuzzle1;

            solver.Solve(puzzle);

            SudokuAnalytics result = solver.Solve(puzzle);

            Assert.Equal(puzzle, MockPuzzle.HardLevelPuzzle1Solution);
        }

        #endregion

        #region Test Data

        public static List<object[]> SolveData()
            => new List<object[]>()
            {
                new object[]{ MockPuzzle.PuzzleI7J2Missing, MockPuzzle.SolvedPuzzle },
                new object[]{ MockPuzzle.PuzzleRow0Missing, MockPuzzle.SolvedPuzzle },
                new object[]{ MockPuzzle.PuzzleColumn0Missing, MockPuzzle.SolvedPuzzle },
                new object[]{ MockPuzzle.PuzzleSquare0Missing, MockPuzzle.SolvedPuzzle },
                new object[]{ MockPuzzle.EasyLevelPuzzle1, MockPuzzle.EasyLevelPuzzle1Solution },
                new object[]{ MockPuzzle.HardLevelPuzzle1, MockPuzzle.HardLevelPuzzle1Solution },
                new object[]{ MockPuzzle.MediumLevelPuzzle1, MockPuzzle.MediumLevelPuzzle1Solution }
            };

        #endregion
    }
}