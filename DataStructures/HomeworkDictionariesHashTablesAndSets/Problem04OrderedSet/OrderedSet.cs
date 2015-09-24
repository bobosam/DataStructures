using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04OrderedSet
{
    public class OrderedSet<T> : IEnumerable<T> where T: IComparable<T>
    {
        private Node<T> root;

        public OrderedSet()
        {
            this.Root = null;
            this.Count = 0;
        }

        public Node<T> Root { get; set; }

        public int Count { get; set; }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can't insert null value! ");
            }

            if (!this.Contains(value))
            {
                this.Count++;
            }

            this.Root = Insert(value, null, this.Root);
        }

        private Node<T> Insert(T value, Node<T> parentNode, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                node.Parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.Value);
                if (0 > compareTo)
                {
                    node.LeftChild = Insert(value, node, node.LeftChild);
                }
                else
                {
                    node.RightChild = Insert(value, node, node.RightChild);
                }
            }

            return node;
        }

        public Node<T> Find(T value)
        {
            Node<T> currentNode = this.Root;
            while (currentNode != null)
            {
                int compareTo = value.CompareTo(currentNode.Value);
                if (0 > compareTo)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (0 < compareTo)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }
         
        public bool Contains(T value)
        {
            var element = this.Find(value);
            return element != null;
        }

        public void Remove(T value)
        {
            Node<T> removeNode = Find(value);
            if (removeNode == null)
            {
                return;
            }

            Delete(removeNode);
            this.Count--;
        }

        private void Delete(Node<T> removeNode)
        {
            if ((removeNode.LeftChild != null) && (removeNode.RightChild != null))
            {
                Node<T> replacement = removeNode.RightChild;
                while (replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }

                removeNode.Value = replacement.Value;
                removeNode = replacement;
            }

            Node<T> child = removeNode.LeftChild != null ? removeNode.LeftChild : removeNode.RightChild;
            if (child != null)
            {
                child.Parent = removeNode.Parent;
                if (removeNode.Parent.Parent == null)
                {
                    this.Root = child;
                }
                else
                {
                    if (removeNode.Parent.LeftChild == removeNode)
                    {
                        removeNode.Parent.LeftChild = child;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = child;
                    }
                }
            }
            else
            {
                if (removeNode.Parent == null)
                {
                    this.Root = null;
                }
                else
                {
                    if (removeNode.Parent.LeftChild == removeNode)
                    {
                        removeNode.Parent.LeftChild = null;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = null;
                    }
                }
            }
        }

        public T Min()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("Can't get Min from empty set! ");
            }
            var currentNode = this.Root;
            T minValue = default(T);
            while (currentNode != null)
            {
                minValue = currentNode.Value;
                currentNode = currentNode.LeftChild;
            }

            return minValue;
        }

        public T Max()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("Can't get Max from empty set! ");
            }

            var currentNode = this.Root;
            T maxValue = default(T);
            while (currentNode != null)
            {
                maxValue = currentNode.Value;
                currentNode = currentNode.RightChild;
            }

            return maxValue;
        }

        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        public void PrintInOrder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            PrintInOrder(root.LeftChild);
            Console.Write(root.Value + " ");
            PrintInOrder(root.RightChild);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Root.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.Root.LeftChild != null)
            {
                this.Root.LeftChild.EachInOrder(action);
            }

            action(this.Root.Value);
            if (this.Root.RightChild != null)
            {
                this.Root.RightChild.EachInOrder(action);
            }
        }
    }
}
