using System;
using System.Collections.Generic;

namespace _01_PlayWithTrees
{
    public class Tree<T>
    {

        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>> Children { get; set; }

        public Tree(T value)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
        }

        public Tree(T value, Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                this.Parent = this;
            }
        }

        public void Each(Action<T> action)
        {
            action(this.Value);

            foreach (var child in this.Children)
            {
                child.Each(action);
            }
        }
        
    }
}
