/*
 * [x] Override ToString()
 * [x] Override GetHashCode()
 * [x] Override CompareTo()
 * [x] Override Equals()
 * [x] GetEnumerator()
 * [x] EachInOrder(Action<T> action)
 */
using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T> : IEnumerable<T>, IComparable<Node<T>> where T : IComparable<T>//, 
{
    // Contains the value of the node
    private T value;

    // Contains the parent of the node
    private Node<T> parent;

    // Contains the left child of the node
    private Node<T> leftChild;

    // Contains the right child of the node
    private Node<T> rightChild;

    /// <summary>
    /// Construct the tree node
    /// </summary>
    /// <param name="value">The value of the tree node</param>
    public Node(T value)
    {
        this.value = value;
        this.parent = null;
        this.leftChild = null;
        this.rightChild = null;
    }

    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }
    public Node<T> Parent
    {
        get 
        {
            return this.parent;
        }
        set 
        {
            this.parent = value;
        }
    }
    public Node<T> LeftChild
    {
        get 
        {
            return this.leftChild;
        }
        set 
        {
            this.leftChild = value;
        }
    }
    public Node<T> RightChild
    {
        get
        {
            return this.rightChild;
        }
        set 
        {
            this.rightChild = value;
        }
    }

    public override string ToString()
    {
        return this.value.ToString();
    }

    public override int GetHashCode()
    {
        return this.value.GetHashCode();
    }

    public int CompareTo(Node<T> other)
    {
        return this.value.CompareTo(other.value);
    }

    public override bool Equals(object obj)
    {
        Node<T> other = (Node<T>)obj;
        return this.CompareTo(other) == 0;
    }

    public IEnumerator<T> GetEnumerator()
    {

        if (LeftChild != null)
        {
            foreach (var child in LeftChild)
                yield return child;
        }

        yield return value;

        if (RightChild != null)
        {
            foreach (var child in RightChild)
                yield return child;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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

