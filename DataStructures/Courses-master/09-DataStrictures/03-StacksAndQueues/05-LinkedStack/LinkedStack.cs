using System;
/*
 *  [x] Count
 *  [x] Push()
 *  [x] Pop()
 *  [x] Peak()
 *  [x] ToArray()
 */
namespace _05_LinkedStack
{
    public class LinkedStack<T>
    {
        private class Node<E>
        {
            private E value;
            private Node<E> next;

            public Node(E value)
            {
                this.value = value;
            }

            public E Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public Node<E> Next
            {
                get { return this.next; }
                set { this.next = value; }
            }
        }

        private int count;
        private Node<T> head;

        public LinkedStack()
        {
            this.count = 0;
            this.head = null;
        }

        /// <summary>
        /// Returns the size of the stack
        /// </summary>
        public int Count
        {
            get { return this.count; }
        }

        /// <summary>
        /// Adds element on top of the stack
        /// </summary>
        /// <param name="value">
        /// The value of the element to add
        /// </param>
        public void Push(T value)
        {
            var newNode = new Node<T>(value);

            if (head == null)
            {
                this.head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }

        /// <summary>
        /// Removes and returns the top value of the stack
        /// </summary>
        /// <returns> Top element </returns>
        public T Pop()
        {
            var topValue = head.Value;
            this.head = head.Next;
            this.count--;

            return topValue;
        }

        /// <summary>
        /// Returns the top value of the stack
        /// </summary>
        /// <returns> Top element </returns>
        public T Peek()
        {
            return this.head.Value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.count];
            Node<T> currNode = this.head;
            int currIdex = 0;

            while (currNode != null)
            {
                array[currIdex] = currNode.Value;
                currNode = currNode.Next;
                currIdex++;
            }

            return array;
        }
    }
}