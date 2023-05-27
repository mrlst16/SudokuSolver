using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public interface IValuable<T>
    {
        T Value { get; }
    }

    public static partial class Extensions
    {
        

        public static bool IsUnique<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector
        ) =>
            !source.GroupBy(keySelector)
                .Any(x => x.Count() > 1);

        public static bool HasUniqueValues<T>(this IEnumerable<IValuable<T>> enumerable)
            => enumerable.IsUnique(x => x.Value);
    }

    public class Cell : IValuable<int>
    {
        public int Value { get; set; }
        public int[] Possiblities { get; set; }

        public static implicit operator int(Cell cell)
            => cell.Value;

        public static implicit operator Cell(int value)
            => new Cell() { Value = value };

        public override bool Equals(object? obj)
        {
            if (obj is int val)
                return Value == val;
            if (obj is Cell valCell)
                return Value == valCell.Value;

            return base.Equals(obj);
        }
    }
}
