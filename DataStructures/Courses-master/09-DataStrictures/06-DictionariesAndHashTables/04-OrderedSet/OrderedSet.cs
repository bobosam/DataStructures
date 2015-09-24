/*
 * Public Methods
 * [x] Count
 * [x] Clear()
 * [x] Add()
 * [x] Remove()
 * [x] Contains()
 * [x] Find()   
 * [x] Min()
 * [x] Max()
 * [x] EachInOrder(Action<T> action)
 * [x] PrintInorder()
 * [x] GetEnumerator()
 * 
 * Private methods
 * [x] Insert
 * [x] Delete
 */
using System;
using System.Collections;
using System.Collections.Generic;

class OrderedSet<T> : IEnumerable<T> where T : IComparable<T> 
{
    // Contains the root of the tree
    private Node<T> root;

    // Constructor of the tree
    public OrderedSet()
    {
        this.root = null;
        this.Count = 0;
    }
    public Node<T> Root 
    {
        get { return this.root; }
        set { this.root = value; }
    }

    public int Count { get; set; }

    /// <summary>
    /// Inserts new value in binary search tree
    /// </summary>
    /// <param name="value"> The value to be inserted </param>
    public void Add(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Cannot insert null value!");
        }
        if (!this.Contains(value))
        {
            this.Count++;
        }

        this.root = Insert(value, null, root);
    }

    /// <summary>
    /// Inserts node in the binary search tree by given value
    /// </summary>
    /// <param name="value"> the new value </param>
    /// <param name="parentNode"> the parent of the node </param>
    /// <param name="node"> current node (try insert in this position)</param>
    /// <returns></returns>
    private Node<T> Insert(T value, 
        Node<T> parentNode, Node<T> node)
    {
        // if position is empty --> insert the <node>
        if (node == null)
        {
            node = new Node<T>(value);
            node.Parent = parentNode;
        }
        else
        {
            int compareTo = value.CompareTo(node.Value);

            if (compareTo < 0)
            {
                node.LeftChild = Insert(value, node, node.LeftChild);
            }
            else if (compareTo > 0)
            {
                node.RightChild = Insert(value, node, node.RightChild);
            }
        }
        return node;
    }

    /// <summary>
    /// Finds the given value in the tree and returns the node
    /// </summary>
    /// <param name="value"> The value to be found </param>
    /// <returns></returns>
    public Node<T> Find(T value)
    {
        Node<T> currNode = this.root;

        while (currNode != null)
        {
            int compareTo = value.CompareTo(currNode.Value);
            if (compareTo < 0)
            {
                currNode = currNode.LeftChild;
            }
            else if (compareTo > 0)
            {
                currNode = currNode.RightChild;
            }
            else
            {
                break;
            }
        }
        return currNode;
    }

    /// <summary>
    /// Checks whether there is an element
    /// </summary>
    /// <param name="value">Тhe value of the element</param>
    /// <returns>true/false</returns>
    public bool Contains(T value)
    {
        var element = this.Find(value);
        return element != null;
    }

    /// <summary>
    /// Removes an element by value
    /// </summary>
    /// <param name="value">Тhe value of the element</param>
    public void Remove(T value)
    {
        Node<T> nodeToDelete = Find(value);
        if (nodeToDelete == null)
        {
            return;
        }

        Delete(nodeToDelete);
        this.Count--;
    }

    /// <summary>
    /// Delete an element by node
    /// </summary>
    /// <param name="nodeToDelete">Node to delete</param>
    private void Delete(Node<T> nodeToDelete)
    {
        // If node has two children
        if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
        {
            Node<T> replacement = nodeToDelete.RightChild;
            while (replacement.LeftChild != null)
            {
                replacement = replacement.LeftChild;
            }
            nodeToDelete.Value = replacement.Value;
            nodeToDelete = replacement;
        }

        // If the ndoe has at most one child
        Node<T> theChild = nodeToDelete.LeftChild != null ? nodeToDelete.LeftChild : nodeToDelete.RightChild;

        // If the element to be deleted has one child
        if (theChild != null)
        {
            theChild.Parent = nodeToDelete.Parent;

            // Handele the case when the element is the root
            if (nodeToDelete.Parent.Parent == null)
            {
                this.root = theChild;
            }
            else
            {
                // Repalce the element with its subtree
                if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                {
                    nodeToDelete.Parent.LeftChild = theChild;
                }
                else
                {
                    nodeToDelete.Parent.RightChild = theChild;
                }
            }
        }
        else
        {
            // Handle the case when the element is the root
            if (nodeToDelete.Parent == null)
            {
                this.root = null;
            }
            else
            {
                // Removes the element - it is a leaf
                if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                {
                    nodeToDelete.Parent.LeftChild = null;
                }
                else
                {
                    nodeToDelete.Parent.RightChild = null;
                }
            }
        }
    }

    /// <summary>
    /// Finds the minimum value in the set.
    /// If the set is empty - throws an exception.
    /// </summary>
    /// <returns>The minimum value</returns>
    public T Min()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException("Can not get Min() from empty OrderedSet!");
        }
        var currentNode = this.root;
        T minValue = default(T);
        while (currentNode != null)
        {
            minValue = currentNode.Value;
            currentNode = currentNode.LeftChild;
        }
        return minValue;
    }

    /// <summary>
    /// Finds the maximum value in the set.
    /// If the set is empty - throws an exception.
    /// </summary>
    /// <returns>The maximum value</returns>
    public T Max()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException("Can not get Max() from empty OrderedSet!");
        }
        var currentNode = this.root;
        T maxValue = default(T);
        while (currentNode != null)
        {
            maxValue = currentNode.Value;
            currentNode = currentNode.RightChild;
        }
        return maxValue;
    }

    /// <summary>
    /// Clears all elements from the OrderedSet
    /// </summary>
    public void Clear()
    {
        this.Root = null;
        this.Count = 0;
    }
   
    /// <summary>
    /// Prints the OrderedSet
    /// </summary>
    public void PrintInorder(Node<T> root)
    {
        if (root == null)
        {
            return;
        }

        PrintInorder(root.LeftChild);

        Console.Write(root.Value + " ");

        PrintInorder(root.RightChild);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.root.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.root.LeftChild != null)
        {
            this.root.LeftChild.EachInOrder(action);
        }

        action(this.root.Value);

        if (this.root.RightChild != null)
        {
            this.root.RightChild.EachInOrder(action);
        }
    }

}

