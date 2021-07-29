namespace WebApplication1
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Class
    {
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
            => k == 0 ? new[] { new T[0] }
                      : elements.SelectMany((e, i) =>
                        elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    }
}
