using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04OrderedSet
{
    public class Node<T> : IEnumerable<T>, IComparable<Node<T>> where T : IComparable<T>
    {
        private T value;
        private Node<T> parent;
        private Node<T> rightChild;
        private Node<T> leftChild;

        public Node(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.RightChild = null;
            this.LeftChild = null;
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public Node<T> RightChild { get; set; }

        public Node<T> LeftChild { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var child in this.LeftChild)
                {
                    yield return child;
                }

                yield return this.Value;
            }

            if (this.RightChild != null)
            {
                foreach (var child in this.RightChild)
                {
                    yield return child;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Node<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Node<T> other = (Node<T>)obj;
            return this.CompareTo(other) == 0;
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.EachInOrder(action);
            }

            action(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.EachInOrder(action);
            }
        }
    }
}
