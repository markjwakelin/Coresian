using System;
using System.Collections.Generic;
using System.Linq;

namespace Coresian.Extensions
{
    public static class EnumerableTExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            enumerable.Select<T, bool?>(x =>
            {
                action(x);
                return null;
            }).ToArray();
        }
    }
}
