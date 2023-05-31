using SudokuSolver.Models;
using SudokuSolver.Navigators;

namespace SudokuSolver.UnitTests
{
    public class PuzzleNavigatorTests
    {
        private static Cell[,] NineByNine => new Cell[9, 9]
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        private static Cell[,] NineByNineOnlySquare1FilledOut => new Cell[9, 9]
        {
            { 1, 2, 3, 0, 0, 0, 0, 0, 0 },
            { 4, 5, 6, 0, 0, 0, 0, 0, 0 },
            { 7, 8, 9, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        private static Cell[,] Square1 => new Cell[3, 3]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        private static Cell[,] Square2 => new Cell[3, 3]
        {
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 1, 2, 3 }
        };

        private static Cell[,] Square3 => new Cell[3, 3]
        {
            { 7, 8, 9 },
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        private static Cell[,] Square4 => new Cell[3, 3]
        {
            { 2, 3, 4 },
            { 5, 6, 7 },
            { 8, 9, 1 }
        };

        private static Cell[,] Square5 => new Cell[3, 3]
        {
            { 5, 6, 7 },
            { 8, 9, 1 },
            { 2, 3, 4 }
        };

        private static Cell[,] Square6 => new Cell[3, 3]
        {
            { 8, 9, 1 },
            { 2, 3, 4 },
            { 5, 6, 7 }
        };

        private static Cell[,] Square7 => new Cell[3, 3]
        {
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 9, 1, 2 }
        };

        private static Cell[,] Square8 => new Cell[3, 3]
        {
            { 6, 7, 8 },
            { 9, 1, 2 },
            { 3, 4, 5 }
        };

        private static Cell[,] Square9 => new Cell[3, 3]
        {
            { 9, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };

        #region Tests
        [Theory]
        [MemberData(nameof(GetSquareByPositionTestData))]
        public void GetSquareByPositionTheory(
            int i,
            int j,
            Cell[,] expected
        )
        {
            PuzzleNavigator navigator = NineByNine;
            Cell[,] result = navigator.GetSquareOfPosition(i, j);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(SelectionCanGoInRowTheory_ExpectingFalse_TestData))]
        public void SelectionCanGoInRowTheory_ExpectingFalse(
            int i,
            int selection
        )
        {
            PuzzleNavigator navigator = NineByNine;
            bool result = navigator.SelectionCanGoInRow(i, selection);
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(SelectionCanGoInRowTheory_ExpectingTrue_TestData))]
        public void SelectionCanGoInRowTheory_ExpectingTrue(
            int i,
            int selection
        )
        {
            PuzzleNavigator navigator = NineByNineOnlySquare1FilledOut;
            bool result = navigator.SelectionCanGoInRow(i, selection);
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(GetPossibleValuesTheoryTestData))]
        public void GetPossibleValuesTheory(
            Cell[,] board,
            int i,
            int j,
            List<int> expected
            )
        {
            List<int> result = PuzzleNavigator.GetPossibleValues(board, i, j);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(PuzzleCoordinatesFromSquareListTheoryTestData))]
        public void PuzzleCoordinatesFromSquareListTheory(
            int i,
            int j,
            int k,
            (int x, int y) expected
            )
        {
            (int rx, int ry) = PuzzleNavigator.PuzzleCoordinatesFromSquareList(i, j, k);
            Assert.Equal(expected.x, rx);
            Assert.Equal(expected.y, ry);
        }

        #endregion

        #region TestData

        public static List<object[]> GetSquareByPositionTestData()
            => new List<object[]>()
            {
                //Square 1
                new object []{ 0, 0, Square1},
                new object []{ 1, 0, Square1},
                new object []{ 2, 0, Square1},
                new object []{ 0, 1, Square1},
                new object []{ 1, 1, Square1},
                new object []{ 2, 1, Square1},
                new object []{ 0, 2, Square1},
                new object []{ 1, 2, Square1},
                new object []{ 2, 2, Square1},
                //Square 2
                new object []{ 0, 3, Square2},
                new object []{ 1, 3, Square2},
                new object []{ 2, 3, Square2},
                new object []{ 0, 4, Square2},
                new object []{ 1, 4, Square2},
                new object []{ 2, 4, Square2},
                new object []{ 0, 5, Square2},
                new object []{ 1, 5, Square2},
                new object []{ 2, 5, Square2},
                //Square 3
                new object []{ 0, 6, Square3},
                new object []{ 1, 6, Square3},
                new object []{ 2, 6, Square3},
                new object []{ 0, 7, Square3},
                new object []{ 1, 7, Square3},
                new object []{ 2, 7, Square3},
                new object []{ 0, 8, Square3},
                new object []{ 1, 8, Square3},
                new object []{ 2, 8, Square3},
                //Square 4
                new object []{ 3, 0, Square4},
                new object []{ 4, 0, Square4},
                new object []{ 5, 0, Square4},
                new object []{ 3, 1, Square4},
                new object []{ 4, 1, Square4},
                new object []{ 5, 1, Square4},
                new object []{ 3, 2, Square4},
                new object []{ 4, 2, Square4},
                new object []{ 5, 2, Square4},
                //Square 5
                new object []{ 3, 3, Square5},
                new object []{ 4, 3, Square5},
                new object []{ 5, 3, Square5},
                new object []{ 3, 4, Square5},
                new object []{ 4, 4, Square5},
                new object []{ 5, 4, Square5},
                new object []{ 3, 5, Square5},
                new object []{ 4, 5, Square5},
                new object []{ 5, 5, Square5},
                //Square 6
                new object []{ 3, 6, Square6},
                new object []{ 4, 6, Square6},
                new object []{ 5, 6, Square6},
                new object []{ 3, 7, Square6},
                new object []{ 4, 7, Square6},
                new object []{ 5, 7, Square6},
                new object []{ 3, 8, Square6},
                new object []{ 4, 8, Square6},
                new object []{ 5, 8, Square6},
                //Square 7
                new object []{ 6, 0, Square7},
                new object []{ 7, 0, Square7},
                new object []{ 8, 0, Square7},
                new object []{ 6, 1, Square7},
                new object []{ 7, 1, Square7},
                new object []{ 8, 1, Square7},
                new object []{ 6, 2, Square7},
                new object []{ 7, 2, Square7},
                new object []{ 8, 2, Square7},
                //Square 8
                new object []{ 6, 3, Square8},
                new object []{ 7, 3, Square8},
                new object []{ 8, 3, Square8},
                new object []{ 6, 4, Square8},
                new object []{ 7, 4, Square8},
                new object []{ 8, 4, Square8},
                new object []{ 6, 5, Square8},
                new object []{ 7, 5, Square8},
                new object []{ 8, 5, Square8},
                //Square 9
                new object []{ 6, 6, Square9},
                new object []{ 7, 6, Square9},
                new object []{ 8, 6, Square9},
                new object []{ 6, 7, Square9},
                new object []{ 7, 7, Square9},
                new object []{ 8, 7, Square9},
                new object []{ 6, 8, Square9},
                new object []{ 7, 8, Square9},
                new object []{ 8, 8, Square9},
            };

        public static List<object[]> SelectionCanGoInRowTheory_ExpectingFalse_TestData()
            => new List<object[]>()
            {
                new object[]{ 0, 1 },
                new object[]{ 1, 2 },
                new object[]{ 2, 3 },
                new object[]{ 3, 4 },
                new object[]{ 4, 5 },
                new object[]{ 5, 6 },
                new object[]{ 6, 7 },
                new object[]{ 7, 8 },
                new object[]{ 8, 9 }
            };

        public static List<object[]> SelectionCanGoInRowTheory_ExpectingTrue_TestData()
            => new List<object[]>()
            {
                new object[]{ 0, 9 },
                new object[]{ 1, 2 },
                new object[]{ 2, 3 },
                new object[]{ 3, 4 },
                new object[]{ 4, 5 },
                new object[]{ 5, 6 },
                new object[]{ 6, 7 },
                new object[]{ 7, 8 },
                new object[]{ 8, 9 }
            };

        //{ 1, 2, 3, 0, 0, 0, 0, 0, 0 },
        //{ 4, 5, 6, 0, 0, 0, 0, 0, 0 },
        //{ 7, 8, 9, 0, 0, 0, 0, 0, 0 },
        //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        public static List<object[]> GetPossibleValuesTheoryTestData()
            => new List<object[]>()
            {
                new object[]{ NineByNineOnlySquare1FilledOut, 0, 3, new List<int>(){ 4, 5, 6, 7, 8, 9  } },
                new object[]{ NineByNineOnlySquare1FilledOut, 0, 0, new List<int>() { } },
                new object[]{ NineByNineOnlySquare1FilledOut, 1, 3, new List<int>(){ 1, 2, 3, 7, 8, 9 } },
                new object[]{ NineByNineOnlySquare1FilledOut, 2, 3, new List<int>(){ 1, 2, 3, 4, 5, 6 } },
                new object[]{ NineByNineOnlySquare1FilledOut, 3, 0, new List<int>(){ 2, 3, 5, 6, 8, 9 } },
                new object[]{ NineByNineOnlySquare1FilledOut, 3, 1, new List<int>(){ 1, 3, 4, 6, 7, 9 } },
                new object[]{ NineByNineOnlySquare1FilledOut, 3, 2, new List<int>() { 1, 2, 4, 5, 7, 8 } }
            };

        public static List<object[]> PuzzleCoordinatesFromSquareListTheoryTestData()
            => new List<object[]>()
            {
                new object[] { 6, 0, 0, (6, 0)},
                new object[] { 6, 0, 1, (6, 1)},
                new object[] { 6, 0, 2, (6, 2)},
                new object[] { 6, 0, 3, (7, 0)},
                new object[] { 6, 0, 4, (7, 1)},
                new object[] { 6, 0, 5, (7, 2)},
                new object[] { 6, 0, 6, (8, 0)},
                new object[] { 6, 0, 7, (8, 1)},
                new object[] { 6, 0, 8, (8, 2)},
            };

        #endregion
    }
}
