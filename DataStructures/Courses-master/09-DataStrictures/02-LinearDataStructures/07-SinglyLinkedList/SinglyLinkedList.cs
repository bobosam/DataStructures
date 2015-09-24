using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/* 
 * [x] Class ListNode<T>
 * [x] Class LinkedList<T> 
 * [x] AddFirst(T item) - like Add()
 * [x] AddLast(T item)
 * [x] Remove(int index)
 * [x] RemoveElement(T item)
 * [x] FirstIndexOf(T item)
 * [x] LastIndexOf(T item)
 * [x] Indexator
 * [x] Count
 * [x] Clear()
 * [x] ToString()
 * [x] Enumerator
 * 
 */

public class SinglyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<E>
    {
        private E element;
        private ListNode<E> next;

        public E Element 
        { 
            get {return this.element;}
            set
            {
                this.element = value;
            }
        }

        public ListNode<E> Next 
        {
            get { return this.next; }
            set
            {
                this.next = value;
            }
        }

        public ListNode(E element)
        {
            this.Element = element;
            this.Next = null;
        }

        public ListNode(E element, ListNode<E> prevNode)
        {
            this.Element = element;
            prevNode.Next = this;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;
    private int count;

    public int Count
    {
        get { return this.count; }
    }

    public SinglyLinkedList()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    public void AddLast(T item)
    {
        if (head == null)
        {
            head = new ListNode<T>(item);
            tail = head;
        }
        else
        {
            ListNode<T> newNode = new ListNode<T>(item, tail);
            tail = newNode;
        }
        count++;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void AddFirst(T item)
    {
        if (this.head == null)
        {
            this.head = new ListNode<T>(item);
            tail = head;
        }
        else
        {
            ListNode<T> newNode = new ListNode<T>(item);
            newNode.Next = this.head;
            this.head = newNode;
        }
        this.count++;
    }

    public void Clear()
    {
        this.head = null;
        this.count = 0;
    }

    /// <summary>
    /// Removes and returns element on the specific index
    /// </summary>
    /// <param name="index">
    /// The index of element you want  to remove
    /// </param>
    /// <returns>The removed element</returns>
    public T Remove(int index)
    {
        if (index >= count || index < 0)
        {
            throw new ArgumentOutOfRangeException("Ivalid index: " + index);
        }

        int currIndex = 0;
        ListNode<T> currNode = head;
        ListNode<T> prevNode = null;

        while (currIndex < index)
        {
            prevNode = currNode;
            currNode = currNode.Next;
            currIndex++;
        }

        // Removes the element
        count--;

        if (count == 0)
        {
            head = null;
        }
        else if (prevNode == null)
        {
            head = currNode.Next;
        }
        else
        {
            prevNode.Next = currNode.Next;
        }

        // Finds the last Node and sets the tail
        ListNode<T> lastNode = null;

        if (this.head != null)
        {
            lastNode = this.head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
        }
        tail = lastNode;

        return currNode.Element;
    }

    /// <summary>
    /// Removes the first occurrence of the item
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int RemoveElement(T item)
    {
        if (FirstIndexOf(item) < 0)
        {
            throw new ArgumentException("Element does not exists");
        }

        int indexOfItem = FirstIndexOf(item);

        if (this.head == null)
        {
            throw new InvalidOperationException("Cannot remove element from empty list.");
        }
        else if (item.Equals(this.head.Element))
        {
            this.head = this.head.Next;
        }
        else
        {
            var currNode = this.head;
            ListNode<T> prevNode = new ListNode<T>(item);
            while (!currNode.Element.Equals(item))
            {
                prevNode = currNode;
                currNode = currNode.Next;
            }

            prevNode.Next = currNode.Next;
        }

        count--;

        // Finds the last element and sets tail

        var tempNode = this.head;

        if (head != null)
        {
            while (tempNode.Next != null)
            {
                tempNode = tempNode.Next;
            }
        }

        tail = tempNode;

        return indexOfItem;
    }

    /// <summary>
    /// Searches for given element in the list
    /// </summary>
    /// <param name="item"></param>
    /// <returns>
    /// the index of the first occurence of the element
    /// in the list or -1 of not found
    /// </returns>
    public int FirstIndexOf(T item)
    {
        var currIndex = 0;
        var currNode = this.head;

        while (currIndex < this.count)
        {
            if (currNode.Element.Equals(item))
            {
                return currIndex;
            }
            currNode = currNode.Next;
            currIndex++;
        }

        return -1;
    }

    /// <summary>
    /// Searches for given element in the list
    /// </summary>
    /// <param name="item"></param>
    /// <returns>
    /// the index of the last occurence of the element
    /// in the list or -1 of not found
    /// </returns>
    public int LastIndexOf(T item)
    {
        var currIndex = 0;
        var currNode = this.head;
        int lastIndex = -1;

        while (currIndex < this.count)
        {
            if (currNode.Element.Equals(item))
            {
                lastIndex = currIndex;
            }
            currNode = currNode.Next;
            currIndex++;
        }

        return lastIndex;
    }


    // Indexator
    public T this[int index]
    {
        get
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }
            ListNode<T> currNode = this.head;
            for (int i = 0; i < index; i++)
            {
                currNode = currNode.Next;
            }
            return currNode.Element;
        }
        set
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }
            ListNode<T> currNode = this.head;
            for (int i = 0; i < index; i++)
            {
                currNode = currNode.Next;
            }
            currNode.Element = value;
        }
    }

    /// <summary>
    /// Overrides default toString() method
    /// </summary>
    /// <returns>
    /// String representation of the DynamicList object if format [item(1), item(2), ... item(n) ]
    /// </returns>
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        ListNode<T> currNode = this.head;

        while (currNode != null)
        {
            result.Append(currNode.Element);

            if (currNode.Next != null)
            {
                result.Append(", ");

            }
            currNode = currNode.Next;
        }

        return String.Format("[{0}]", result.ToString());
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.head;
        while (node != null)
        {
            yield return node.Element;
            node = node.Next;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}