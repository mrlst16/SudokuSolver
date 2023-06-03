using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Parsers
{
    public class PuzzleParser : IPuzzleParser
    {
        public static IEnumerable<int> ExtractNumbers(string str)
            => str
            .Where(x => x.IsInRange() || x == '0')
            .Select(x => ((int) x) - 48);

        public SudokuPuzzle Parse(string str)
        {
            if (str.None())
                throw new ArgumentException("string is empty");

            SudokuPuzzle result = new();
            IEnumerable<int> numbers = ExtractNumbers(str);

            if (numbers.None() || numbers.Count() != 81)
                throw new ArgumentException("string should contain 81 numbers");

            for (int i = 0; i < 9; i++)
            {
                IEnumerable<int> row = numbers
                    .Skip(i * 9)
                    .Take(9);

                for (int j = 0; j < 9; j++)
                {
                    result[i, j] = row.ElementAt(j);
                }
            }
            return result;
        }
    }
}
