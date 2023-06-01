using Common.Extensions;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Navigators;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityOfNumberInSquareStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle, bool initiateWithFastPencil = false)
        {
            if (initiateWithFastPencil)
                FastPencil.Apply(puzzle);

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
                        continue;

                    foreach (int single in singles)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            if (square[k].Possiblities.Contains(single))
                            {
                                (int txI, int txj) = PuzzleNavigator.PuzzleCoordinatesFromSquareList(i, j, k);
                                puzzle[txI, txj] = single;
                                FastPencil.Apply(puzzle);
                                result = true;
                                break;
                            }
                        }
                    }
                }

            return result;
        }
    }
}
