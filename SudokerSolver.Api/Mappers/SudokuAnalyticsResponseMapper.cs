using Common.Extensions;
using Common.Interfaces.Utilities;
using SudokuSolver.Api.Extensions;
using SudokuSolver.Api.Responses;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.Api.Mappers
{
    public class SudokuAnalyticsResponseMapper : IMapper<SudokuAnalytics, SudokuAnalyticsResponse>
    {
        public SudokuAnalyticsResponse Map(SudokuAnalytics source)
            => new SudokuAnalyticsResponse()
            {
                TotalPasses = source.TotalPasses,
                Moves = source.Moves,
                StringRepresentation = source.StringRepresentation,
                SolvedPuzzle = source.Result.Board.MapBoardToRespons()
            };
    }
}