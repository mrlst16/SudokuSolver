using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Printers
{
    public class StringPuzzlePrinter : IPuzzlePrinter
    {
        public string Print(SudokuPuzzle puzzle)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    builder.Append(puzzle[i, j].Value);
                    builder.Append(' ');
                }
                builder.Append('\n');
            }
            return builder.ToString();
        }
    }
}
