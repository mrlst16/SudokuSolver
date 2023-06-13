using Common.Interfaces.Utilities;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Api.Responses;
using SudokuSolver.Interfaces;
using SudokuSolver.Models.Analytics;
using SudokuSolver.Models;

namespace SudokuSolver.Api.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : Controller
    {
        private readonly IPuzzleParser _parser;
        private readonly Func<int, IValidator<string>> _parserValidator;
        private readonly IMapper<SudokuPuzzle, ParserResponse> _mapper;

        public ParserController(
            IPuzzleParser parser,
            Func<int, IValidator<string>> parserValidator,
            IMapper<SudokuPuzzle, ParserResponse> mapper
        )
        {
            _parser = parser;
            _parserValidator = parserValidator;
            _mapper = mapper;
        }

        [HttpPost("parse")]
        public async Task<IActionResult> Solve(
            [FromBody] string input
        )
        {
            await _parserValidator(1).ValidateAndThrowAsync(input);
            SudokuPuzzle puzzle = _parser.Parse(input);
            ParserResponse response = _mapper.Map(puzzle);

            return new OkObjectResult(new ApiResponse<ParserResponse>()
            {
                Data = response,
                Success = true,
                SuccessMessage = "Successfully solved puzzle"
            });
        }
    }
}
