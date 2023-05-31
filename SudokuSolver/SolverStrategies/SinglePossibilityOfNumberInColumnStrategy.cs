using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityOfNumberInColumnStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle)
        {
            bool result = false;
            FastPencil.Apply(puzzle);
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
                            puzzle[i,j] = single;
                            result = true;
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
