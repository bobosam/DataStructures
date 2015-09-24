using System;
using System.Collections.Generic;

class Words
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<string> words = new List<string>(input.Split(' '));
        words.Sort();

        foreach (var word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}

