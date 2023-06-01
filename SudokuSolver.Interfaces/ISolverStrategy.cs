using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface ISolverStrategy
    {
        /// <summary>
        /// Cycles through and applies changes as dictated by the strategy
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>Whether or not the strategy made any changes</returns>
        bool Cycle(SudokuPuzzle  puzzle, bool initiateWithFastPencil = false);
    }
}
