using SudokuSolver.Printers;
using SudokuSolver.Tests.MockData;

namespace SudokuSolver.UnitTests.Printers
{
    public class StringPuzzlePrinterTests
    {
        [Fact]
        public void TestPrint()
        {
            StringPuzzlePrinter printer = new StringPuzzlePrinter();
            string result = printer.Print(MockPuzzle.SolvedPuzzle);

        }
    }
}
