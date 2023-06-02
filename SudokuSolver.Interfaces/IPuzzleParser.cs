using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleParser
    {
        SudokuPuzzle Parse(string str);
    }
}
