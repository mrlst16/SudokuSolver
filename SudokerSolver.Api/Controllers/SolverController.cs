using Common.Interfaces.Utilities;
using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Api.Responses;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;

namespace SudokuSolver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolverController : ControllerBase
    {

        private readonly IPuzzleParser _parser;
        private readonly IPuzzleSolver _solver;
        private readonly Func<int, IValidator<string>> _parserValidator;
        private readonly IMapper<SudokuAnalytics, SudokuAnalyticsResponse> _mapper;

        public SolverController(
            IPuzzleParser parser,
            IPuzzleSolver solver,
            Func<int, IValidator<string>> parserValidator,
            IMapper<SudokuAnalytics, SudokuAnalyticsResponse> mapper
            )
        {
            _parser = parser;
            _solver = solver;
            _parserValidator = parserValidator;
            _mapper = mapper;
        }

        [HttpPost("solve")]
        public async Task<IActionResult> Solve(
            [FromBody] string input
        )
        {
            await _parserValidator(1).ValidateAndThrowAsync(input);
            SudokuPuzzle puzzle = _parser.Parse(input);
            SudokuAnalytics result = _solver.Solve(puzzle);
            SudokuAnalyticsResponse response = _mapper.Map(result);

            return new OkObjectResult(new ApiResponse<SudokuAnalyticsResponse>()
            {
                Data = response,
                Success = true,
                SuccessMessage = "Successfully verified user email"
            });
        }
    }
}