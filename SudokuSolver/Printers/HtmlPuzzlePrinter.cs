using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Printers
{
    public class HtmlPuzzlePrinter : IPuzzlePrinter
    {
        public string Print(SudokuPuzzle puzzle)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<table style=\"border: 1px solid black\"; border-collapse: collapse;>");
            for (int i = 0; i < 9; i++)
            {
                builder.AppendLine("<tr style=\"border: 1px solid black\"; border-collapse: collapse;>");
                for (int j = 0; j < 9; j++)
                {
                    builder.AppendLine("<td style=\"border: 1px solid black\"; border-collapse: collapse;>");
                    
                    Cell cell = puzzle[i, j];
                    if (cell.Value.IsInRange())
                    {
                        builder.Append($"<b>{cell.Value}</b>");
                    }
                    else
                    {
                        string possibilities = Possibilities(cell);
                        builder.Append(possibilities);
                    }
                    builder.AppendLine("</td>");
                }

                builder.AppendLine("</tr>");
            }
            builder.AppendLine("</table>");
            return builder.ToString();
        }

        private string Possibilities(Cell cell)
        {
            StringBuilder builder = new();
            int place = 1;

            builder.AppendLine("<table>");
            for (int i = 0; i < 3; i++)
            {
                builder.AppendLine("<tr>");
                for (int j = 0; j < 3; j++)
                {
                    builder.AppendLine("<td>");
                    if (cell.Possiblities.Contains(place))
                        builder.Append(place);
                    builder.AppendLine("</td>");
                    place++;
                }

                builder.AppendLine("</tr>");
            }
            builder.AppendLine("</table>");
            return builder.ToString();
        }
    }
}
