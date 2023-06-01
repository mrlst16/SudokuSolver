using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleIterator
    {
        /// <summary>
        /// Iterates over the board as implemented
        /// </summary>
        /// <param name="board"></param>
        /// <param name="action">
        /// Action taking in a 2D array, the row position (i), the column position (j), and the value
        /// </param>
        void Iterate(ref int[,] board, Action<int[,], int, int, int> action);
    }
}
