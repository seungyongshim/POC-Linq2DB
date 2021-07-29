namespace WebApplication1
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Class
    {
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
            => k == 0 ? EnumerableEx.Return(Enumerable.Empty<T>())
                      : elements.SelectMany((e, i) =>
                            elements.Skip(i + 1)
                                    .DifferentCombinations(k - 1)
                                    .Select(c => EnumerableEx.Return(e).Concat(c)));
    }
}
