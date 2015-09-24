using System;
using System.Collections.Generic;

class TestLongestSequence
{
    static void Main()
    {
        
        List<string> inputs = new List<string>() 
        { 
            "12 2 7 4 3 3 8",
            "2 2 2 3 3 3",
            "4 4 5 5 5",
            "1 2 3",
            "0"
        };

        List<string> results = new List<string>() 
        { 
            "3, 3",
            "2, 2, 2",
            "5, 5, 5",
            "1",
            "0"
        };

        bool worksCorrect = true;

        for (int i = 0; i < inputs.Count; i++)
        {
            var currResult = string.Join(", ", LongestSequence.getLongestSubsequence(inputs[i]));
            if (currResult != results[i])
            {
                worksCorrect = false;
            }
        }

        if (worksCorrect)
        {
            Console.WriteLine("The program works correct !");
        }
        else
        {
            Console.WriteLine("Not all test passed...");
        }
    }
}

