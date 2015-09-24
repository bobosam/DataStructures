using System;
using _05_LinkedStack;

class Tests
{
    static void Main()
    {
        var stack = new LinkedStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        //stack.Pop();
        //stack.Push(4);
        //stack.Push(5);
        //stack.Push(6);
        var arr = stack.ToArray();

        Console.WriteLine(string.Join(", ", arr));

        var stack1 = new LinkedStack<int>();
        //stack1.Pop();
    }
}

