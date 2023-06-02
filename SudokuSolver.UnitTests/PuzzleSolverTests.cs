using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;
using SudokuSolver.Printers;
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
            SudokuPuzzle puzzle = MockPuzzleFactory.MediumLevelPuzzle1;

            SudokuAnalytics result = solver.Solve(puzzle);

            Assert.Equal(puzzle, MockPuzzleFactory.MediumLevelPuzzle1Solution);
        }

        [Fact]
        public void SolveHardLevelPuzzle()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.HardLevelPuzzle1;

            solver.Solve(puzzle);

            SudokuAnalytics result = solver.Solve(puzzle);

            Assert.Equal(puzzle, MockPuzzleFactory.HardLevelPuzzle1Solution);
        }

        #endregion

        #region Test Data

        public static List<object[]> SolveData()
            => new List<object[]>()
            {
                new object[]{ MockPuzzleFactory.PuzzleI7J2Missing, MockPuzzleFactory.SolvedPuzzle },
                new object[]{ MockPuzzleFactory.PuzzleRow0Missing, MockPuzzleFactory.SolvedPuzzle },
                new object[]{ MockPuzzleFactory.PuzzleColumn0Missing, MockPuzzleFactory.SolvedPuzzle },
                new object[]{ MockPuzzleFactory.PuzzleSquare0Missing, MockPuzzleFactory.SolvedPuzzle },
                new object[]{ MockPuzzleFactory.EasyLevelPuzzle1, MockPuzzleFactory.EasyLevelPuzzle1Solution },
                new object[]{ MockPuzzleFactory.HardLevelPuzzle1, MockPuzzleFactory.HardLevelPuzzle1Solution },
                new object[]{ MockPuzzleFactory.MediumLevelPuzzle1, MockPuzzleFactory.MediumLevelPuzzle1Solution }
            };

        #endregion
    }
}