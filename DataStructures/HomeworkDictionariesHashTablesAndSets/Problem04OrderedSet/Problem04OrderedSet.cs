using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04OrderedSet
{
    class Problem04OrderedSet
    {
        public static void Main(string[] args)
        {
            var set = new OrderedSet<int>();
            Console.WriteLine("Add numbers --> 19, 21, 55, 27, 66, 33, 17, 85");
            set.Add(19);
            set.Add(21);
            set.Add(55);
            set.Add(27);
            set.Add(66);
            set.Add(33);
            set.Add(17);
            set.Add(85);
            Console.WriteLine();
            Console.WriteLine("In-order print --> ");
            set.PrintInOrder(set.Root);
            Console.WriteLine();
            Console.WriteLine("Foreach --> ");
            foreach (var item in set)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("EachInOrder(Action<T> action) --> ");
            set.EachInOrder(n => Console.Write(n + " "));
            Console.WriteLine();
            Console.WriteLine("Insert 44 --> ");
            set.Add(44);
            set.EachInOrder(n => Console.Write(n + " "));
            Console.WriteLine();
            Console.WriteLine("Remove 66 --> ");
            set.Remove(66);
            set.EachInOrder(n => Console.Write(n + " "));
            Console.WriteLine();
            Console.WriteLine("Find 17 --> ");
            var find17 = set.Find(17) != null ? "17" : "null";
            Console.WriteLine(find17);
            Console.WriteLine();
            Console.WriteLine("Find 200 --> ");
            var find200 = set.Find(200) != null ? "200" : "null";
            Console.WriteLine(find200);
            Console.WriteLine();
            Console.WriteLine("Contains 44 --> ");
            var contains44 = set.Contains(44) == true ? "true" : "false";
            Console.WriteLine(contains44);
            Console.WriteLine();
            Console.WriteLine("Contains 200 --> ");
            var contains200 = set.Contains(200) == true ? "true" : "false";
            Console.WriteLine(contains200);
            Console.WriteLine();
            Console.WriteLine("Count --> ");
            Console.WriteLine(set.Count);
            Console.WriteLine(
    "Count after Add and Remove: Add 11, Remove 55, Add 5, Add 84, Add 18, Remove 5, Remove 18 (no such value)");
            set.Add(11);
            set.Remove(55);
            set.Add(5);
            set.Add(84);
            set.Add(18);
            set.Remove(5);
            set.Remove(18);
            Console.WriteLine("Count --> {0}", set.Count);
            set.EachInOrder(n => Console.Write(n + " "));
            Console.WriteLine();
            Console.WriteLine("Min value --> {0}", set.Min());
            Console.WriteLine();
            Console.WriteLine("Min value --> {0}", set.Max());
            Console.WriteLine();
            set.Clear();
            Console.WriteLine("Clear --> {0} (Count)", set.Count);
        }
    }
}
