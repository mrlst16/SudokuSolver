using Common.Extensions;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Solvers;

namespace SudokuSolver.SolverStrategies
{
    public class SinglePossibilityPerCellStrategy : ISolverStrategy
    {
        public bool Cycle(SudokuPuzzle puzzle)
        {
            FastPencil.Apply(puzzle);
            bool result = false;
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++)
                {
                    Cell cell = puzzle[i, j];

                    if (
                        cell.Value.IsInRange()
                        || cell.Possiblities.Count != 1
                    )
                        continue;

                    puzzle[i, j] = cell.Value;
                    result = true;
                    FastPencil.Apply(puzzle);
                }
            return result;
        }
    }
}
