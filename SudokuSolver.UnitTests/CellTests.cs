using SudokuSolver.Models;

namespace SudokuSolver.UnitTests
{
    public class CellTests
    {

        #region Tests

        [Theory]
        [MemberData(nameof(EqualsTest_ExpectTrue_TestData))]
        public void EqualsTest_ExpectTrue(
            Cell one,
            Cell two
        )
        {
            bool result = one.Equals(two);
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(EqualsTest_ExpectFalse_TestData))]
        public void EqualsTest_ExpectFalse(
            Cell one,
            Cell two
        )
        {
            bool result = one.Equals(two);
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(ImplicitConversionEqualsTestData))]
        public void ImplicitConversionEqualsTest(
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
            Cell[] array = new Cell[] { 1, 2, 3, 1 };
            bool result = array.HasUniqueValues();
            Assert.False(result);
        }

        #endregion

        #region Data

        [Fact]
        public static List<object[]> ImplicitConversionEqualsTestData()
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

        public static List<object[]> EqualsTest_ExpectTrue_TestData()
            => new List<object[]>()
            {
                new object[]
                {
                    new Cell(){ Value = 1, Possiblities = new List<int>(){ 1, 2, 3} },
                    new Cell(){ Value = 1, Possiblities = new List<int>(){ 1, 2, 3 } }
                },
                new object[]
                {
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ } },
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ } }
                },
                new object[]
                {
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ 1, 2, 3, 4, 5 } },
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ 1, 2, 3, 4, 5 } }
                },
            };

        public static List<object[]> EqualsTest_ExpectFalse_TestData()
            => new List<object[]>()
            {
                new object[]
                {
                    new Cell(){ Value = 1, Possiblities = new List<int>(){ 1} },
                    new Cell(){ Value = 1, Possiblities = new List<int>(){ } }
                },
                new object[]
                {
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ } },
                    new Cell(){ Value = 1, Possiblities = new List<int>(){ } }
                },
                new object[]
                {
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ 1, 2, 8, 9 } },
                    new Cell(){ Value = 0, Possiblities = new List<int>(){ 1, 6, 7 } }
                },
            };

        #endregion
    }
}
