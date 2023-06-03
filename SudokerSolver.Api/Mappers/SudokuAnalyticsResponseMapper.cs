using Common.Extensions;
using Common.Interfaces.Utilities;
using SudokuSolver.Api.Responses;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.Api.Mappers
{
    public class SudokuAnalyticsResponseMapper : IMapper<SudokuAnalytics, SudokuAnalyticsResponse>
    {
        public SudokuAnalyticsResponse Map(SudokuAnalytics source)
        {
            List<List<int>> twoDSolved = new();
            for (int i = 0; i < 9; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    row.Add(source.Result.Board[i,j]);
                }
                twoDSolved.Add(row);
            }
            return new SudokuAnalyticsResponse()
            {
                TotalPasses = source.TotalPasses,
                Moves = source.Moves,
                StringRepresentation = source.StringRepresentation,
                SolvedPuzzle = source.Result.Board.Flatten().Select(x => x.Value),
                SolvedPuzzle2D = twoDSolved
            };
        }
    }
}
