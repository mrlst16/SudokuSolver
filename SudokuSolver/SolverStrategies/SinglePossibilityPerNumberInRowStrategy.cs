using Common.Extensions;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityPerNumberInRowStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle, ref SudokuAnalytics analytics, bool initiateWithFastPencil = false)
        {
            if (initiateWithFastPencil)
                FastPencil.Apply(puzzle);

            bool result = false;
            for (int i = 0; i < 9; i++)
            {
                Cell[] row = puzzle.Board.GetRow(i);
                var singles = row
                    .SelectMany(x => x.Possiblities)
                    .GroupBy(x => x)
                    .Where(x => x.Count() == 1)
                    .Select(x => x.Key);

                if (!singles.Any())
                    continue;
                foreach (int single in singles)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var cell = row[j];
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
                                Type = SolverStrategyType.SinglePossibilityOfNumberInRow
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
