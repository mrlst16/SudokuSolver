using SudokuSolver.Factories;

namespace SudokuSolver.UnitTests
{
    public class PuzzleFactoryTests
    {
        [Fact]
        public void CreateBoardNull_ThrowException()
        {
            PuzzleFactory factory = new PuzzleFactory();
            Assert.Throws<ArgumentNullException>(() => factory.Create(null));
        }

        [Fact]
        public void CreateBoardTooShort_ThrowException()
        {
            PuzzleFactory factory = new PuzzleFactory();
            int[,] board = new int[,]
            {
                { 1, 2, 3 },
                { 1, 2, 3 }
            };
            Assert.Throws<ArgumentException>(() => factory.Create(board));
        }

        [Fact]
        public void CreateBoardTooLong_ThrowException()
        {
            PuzzleFactory factory = new PuzzleFactory();
            int[,] board = new int[,] { 
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            };
            Assert.Throws<ArgumentException>(() => factory.Create(board));
        }
    }
}