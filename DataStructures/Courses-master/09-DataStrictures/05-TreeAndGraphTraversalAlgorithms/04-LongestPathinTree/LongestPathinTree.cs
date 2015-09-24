using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_LongestPathinTree
{
    class LongestPathInTree
    {
        static Dictionary<int, List<int>> treeNodes = new Dictionary<int, List<int>>();
        static Dictionary<int, int?> parents = new Dictionary<int, int?>();

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                string currentFriendship = Console.ReadLine();
                int parent = int.Parse(currentFriendship.Split(' ')[0]);
                int child = int.Parse(currentFriendship.Split(' ')[1]);

                if (!treeNodes.ContainsKey(parent))
                {
                    treeNodes[parent] = new List<int>();
                }
                if (!treeNodes.ContainsKey(child))
                {
                    treeNodes[child] = new List<int>();
                }
                if (!parents.ContainsKey(child))
                {
                    parents[child] = parent;
                }
                if (!parents.ContainsKey(parent))
                {
                    parents[parent] = null;
                }

                treeNodes[parent].Add(child);
                parents[child] = parent;
            }

            var leaves = GetLeaves();
            int root = GetRoot();
            var pathsToRootList = new List<List<int>>();

            foreach (var leaf in leaves)
            {
                int cuurNode = leaf;
                List<int> currentPathToRoot = new List<int>();
                while (cuurNode != root)
                {
                    currentPathToRoot.Add(cuurNode);
                    cuurNode = (int)parents[cuurNode];
                }
                pathsToRootList.Add(currentPathToRoot);
            }

            int maximumPath = int.MinValue;

            for (int i = 0; i < pathsToRootList.Count; i++)
            {
                for (int j = 0; j < pathsToRootList.Count; j++)
                {
                    if (i != j && pathsToRootList[i].Intersect(pathsToRootList[j]).Count() == 0)
                    {
                        int currSum = pathsToRootList[i].Sum() + pathsToRootList[j].Sum() + root;
                        if (currSum > maximumPath)
                        {
                            maximumPath = currSum;
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(maximumPath);
        }

        private static List<int> GetLeaves()
        {
            var leaves = treeNodes.Where(n => n.Value.Count == 0).Select(n => n.Key).ToList();
            return leaves;
        }

        private static int GetRoot()
        {
            var root = parents.First(p => p.Value == null);
            return root.Key;
        }
    }
}
