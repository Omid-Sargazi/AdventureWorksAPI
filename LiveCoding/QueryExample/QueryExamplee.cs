using System.Collections;

namespace LiveCoding.QueryExample
{
    public class Personn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class QueryExamplee
    {
        public static void Run()
        {
            List<Personn> people = new List<Personn>
            {
                new Personn { Id = 1, Name = "Omid", Age = 42 },
                new Personn { Id = 2, Name = "Sara", Age = 25 },
                new Personn { Id = 3, Name = "Ali", Age = 30 },
                new Personn { Id = 4, Name = "Niloofar", Age = 28 }
            };

            var nums = new int[] { 1, 2, 3, 4, 5 };


            // IEnumerable<Person> bb = people.Where(p => p.Age > 27);
            // var res2 = people.ToList().Where(p => p.Age > 27);
            // var res3 = people.ToList().Select(p => p.Age > 27);
            // var res4 = people.Select(p => p.Age > 27).ToList();
            // var res5 = people.Where(p => p.Age < 27).Select(p => p.Age > 27);

            // //=======================
            // var res1 = db.people.Where(p => p.Age > 27);
            // var res2 = db.people.ToList().Where(p => p.Age > 27);
            // var res3 = db.people.ToList().Select(p => p.Age > 27);
            // var res4 = db.people.Select(p => p.Age > 27).ToList();
            // var res5 = db.people.Where(p => p.Age < 27).Select(p => p.Age > 27);

            var res = people.MyWhere(p => p.Age > 18).ToList();
            Console.WriteLine(string.Join(",", res[0].Age));

            var numsRatherThan5 = nums.MySelect(n => n > 3);
            foreach (var item in numsRatherThan5)
            {
                Console.WriteLine(item);
            }
            //=======================


        }
    }

    public static class LinqCustome
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                var res = selector(item);
                yield return res;
            }
        }

       


    }

    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        public TKey Key => throw new NotImplementedException();

        public IEnumerator<TElement> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public interface IGrouping<TKey, TElement> : IEnumerable<TElement>
    {
        TKey Key { get; }
    }
}