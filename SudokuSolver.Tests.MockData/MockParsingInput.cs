using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;

namespace SudokuSolver.Tests.MockData
{
    public static class MockParsingInput
    {
        public static string CommaDelimitedOfSolvedPuzzle
            => MockPuzzle.SolvedPuzzle
                .Board.Flatten()
                .Select(x => x.Value.ToString())
                .Aggregate((x, y) => $"{x}, {y}");

        public static string CommaDelimitedOfEasyLevelPuzzle1
            => MockPuzzle.EasyLevelPuzzle1
                .Board.Flatten()
                .Select(x => x.Value.ToString())
                .Aggregate((x, y) => $"{x}, {y}");
    }
}
