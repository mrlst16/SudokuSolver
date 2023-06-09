using SudokuSolver.Models;

namespace SudokuSolver.Api.Extensions
{
    public static class MapperExtensions
    {

        public static IEnumerable<IEnumerable<int>> MapBoardToRespons(this Cell[,] board)
        {
            List<List<int>> result = new();
            for (int i = 0; i < 9; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    row.Add(board[i, j]);
                }
                result.Add(row);
            }
            return result;
        }
    }
}
