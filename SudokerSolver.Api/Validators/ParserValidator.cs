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
                .Must(x => HaveCorrectNumbers(x))
                .WithMessage("Puzzle must have 81 numbers each between 1 and 9 inclusively");
        }

        private bool HaveCorrectNumbers(string str)
            => PuzzleParser.ExtractNumbers(str)?.Count() == 81;
    }
}
