using System.Collections;
using Common.Extensions;
using SudokuSolver.Models;

namespace SudokuSolver.UnitTests
{
    public class CellTests
    {

        #region Tests
        [Theory]
        [MemberData(nameof(EqualsTestData))]
        public void EqualsTest(
            int expected
            )
        {
            Cell cell = expected;
            bool result = cell.Equals(expected);
            Assert.True(result);
        }

        [Fact]
        public void HasUniqueValues_NonUniqueData()
        {
            Cell[] array = new Cell[]{ 1, 2, 3, 1 };
            bool result = array.HasUniqueValues();
            Assert.False(result);
        }

        #endregion

        #region Data

        [Fact]
        public static List<object[]> EqualsTestData()
            => new List<object[]>()
            {
                new object[]{ 1 },
                new object[]{ 2 },
                new object[]{ 3 },
                new object[]{ 4 },
                new object[]{ 5 },
                new object[]{ 6 },
                new object[]{ 7 },
                new object[]{ 8 },
                new object[]{ 9 },
            };

        #endregion
    }
}
