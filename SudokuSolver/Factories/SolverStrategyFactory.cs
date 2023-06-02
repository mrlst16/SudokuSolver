using SudokuSolver.SolverStrategies;

namespace SudokuSolver.Factories
{
    public class SolverStrategyFactory
    {
        public static SinglePossibilityPerCellStrategy SinglePossibilityPerCellStrategy
        {
            get => new SinglePossibilityPerCellStrategy();
        }

        public static SinglePossibilityPerNumberInRowStrategy SinglePossibilityPerNumberInRowStrategy
        {
            get => new SinglePossibilityPerNumberInRowStrategy();
        }

        public static SinglePossibilityOfNumberInColumnStrategy SinglePossibilityOfNumberInColumnStrategy
        {
            get => new SinglePossibilityOfNumberInColumnStrategy();
        }

        public static SinglePossibilityOfNumberInSquareStrategy SinglePossibilityOfNumberInSquareStrategy
        {
            get => new SinglePossibilityOfNumberInSquareStrategy();
        }
    }
}
