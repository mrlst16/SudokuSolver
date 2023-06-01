using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests
{
    public class PuzzleSolverTests
    {

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
    }
}