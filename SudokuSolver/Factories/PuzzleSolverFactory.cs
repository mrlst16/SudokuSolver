using SudokuSolver.Checkers;
using SudokuSolver.Models;
using SudokuSolver.Printers;
using SudokuSolver.Solvers;

namespace SudokuSolver.Factories
{
    public class PuzzleSolverFactory
    {
        public static PuzzleSolver CreateAllCellsInRangeStandardStrategies
            => new PuzzleSolver(
                new PuzzleChecker(),
                SolverStrategyFactory.SinglePossibilityPerCellStrategy,
                SolverStrategyFactory.SinglePossibilityPerNumberInRowStrategy,
                SolverStrategyFactory.SinglePossibilityOfNumberInColumnStrategy,
                SolverStrategyFactory.SinglePossibilityOfNumberInSquareStrategy,
                new StringPuzzlePrinter(),
                new PuzzleSolverOptions()
                {
                    MaxPasses = 200
                }
            );

        public static PuzzleSolver CreateAllCellsInRangeStandardStrategiesHtmlPrinter
            => new PuzzleSolver(
                new PuzzleChecker(),
                SolverStrategyFactory.SinglePossibilityPerCellStrategy,
                SolverStrategyFactory.SinglePossibilityPerNumberInRowStrategy,
                SolverStrategyFactory.SinglePossibilityOfNumberInColumnStrategy,
                SolverStrategyFactory.SinglePossibilityOfNumberInSquareStrategy,
                new HtmlPuzzlePrinter(),
                new PuzzleSolverOptions()
                {
                    MaxPasses = 200
                }
            );
    }
}
