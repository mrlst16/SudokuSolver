using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;
using SudokuSolver.Printers;
using SudokuSolver.SolverStrategies;

namespace SudokuSolver.Solvers
{
    public class PuzzleSolver : IPuzzleSolver
    {
        private readonly IPuzzleChecker _checker;
        private readonly PuzzleSolverOptions _options;
        private readonly IPuzzlePrinter _printer;
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
            IPuzzlePrinter printer,
            PuzzleSolverOptions options
        )
        {
            _checker = checker;
            _options = options;
            _printer = printer;
            _singlePossibilityPerCellStrategy = singlePossibilityPerCellStrategy;
            _singlePossibilityOfNumberInRowStrategy = singlePossibilityOfNumberInRowStrategy;
            _singlePossibilityOfNumberInColumnStrategy = singlePossibilityOfNumberInColumnStrategy;
            _singlePossibilityOfNumberInSquareStrategy = singlePossibilityOfNumberInSquareStrategy;
        }

        public SudokuAnalytics Solve(SudokuPuzzle puzzle)
        {
            int passes = 0;
            bool keepGoing = true;
            FastPencil.Apply(puzzle);
            SudokuAnalytics result = new();

            do
            {
                bool underPasses = passes < _options.MaxPasses;
                bool check = _checker.Check(puzzle);
                bool perCell = _singlePossibilityPerCellStrategy.Cycle(puzzle, ref result, true);
                bool perRow = _singlePossibilityOfNumberInRowStrategy.Cycle(puzzle, ref result, true);
                bool perColumn = _singlePossibilityOfNumberInColumnStrategy.Cycle(puzzle, ref result, true);
                bool perSquare = _singlePossibilityOfNumberInSquareStrategy.Cycle(puzzle, ref result, true);
                passes++;

                keepGoing = !underPasses
                                && !check
                                || (
                                    perCell
                                    || perRow
                                    || perColumn
                                    || perSquare
                                );
            } while (keepGoing);

            result.TotalPasses = passes;
            result.StringRepresentation = _printer.Print(puzzle);
            result.Result = puzzle;
            return result;
        }


    }
}