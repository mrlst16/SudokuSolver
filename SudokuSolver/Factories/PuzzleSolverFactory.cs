using SudokuSolver.Checkers;
using SudokuSolver.Models;
using SudokuSolver.Printers;
using SudokuSolver.Solvers;
using SudokuSolver.SolverStrategies;

namespace SudokuSolver.Factories
{
    public class PuzzleSolverFactory
    {
        public static PuzzleSolver CreateAllCellsInRangeStandardStrategies
            => new PuzzleSolver(
                new PuzzleChecker(),
                SolverStrategyFactory.SinglePossibilityPerCellStrategy,
                SolverStrategyFactory.SinglePossibilityPerCellStrategy,
                SolverStrategyFactory.SinglePossibilityPerCellStrategy,
                SolverStrategyFactory.SinglePossibilityPerCellStrategy,
                new StringPuzzlePrinter(),
                new PuzzleSolverOptions()
                {
                    MaxPasses = 200
                }
            );
    }
}
