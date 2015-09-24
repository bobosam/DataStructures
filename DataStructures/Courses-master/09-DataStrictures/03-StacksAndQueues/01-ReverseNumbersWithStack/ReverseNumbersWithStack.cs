using System;
using System.Collections.Generic;

class ReverseNumbersWithStack
{
    static void Main()
    {
        Console.WriteLine("Please, input N: ");
        int numberOfIntegers = int.Parse(Console.ReadLine());
            
        Stack<int> stack = new Stack<int>();

        while (numberOfIntegers > 0)
        {
            int currentNumer = int.Parse(Console.ReadLine());
            stack.Push(currentNumer);
            numberOfIntegers--;
        }

        Console.WriteLine();

        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}

