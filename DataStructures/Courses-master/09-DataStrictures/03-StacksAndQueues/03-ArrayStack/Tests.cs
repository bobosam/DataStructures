using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_ArrayStack;

class Program
{
    static void Main()
    {
        var stack = new ArrayStack<int>();

        int[] arr1 = stack.ToArray();

        Console.WriteLine(string.Join(", ", arr1));

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);
        //Console.WriteLine(stack.Pop());
        //stack.Pop();
        //stack.Pop();
        //stack.Pop();
        //stack.Pop();
        //stack.Pop();
        //Console.WriteLine(stack.Contains(50));
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Count);
        int[] arr = stack.ToArray();
        Console.WriteLine(string.Join(", ", arr));

        var stack1 = new ArrayStack<int>();

        //stack1.Pop();
        var st = new Stack<int>();
        //st.Push(1);
        //st.Push(2);
        //st.Push(3);
        //Console.WriteLine(string.Join(", ", st.ToArray()));


        
    }
}

