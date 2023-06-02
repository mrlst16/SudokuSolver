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
        public static string CommaDelimited
            => MockPuzzle.SolvedPuzzle
                .Board.Flatten()
                .Select(x=> x.Value.ToString())
                .Aggregate((x, y)=> $"{x}, {y}");
    }
}
