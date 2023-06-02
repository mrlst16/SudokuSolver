using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityPerCellStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle, ref SudokuAnalytics analytics, bool initiateWithFastPencil = false)
        {
            if (initiateWithFastPencil)
                FastPencil.Apply(puzzle);

            bool result = false;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    Cell cell = puzzle[i, j];

                    if (
                        cell.Value.IsInRange()
                        || cell.Possiblities.Count != 1
                    )
                        continue;

                    puzzle[i, j] = cell.Possiblities.First();
                    result = true;
                    analytics.Moves.Add(new Move()
                    {
                        I = i,
                        J = j,
                        Order = analytics.Moves.Count(),
                        Value = puzzle[i, j].Value,
                        Type = SolverStrategyType.SinglePossibilityPerCell
                    });
                    FastPencil.Apply(puzzle);
                }
            return result;
        }
    }
}
