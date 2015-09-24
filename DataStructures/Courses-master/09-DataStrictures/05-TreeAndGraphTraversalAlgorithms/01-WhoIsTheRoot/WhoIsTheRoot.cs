using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_WhoIsTheRoot
{
    class WhoIsTheRoot
    {
        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[numberOfNodes];
            bool[] hasChild = new bool[numberOfNodes];

            for (int i = 0; i < numberOfEdges; i++)
            {
                string currentLine = Console.ReadLine();
                int child = int.Parse(currentLine.Split(' ')[1]);
                int parent = int.Parse(currentLine.Split(' ')[0]);
                hasParent[child] = true;
                hasChild[parent] = true;
            }

            int index = hasParent
                .Select((h, i) => new { i, h })
                .Where(c => c.h == false)
                .Select(c => c.i).FirstOrDefault();

            int hasNoParentCount = hasParent.Where(n => n == false).Count();

            if (hasNoParentCount == 1 && hasChild[index] == true)
            {
                Console.WriteLine(index);
            }
            else if (hasNoParentCount == 1 && hasChild[index] == false)
            {
                Console.WriteLine("Single (not-connected) node is not a root!");
            }
            else if (hasNoParentCount > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine("No root");
            }
        }
    }
}
