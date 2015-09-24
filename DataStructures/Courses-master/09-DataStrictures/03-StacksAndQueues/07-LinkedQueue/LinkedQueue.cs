using System;
/*
 * [x] Count
 * [x] Enqueue()
 * [x] Dequeue()
 * [x] ToArray()
 */
namespace _07_LinkedQueue
{
    public class LinkedQueue<T>
    {
        private class Node<V>
        {
            private V value;
            private Node<V> next;

            public Node(V value)
            {
                this.value = value;
            }

            public Node(V element, Node<V> prevNode)
            {
                this.value = element;
                prevNode.next = this;
            }

            public V Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public Node<V> Next
            {
                get { return this.next; }
                set { this.next = value; }
            }
        }

        private int count;
        private Node<T> tail;
        private Node<T> head;

        public LinkedQueue()
        {
            this.count = 0;
            this.head = null;
            this.tail = null;
        }

        /// <summary>
        /// Returns the size of the queue
        /// </summary>
        public int Count
        {
            get { return this.count; }
        }

        /// <summary>
        /// Adds element on top of the queue
        /// </summary>
        /// <param name="item">
        /// The value of the element to add
        /// </param>
        public void Enqueue(T item)
        {
            if (head == null)
            {
                this.head = new Node<T>(item);
                tail = head;
            }
            else
            {
                var newNode = new Node<T>(item, tail);
                tail = newNode;
            }
            count++;
        }

        /// <summary>
        /// Removes and returns the head element of the queue
        /// </summary>
        /// <returns> Head element </returns>
        public T Dequeue()
        {
            var headItem = this.head.Value;

            if (count == 0)
            {
                throw new InvalidOperationException("Cannot Pop() item from empty queue!");
            }
            else
            {
                this.head = this.head.Next;
                count--;
            }
            return headItem;
        }

        public T[] ToArray()
        {
            var arr = new T[this.count];
            var currNode = this.head;
            int currIndex = 0;

            while (currNode != null)
            {
                arr[currIndex] = currNode.Value;
                currNode = currNode.Next;
                currIndex++;
            }

            return arr;
        }
    }
}
