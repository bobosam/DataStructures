using System;
using _05_LinkedStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_LinkedStackTests
{
    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void TestPushPopElement()
        {
            var stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);

            stack.Push(1);
            Assert.AreEqual(1, stack.Count);

            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestPush_1000_Elements()
        {
            var stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i + 1, stack.Count);
            }

            for (int i = 0; i < 1000; i++)
            {
                stack.Pop();
                Assert.AreEqual(1000 - i - 1, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestPopFromEmptyStack()
        {
            var stack = new LinkedStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void TestStackToArrayAfterPushingNubers()
        {
            var stack = new LinkedStack<int>();
            int[] arrayWithOrigins = { 3, 5, -2, 7 };

            for (int i = 0; i < arrayWithOrigins.Length; i++)
            {
                stack.Push(arrayWithOrigins[i]);
            }

            int[] stackToArray = stack.ToArray();

            for (int i = 0; i < arrayWithOrigins.Length; i++)
            {
                Assert.AreEqual(arrayWithOrigins[stack.Count - i - 1], stackToArray[i]);
            }
        }

        [TestMethod]
        public void TestEmptyStackToArray()
        {
            var stack = new LinkedStack<DateTime>();
            DateTime[] array = stack.ToArray();

            Assert.AreEqual(0, array.Length);
        }

        [TestMethod]
        public void TestPeakAfterPushPopElement()
        {
            var stack = new LinkedStack<int>();

            stack.Push(10);
            stack.Push(20);
            Assert.AreEqual(20, stack.Peek());
            stack.Pop();
            Assert.AreEqual(10, stack.Peek());
        }

        [TestMethod]
        public void TestCountAfterPushing()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        public void TestCountAfterPoping()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            stack.Pop();
            Assert.AreEqual(1, stack.Count);
        }    
    }
}
