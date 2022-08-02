using System;
using System.Collections.Generic;

namespace LinqTasksReinvent
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Repeat<TSource>(this IEnumerable<TSource> source, int count)
        {
            bool flag = false;
            for (int i = 0; i < count; i++)
            {
                foreach (var item in source)
                {
                    if (flag)
                    {
                        throw new ArgumentException();
                    }
                    yield return item;
                    flag = true;
                }
                flag = false;
            }
        }

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            foreach (var item in first)
            {
                yield return item;
            }
            foreach (var item in second)
            {
                yield return item;
            }
        }

        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            foreach (var item in source)
            {
                if (count == 0)
                {
                    yield break;
                }
                yield return item;
                count--;
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            List<TSource> result = new();
            foreach (var item in source)
            {
                result.Add(item);
            }
            return result;
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int count = 0;
            foreach (var item in source)
            {
                if (predicate(item, count++))
                {
                    yield return item;
                }
            }
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value,
            IEqualityComparer<TSource> comparer)
        {
            foreach (var item in source)
            {
                if (comparer.Equals(item, value))
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            int count = 0;
            foreach (var item in source)
            {
                yield return selector(item, count++);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource sourceItem in source)
            {
                IEnumerable<TResult> collection = selector(sourceItem);

                foreach (TResult collectionItem in collection)
                {
                    yield return collectionItem;
                }
            }
        }

        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            TSource result = default;
            var sourceList = source.ToList();

            for (int i = 0; i < sourceList.Count; i++)
            {
                result = func(result, sourceList[i]);
            }
            return result;
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            HashSet<TSource> result = new();

            foreach (var item in source)
            {
                result.Add(item);
            }
            return result;
        }

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            List<TSource> collection = new();
            foreach (var itemFirst in first)
            {
                foreach (var itemSecond in second)
                {
                    if (itemFirst.Equals(itemSecond))
                    {
                        collection.Add(itemFirst);
                    }
                }
            }
            return collection;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            Dictionary<TKey, List<TElement>> keyAndValues = new();

            foreach (var item in source)
            {
                var key = keySelector(item);
                var element = elementSelector(item);

                if (keyAndValues.ContainsKey(key))
                {
                    keyAndValues[key].Add(element);
                    continue;
                }
                keyAndValues.Add(key, new List<TElement> { element });
            }

            foreach (var item in keyAndValues)
            {
                yield return resultSelector(item.Key, item.Value);
            }
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            {
                foreach (var itemOuter in outer)
                {
                    foreach (var itemInner in inner)
                    {
                        if (outerKeySelector(itemOuter).Equals(innerKeySelector(itemInner)))
                        {
                            yield return resultSelector(itemOuter, itemInner);
                        }
                    }
                }
            }
        }
    }
}
