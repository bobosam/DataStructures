using System;

class ReversedListTest
{
    static void Main()
    {
        Console.WriteLine();
        // creates GenericList<int>
        ReversedList<int> list = new ReversedList<int>();

        //empry list test
        Console.WriteLine(list);

        // adding test
        for (int i = 0; i < 10; i++)
        {
            list.Add(i);
            Console.WriteLine(list);
        }

        // ToString()
        Console.WriteLine(list);

        // removing element by index test
        for (int i = 9; i >= 0; i--)
        {
            list.Remove(i);
            Console.WriteLine(list);
        }

        list.Add(6);
        list.Add(1);
        list.Add(7);
        list.Add(5);
        list.Add(9);
        list.Add(2);
        list.Add(8);
        list.Add(0);
        list.Add(3);
        list.Add(4);

        // ToString()
        Console.WriteLine(list);

        // Foreach
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        // Count
        Console.WriteLine("Count: {0}", list.Count);

        // Capacity
        Console.WriteLine("Capacity: {0}", list.Capacity);
    }
}

