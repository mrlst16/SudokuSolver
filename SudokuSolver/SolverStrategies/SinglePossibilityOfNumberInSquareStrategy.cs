using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Navigators;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityOfNumberInSquareStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle)
        {
            bool result = false;
            for (int i = 0; i < 9; i += 3)
                for (int j = 0; j < 9; j += 3)
                { 
                    Cell[] square = PuzzleNavigator
                        .GetSquareOfPosition(puzzle, i, j)
                        .Flatten();
                    
                    var singles = square
                        .SelectMany(x => x.Possiblities)
                        .GroupBy(x => x)
                        .Where(x => x.Count() == 1)
                        .Select(x => x.Key);

                    if (!singles.Any())
                        return result;
                    foreach (int single in singles)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            var cell = square[k];
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
