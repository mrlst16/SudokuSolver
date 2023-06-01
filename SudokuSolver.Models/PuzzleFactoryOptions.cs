namespace SudokuSolver.Models
{
    public class PuzzleFactoryOptions
    {
        public int TriesPerSquare { get; set; }
        public int TotalTries { get; set; } = 100;
        public Func<int[,], bool> IsComplete { get; set; }
    }
}
