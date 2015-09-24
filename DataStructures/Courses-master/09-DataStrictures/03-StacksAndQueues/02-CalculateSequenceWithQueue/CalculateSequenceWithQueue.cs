using System;
using System.Collections.Generic;

class CalculateSequenceWithQueue
{
    static void Main()
    {
        Console.WriteLine("Please, input N: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Queue<int> queue = new Queue<int>(new int[]{ firstNumber });

        int sequenceLength = 50;

        while (sequenceLength > 0)
        {
            int currentElement = queue.Dequeue();
            Console.Write(currentElement + " ");
            sequenceLength--;

            queue.Enqueue(currentElement + 1);
            queue.Enqueue(2 * currentElement + 1);
            queue.Enqueue(currentElement + 2);
        }
    }
}

