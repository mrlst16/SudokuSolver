﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class PuzzleFactoryOptions
    {
        public int TriesPerSquare { get; set; }
        public int TotalTries { get; set; } = 100;
        public Func<int[,], bool> IsComplete { get; set; }
    }
}