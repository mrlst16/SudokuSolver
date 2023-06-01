using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
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
        public void SolveOneMissing()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleI7J2Missing;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.SolvedPuzzle);
        }

        [Fact]
        public void SolveFirstRowMissing()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleRow0Missing;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.SolvedPuzzle);
        }

        [Fact]
        public void SolveFirstColumnMissing()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleColumn0Missing;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.SolvedPuzzle);
        }

        [Fact]
        public void SolveFirstSquareMissing()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.PuzzleSquare0Missing;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.SolvedPuzzle);
        }

        [Fact]
        public void SolveSporadicMissing()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.SporadicMissingPuzzle;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.SolvedPuzzle);
        }

        [Fact]
        public void SolveEasyLevelPuzzle()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.EasyLevelPuzzle1;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.EasyLevelPuzzle1Solution);
        }

        [Fact]
        public void SolveMediumLevelPuzzle()
        {
            IPuzzleSolver solver = PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategies;
            SudokuPuzzle puzzle = MockPuzzleFactory.HardLevelPuzzle1;

            solver.Solve(puzzle);
            Assert.Equal(puzzle, MockPuzzleFactory.HardLevelPuzzle1Solved);
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
                new object[]{ MockPuzzleFactory.HardLevelPuzzle1, MockPuzzleFactory.HardLevelPuzzle1Solved }
            };

        #endregion
    }
}