using System;
/* [x] Count
 * [x] Push()
 * [x] Pop()
 * [x] Peek()
 * [x] Clear()
 * [x] Contains()
 * [x] ToArray()
 * [x] OptimizeCapacity()
 */
namespace _03_ArrayStack
{
    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private int count;
        private T[] elements;
        private int top;

        public ArrayStack()
        {
            this.elements = new T[InitialCapacity];
        }

        public ArrayStack(int InitialCapacity)
        {
            this.elements = new T[InitialCapacity];
        }


        public int Count
        {
            get { return this.count; }
        }

        public void Push(T item)
        {
            if (count == this.elements.Length)
            {
                OptimizeCpacity(true);
            }
            this.elements[top] = item;
            top++;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Cannot Pop() value from empty stack!");
            }
            top--;
            count--;
            var returnValue = this.elements[top];
            this.elements[top] = default(T);


            if (count <= elements.Length / 2)
            {
                OptimizeCpacity(false);
            }
            return returnValue;
        }

        public T Peek()
        {
            return this.elements[top - 1];
        }

        public void Clear()
        {
            this.elements = new T[InitialCapacity];
            this.count = 0;
            this.top = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < top; i++)
            {
                if (elements[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            for (int i = 0; i < this.count; i++)
            {
                array[i] = this.elements[this.count - i - 1];
            }
            return array;
        }

        // Implements Grow/Compress Array for size optimization
        private void OptimizeCpacity(bool increase)
        {
            T[] newStack = null;

            if (increase)
            {
                newStack = new T[this.elements.Length * 2];
            }
            else
            {
                newStack = new T[this.elements.Length / 2];
            }

            for (int i = 0; i < top; i++)
            {
                newStack[i] = elements[i];
            }

            this.elements = newStack;
        }
    }
}