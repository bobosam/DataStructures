using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_PlayWithTrees
{
    class PlayWithTreesMain
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            // The root node
            Console.WriteLine("Root node: {0}", FindRootNode().Value);
            Console.WriteLine();

            // All leaf nodes
            var leafNodes = FindLeafNodes().Select(n => n.Value).ToList();
            //leafNodes.Sort();
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafNodes));
            Console.WriteLine();

            // All middle nodes
            var middleNodes = FindMiddleNodes().Select(n => n.Value).ToList();
            middleNodes.Sort();
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));
            Console.WriteLine();

            // The longest path 
            var leafNode = FindLongestPath();
            Console.WriteLine(string.Format("Longest path: {0} (length = {1})",
                string.Join(" -> ", GetPath(leafNode)), GetPath(leafNode).Count));
            Console.WriteLine();

            // All paths in the tree with given sum P of their nodes
            Console.WriteLine("Paths of sum {0}: ", pathSum);
            var startLeafs = FindAllPathWithGivenSum(pathSum);
            foreach (var startLeaf in startLeafs)
            {
                Console.WriteLine(string.Join(" -> ", GetPath(startLeaf)));
            }
            Console.WriteLine();

            // All subtrees with given sum S of their nodes
            Console.WriteLine("Subtrees of sum {0}:", subtreeSum);
            var subtrees = FindSubtreeWithGivenSum(subtreeSum);
            foreach (var subtree in subtrees)
            {
                var list = new List<int>();
                subtree.Each(list.Add);
                Console.WriteLine(string.Join(" + ", list));
            }
        }

        static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(node => node.Children.Count == 0 &&
                    node.Parent != null).ToList();

            return leafNodes;
        }

        static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(node => node.Children.Count > 0 &&
                    node.Parent != null).ToList();

            return middleNodes;
        }

        // Without recursion - Starts with leaf nodes list
        static Tree<int> FindLongestPath()
        {
            var leafNodes = FindLeafNodes();
            int maxLength = 0;
            Tree<int> startNode = null;

            foreach (var leaf in leafNodes)
            {
                var currLeaf = leaf;
                int currLength = 1;
                while (currLeaf.Parent != null)
                {
                    currLength++;
                    if (currLength > maxLength)
                    {
                        maxLength = currLength;
                        startNode = leaf;
                    }
                    currLeaf = currLeaf.Parent;
                }
            }

            return startNode;
        }

        // Without recursion - Starts with leaf nodes list
        static IList<Tree<int>> FindAllPathWithGivenSum(int pathSum)
        {
            var leafNodes = FindLeafNodes();
            var paths = new List<Tree<int>>(); 

            foreach (var leaf in leafNodes)
            {
                if (GetPath(leaf).Sum() == pathSum)
                {
                    paths.Add(leaf);
                }
            }

            return paths;
        }

        // Gets path from given leaf to root node
        static IList<int> GetPath(Tree<int> leafNode)
        {
            var path = new Stack<int>();

            while (leafNode != null)
            {
                path.Push(leafNode.Value);
                leafNode = leafNode.Parent;
            }

            return path.ToList();
        }

        static IList<Tree<int>> FindSubtreeWithGivenSum(int sum)
        {
            var nodes = new List<Tree<int>>();

            foreach (var node in nodeByValue)
            {
                if (TreeSum(node.Value) == sum)
                {
                    nodes.Add(node.Value);
                }
            }
            return nodes;
        }

        private static int TreeSum(Tree<int> node)
        {
            if (node == null) // node.Children.Count == 0
            {
                return 0;
            }

            int childSum = 0;

            foreach (var child in node.Children)
            {
                childSum += TreeSum(child);
            }
            return node.Value + childSum;
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }
    }
}
