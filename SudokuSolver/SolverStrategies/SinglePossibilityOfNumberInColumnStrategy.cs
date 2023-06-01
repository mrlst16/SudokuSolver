using Common.Extensions;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityOfNumberInColumnStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle, ref SudokuAnalytics analytics, bool initiateWithFastPencil = false)
        {
            if (initiateWithFastPencil)
                FastPencil.Apply(puzzle);

            bool result = false;
            for (int j = 0; j < 9; j++)
            {
                Cell[] column = puzzle.Board.GetColumn(j);
                var singles = column
                    .SelectMany(x => x.Possiblities)
                    .GroupBy(x => x)
                    .Where(x => x.Count() == 1)
                    .Select(x => x.Key);

                if (!singles.Any())
                    continue;
                foreach (int single in singles)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        var cell = column[i];
                        if (cell.Possiblities.Contains(single))
                        {
                            puzzle[i, j] = single;
                            result = true;
                            analytics.Moves.Add(new Move()
                            {
                                I = i,
                                J = j,
                                Order = analytics.Moves.Count(),
                                Value = single,
                                Type = SolverStrategyType.SinglePossibilityOfNumberInColumn
                            });
                            FastPencil.Apply(puzzle);
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
