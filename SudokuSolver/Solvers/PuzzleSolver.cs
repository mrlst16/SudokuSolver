using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Navigators;
using SudokuSolver.SolverStrategies;

namespace SudokuSolver.Solvers
{
    public class PuzzleSolver : IPuzzleSolver
    {
        private readonly IPuzzleChecker _checker;
        private readonly PuzzleSolverOptions _options;

        private readonly ISolverStrategy _singlePossibilityPerCellStrategy;
        private readonly ISolverStrategy _singlePossibilityOfNumberInRowStrategy;
        private readonly ISolverStrategy _singlePossibilityOfNumberInColumnStrategy;
        private readonly ISolverStrategy _singlePossibilityOfNumberInSquareStrategy;

        public PuzzleSolver(
            IPuzzleChecker checker,
            ISolverStrategy singlePossibilityPerCellStrategy,
            ISolverStrategy singlePossibilityOfNumberInRowStrategy,
            ISolverStrategy singlePossibilityOfNumberInColumnStrategy,
            ISolverStrategy singlePossibilityOfNumberInSquareStrategy,
            PuzzleSolverOptions options
        )
        {
            _checker = checker;
            _options = options;

            _singlePossibilityPerCellStrategy = singlePossibilityPerCellStrategy;
            _singlePossibilityOfNumberInRowStrategy = singlePossibilityOfNumberInRowStrategy;
            _singlePossibilityOfNumberInColumnStrategy = singlePossibilityOfNumberInColumnStrategy;
            _singlePossibilityOfNumberInSquareStrategy = singlePossibilityOfNumberInSquareStrategy;
        }

        public PuzzleSolver(
            IPuzzleChecker checker,
            PuzzleSolverOptions options
        ) : this(
            checker,
            SolverStrategyFactory.SinglePossibilityPerCellStrategy,
            SolverStrategyFactory.SinglePossibilityPerCellStrategy,
            SolverStrategyFactory.SinglePossibilityPerCellStrategy,
            SolverStrategyFactory.SinglePossibilityPerCellStrategy,
            options
            )
        {
        }

        public SudokuPuzzle Solve(SudokuPuzzle puzzle)
        {
            int passes = 0;
            while (
                passes < _options.MaxPasses
                && !_checker.Check(puzzle)
                && (
                    _singlePossibilityPerCellStrategy.Cycle(puzzle)
                    || _singlePossibilityOfNumberInRowStrategy.Cycle(puzzle)
                    || _singlePossibilityOfNumberInColumnStrategy.Cycle(puzzle)
                    || _singlePossibilityOfNumberInSquareStrategy.Cycle(puzzle)
                    )
                )
            {
                passes++;
            }
            return puzzle;
        }

    }
}
