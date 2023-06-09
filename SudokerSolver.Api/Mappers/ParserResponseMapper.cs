using Common.Interfaces.Utilities;
using SudokuSolver.Api.Extensions;
using SudokuSolver.Api.Responses;
using SudokuSolver.Models;

namespace SudokuSolver.Api.Mappers
{
    public class ParserResponseMapper : IMapper<SudokuPuzzle, ParserResponse>
    {
        public ParserResponse Map(SudokuPuzzle source)
            => new ParserResponse()
            {
                Board = source.Board.MapBoardToRespons()
            };
    }
}
