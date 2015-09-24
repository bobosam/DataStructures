using System;

class TestOrderedSetMain
{
    static void Main()
    {
        var set = new OrderedSet<int>();
        Console.WriteLine("Add: 29, 11, 35, 7, 16, 23, 37, 17");
        set.Add(29);
        set.Add(11);
        set.Add(35);
        set.Add(7);
        set.Add(16);
        set.Add(23);
        set.Add(37);
        set.Add(17);

        Console.WriteLine();

        Console.WriteLine("In-order print: ");
        set.PrintInorder(set.Root);

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Foreach: ");
        foreach (var item in set)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("EachInOrder(Action<T> action): ");
        set.EachInOrder(n => Console.Write(n + " "));

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Insert 23: ");
        set.Add(23);
        set.EachInOrder(n => Console.Write(n + " "));

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Remove 16: ");
        set.Remove(16);
        set.EachInOrder(n => Console.Write(n + " "));

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Find 7: ");
        var find7 = set.Find(7) != null ? "7" : "null";
        Console.WriteLine(find7);


        Console.WriteLine();

        Console.WriteLine("Find 200: ");
        var find200 = set.Find(200) != null ? "200" : "null";
        Console.WriteLine(find200);

        Console.WriteLine();

        Console.WriteLine("Contains 7: ");
        var contains7 = set.Contains(7) == true ? "true" : "false";
        Console.WriteLine(contains7);

        Console.WriteLine();

        Console.WriteLine("Contains 200: ");
        var contains200 = set.Contains(200) == true ? "true" : "false";
        Console.WriteLine(contains200);

        Console.WriteLine();

        Console.WriteLine("Count:");
        Console.WriteLine(set.Count);

        Console.WriteLine(
            "Count after Add and Remove: Add 1, Remove 23, Add 5, " +
            "Add 14, Add 108, Remove 5, Remove 12 (no such value)");
        set.Add(1);
        set.Remove(23);
        set.Add(5);
        set.Add(14);
        set.Add(108);
        set.Remove(5);
        set.Remove(12);// no such value
        Console.WriteLine("Count: {0}", set.Count); 
        set.EachInOrder(n => Console.Write(n + " "));

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Min value: {0}", set.Min());

        Console.WriteLine();

        Console.WriteLine("Min value: {0}", set.Max());

        Console.WriteLine();

        set.Clear();
        Console.WriteLine("Clear: {0} (Count)", set.Count);
    }
}

