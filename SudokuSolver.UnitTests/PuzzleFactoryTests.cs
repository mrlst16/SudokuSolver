using SudokuSolver.Checkers;
using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.UnitTests
{
    public class PuzzleFactoryTests
    {
        private PuzzleFactoryOptions Options => new PuzzleFactoryOptions()
        {
            TriesPerSquare = 100
        };

        #region Tests
        [Fact]
        public void Create_BoardNull_ThrowException()
        {
            ByRowPuzzleFactory factory = new ByRowPuzzleFactory(Options);
            Assert.Throws<ArgumentNullException>(() => factory.Create(null));
        }

        [Fact]
        public void Create_BoardTooShort_ThrowException()
        {
            ByRowPuzzleFactory factory = new ByRowPuzzleFactory(Options);
            int[,] board = new int[,]
            {
                { 1, 2, 3 },
                { 1, 2, 3 }
            };
            Assert.Throws<ArgumentException>(() => factory.Create(board));
        }

        [Fact]
        public void Create_BoardTooLong_ThrowException()
        {
            ByRowPuzzleFactory factory = new ByRowPuzzleFactory(Options);
            int[,] board = new int[,] {
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            Assert.Throws<ArgumentException>(() => factory.Create(board));
        }

        [Theory]
        [MemberData(nameof(CreateTestData))]
        public void CreateOneTry_Test(
            PuzzleBoilermaker.PuzzleFactoryStrategy strategy
            )
        {
            PuzzleFactoryOptions options = new PuzzleFactoryOptions()
            {
                TotalTries = 1,
                TriesPerSquare = 10,
                IsComplete = board => false
            };
            IPuzzleFactory factory = PuzzleBoilermaker.Get(strategy, options);
            SudokuPuzzle result = factory.Create();
            PuzzleChecker checker = new PuzzleChecker();
            bool isGood = checker.Check(result);
            Assert.True(isGood);
        }
        #endregion

        #region Test Data

        public static List<object[]> CreateTestData()
            => new List<object[]>()
            {
                new object[]{ PuzzleBoilermaker.PuzzleFactoryStrategy.ByRow },
                new object[]{ PuzzleBoilermaker.PuzzleFactoryStrategy.DiagonalCross }
            };


        #endregion
    }
}