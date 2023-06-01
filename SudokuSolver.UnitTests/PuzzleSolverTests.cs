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
    }
}