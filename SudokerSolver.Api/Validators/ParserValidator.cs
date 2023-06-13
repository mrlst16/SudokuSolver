using FluentValidation;
using SudokuSolver.Parsers;

namespace SudokuSolver.Api.Validators
{
    public class ParserValidator : AbstractValidator<string>
    {
        public ParserValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .WithMessage("Puzzle cannot be null or empty");

            RuleFor(x => x)
                .Must(HaveCorrectNumbers)
                .WithMessage("Puzzle must have 81 numbers each between 0 and 9 inclusively");
        }

        private bool HaveCorrectNumbers(string str)
            => PuzzleParser.ExtractNumbers(str)?.Count() == 81;
    }
}
