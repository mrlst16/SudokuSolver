using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Checkers
{
    public class AllCellsInRangePuzzleChecker : IPuzzleChecker
    {
        public bool Check(Cell[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (!board[i, j].IsInRange())
                        return false;
            return true;
        }
    }
}