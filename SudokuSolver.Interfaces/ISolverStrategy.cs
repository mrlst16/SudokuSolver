using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.Interfaces
{
    public interface ISolverStrategy
    {
        /// <summary>
        /// Cycles through and applies changes as dictated by the strategy
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>Whether or not the strategy made any changes</returns>
        bool Cycle(SudokuPuzzle puzzle, ref SudokuAnalytics analytics, bool initiateWithFastPencil = false);
    }
}
