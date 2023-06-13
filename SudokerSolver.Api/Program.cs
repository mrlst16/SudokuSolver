using Common.Interfaces.Utilities;
using FluentValidation;
using SudokuSolver.Api.Mappers;
using SudokuSolver.Api.Middleware;
using SudokuSolver.Api.Responses;
using SudokuSolver.Api.Validators;
using SudokuSolver.Checkers;
using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;
using SudokuSolver.Models.Analytics;
using SudokuSolver.Parsers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPuzzleParser, PuzzleParser>()
    .AddTransient<IPuzzleSolver>(x => PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategiesHtmlPrinter)
    .AddTransient<IPuzzleChecker, AllCellsInRangePuzzleChecker>()
    .AddTransient<Func<int, IValidator<string>>>(
        x => new Func<int, IValidator<string>>(
            i => i switch
            {
                1 => new ParserValidator(),
                _ => throw new NotImplementedException()
            }
        )
    )
    .AddTransient<Func<int, IPuzzleChecker>>(
        x => new Func<int, IPuzzleChecker>(
            i => i switch
            {
                1 => new PuzzleChecker(),
                _ => throw new NotImplementedException()
            }
        )
    )
    .AddTransient<IMapper<SudokuAnalytics, SudokuAnalyticsResponse>, SudokuAnalyticsResponseMapper>()
    .AddTransient<IMapper<SudokuPuzzle, ParserResponse>, ParserResponseMapper>()
    .AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x =>
    x.AddPolicy("LP",
        policy =>
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("LP");
app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    ErrorHandlingMiddleware errorHandler = new ErrorHandlingMiddleware();
    await errorHandler.Handle(context, next);
});

//app.UseAuthorization();

app.MapControllers();

app.Run();