using Common.Interfaces.Utilities;
using FluentValidation;
using SudokuSolver.Api.Mappers;
using SudokuSolver.Api.Responses;
using SudokuSolver.Api.Validators;
using SudokuSolver.Checkers;
using SudokuSolver.Factories;
using SudokuSolver.Interfaces;
using SudokuSolver.Models.Analytics;
using SudokuSolver.Parsers;
using SudokuSolver.Solvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPuzzleParser, PuzzleParser>();
builder.Services.AddTransient<IPuzzleSolver>(x => PuzzleSolverFactory.CreateAllCellsInRangeStandardStrategiesHtmlPrinter);
builder.Services.AddTransient<IPuzzleChecker, AllCellsInRangePuzzleChecker>();
builder.Services.AddTransient<Func<int, IValidator<string>>>(
    x => new Func<int, IValidator<string>>(
        i => i switch
            {
                1 => new ParserValidator()
            }
        )
    );
builder.Services.AddTransient<IMapper<SudokuAnalytics, SudokuAnalyticsResponse>, SudokuAnalyticsResponseMapper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
