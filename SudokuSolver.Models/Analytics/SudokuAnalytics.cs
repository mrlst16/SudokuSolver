namespace SudokuSolver.Models.Analytics
{
    public class SudokuAnalytics
    {
        public List<Move> Moves { get; set; } = new List<Move>();
        public int TotalPasses { get; set; }
        public SudokuPuzzle Result { get; set; }
        public string StringRepresentation { get; set; }
    }
}
