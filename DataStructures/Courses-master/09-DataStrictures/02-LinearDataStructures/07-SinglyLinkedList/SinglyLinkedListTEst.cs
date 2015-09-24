using System;

class SinglyLinkedListTest
{
    static void Main()
    {
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(6);
        list.AddLast(3);

        Console.WriteLine("FirstIndexOf(6): {0}", list.FirstIndexOf(6));
        Console.WriteLine("FirstIndexOf(1): {0}", list.FirstIndexOf(1));
        Console.WriteLine("FirstIndexOf(16): {0}", list.FirstIndexOf(16));

        Console.WriteLine("LastIndexOf(3): {0}", list.LastIndexOf(3));
        Console.WriteLine("LastIndexOf(30): {0}", list.LastIndexOf(30));

        Console.WriteLine(list.Count);

        list.Remove(0);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        
    }
}

