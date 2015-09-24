using System;
using System.Collections.Generic;
using System.Linq;

class SequenceNM
{
    private class Item
    { 
        public int Value { get; set; }
        public Item PreviousItem { get; set; }

        public Item(int value, Item previousItem)
        {
            this.Value = value;
            this.PreviousItem = previousItem;
        }
    }
    static void Main()
    {
        string input = Console.ReadLine();
        int start = int.Parse(input.Split(' ')[0]);
        int end = int.Parse(input.Split(' ')[1]);
        

        Queue<Item> queue = new Queue<Item>(new Item[]{ new Item(start, null) });

        while (queue.Count > 0)
        {
            var currentItem = queue.Dequeue();

            if (currentItem.Value < end || currentItem.Value < 0 
                && end < 0 && currentItem.Value > end)
            {
                queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
                queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
            }
            else if (currentItem.Value == end)
            {
                printNMSequence(currentItem);
                break;
            }
        }
        if (queue.Count == 0)
        {
            Console.WriteLine("(No solution)");
        }
    }
     
    static void printNMSequence(Item item)
    {
        var stack = new Stack<int>();

        while (item.PreviousItem != null)
        {
            stack.Push(item.Value);
            item = item.PreviousItem;

            if (item.PreviousItem == null)
            {
                stack.Push(item.Value);
            }
        }
        Console.WriteLine(string.Join(" -> ", stack));
    }
}

