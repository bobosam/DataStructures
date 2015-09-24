using System;
using System.Collections.Generic;
public class GraphConnectedComponents
{
    private static List<int>[] graph;

    private static bool[] visited;
    
    
    public static void Main()
    {
        int graphSize = int.Parse(Console.ReadLine());
        graph = new List<int>[graphSize];
        visited = new bool[graphSize];

        for (int row = 0; row < graphSize; row++)
        {
            graph[row] = new List<int>();
            string neighboursLine = Console.ReadLine();
            string[] neighboursSplit = neighboursLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int[] neighbours = new int[neighboursSplit.Length];

            for (int index = 0; index < neighboursSplit.Length; index++)
            {
                neighbours[index] = int.Parse(neighboursSplit[index]);
                graph[row].Add(neighbours[index]);
            }
        }

        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }
    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var chaild in graph[node])
            {
                DFS(chaild);
            }

            Console.Write(" " + node);
        }
    }
}
