using System;
using _07_LinkedQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_LinkedQueue.Tests
{
    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void TestEnqueueDequeueElement()
        {
            var queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Count);

            queue.Dequeue();
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestEnqueue_1000_Elements()
        {
            var queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(i);
                Assert.AreEqual(i + 1, queue.Count);
            }

            for (int i = 0; i < 1000; i++)
            {
                queue.Dequeue();
                Assert.AreEqual(1000 - i - 1, queue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestDequeueFromEmptyStack()
        {
            var queue = new LinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void TestQueueToArrayAfterEnqueueNubers()
        {
            var queue = new LinkedQueue<int>();
            int[] arrayWithOrigins = { 3, 5, -2, 7 };

            for (int i = 0; i < arrayWithOrigins.Length; i++)
            {
                queue.Enqueue(arrayWithOrigins[i]);
            }

            int[] stackToArray = queue.ToArray();

            for (int i = 0; i < arrayWithOrigins.Length; i++)
            {
                Assert.AreEqual(arrayWithOrigins[i], stackToArray[i]);
            }
        }

        [TestMethod]
        public void TestEmptyQueueToArray()
        {
            var queue = new LinkedQueue<DateTime>();
            DateTime[] array = queue.ToArray();

            Assert.AreEqual(0, array.Length);
        }

        [TestMethod]
        public void TestCountAfterEnqueue()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod]
        public void TestCountAfterDequeue()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(1, queue.Count);
        }
    }
}
