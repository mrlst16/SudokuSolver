namespace SudokuSolver.Models.Analytics
{
    public class Move
    {
        public int Order { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public int Value { get; set; }
        public SolverStrategyType Type { get; set; }
    }
}
