﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Models;

namespace SudokuSolver.Interfaces
{
    public interface IPuzzleSolver
    {
        SudokuPuzzle Solve(SudokuPuzzle  puzzle);
    }
}
