using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Models;
using SudokuSolver.Parsers;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.Parsers
{
    public class PuzzleParserTests
    {
        #region Tests
        [Theory]
        [MemberData(nameof(ParseTestData))]
        public void ParseTest(
            string input,
            SudokuPuzzle expected
            )
        {
            PuzzleParser parser = new();
            SudokuPuzzle result = parser.Parse(input);
            Assert.Equal(expected, result);
        }
        #endregion

        #region TestData

        public static List<object[]> ParseTestData()
            => new List<object[]>()
            {
                new object[]{ MockParsingInput.CommaDelimited, MockPuzzle.SolvedPuzzle }
            };
        #endregion
    }
}
