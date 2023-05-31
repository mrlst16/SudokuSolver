using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityPerNumberInRowStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle)
        {
            bool result = false;
            for (int i = 0; i <= 9; i++)
            {
                Cell[] row = puzzle.Board.GetRow(i);
                var singles = row
                    .SelectMany(x => x.Possiblities)
                    .GroupBy(x => x)
                    .Where(x => x.Count() == 1)
                    .Select(x => x.Key);

                if (!singles.Any())
                    return result;
                foreach (int single in singles)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var cell = row[j];
                        if (cell.Possiblities.Contains(single))
                        {
                            cell = single;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
