using SudokuSolver.Helpers;
using SudokuSolver.Models;
using SudokuSolver.Printers;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.Printers
{
    public class HtmlPuzzlePrinterTests
    {
        [Fact]
        public void Test()
        {
            HtmlPuzzlePrinter printer = new HtmlPuzzlePrinter();
            SudokuPuzzle puzzle = MockPuzzleFactory.EasyLevelPuzzle1;
            FastPencil.Apply(puzzle);
            string result = printer.Print(puzzle);
        }
    }
}
