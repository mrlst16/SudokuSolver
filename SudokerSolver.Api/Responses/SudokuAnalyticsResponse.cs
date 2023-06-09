using SudokuSolver.Models.Analytics;

namespace SudokuSolver.Api.Responses
{
    public class SudokuAnalyticsResponse
    {
        public List<Move> Moves { get; set; } = new List<Move>();
        public int TotalPasses { get; set; }
        public string StringRepresentation { get; set; }
        public IEnumerable<IEnumerable<int>> SolvedPuzzle { get; internal set; }
    }
}
