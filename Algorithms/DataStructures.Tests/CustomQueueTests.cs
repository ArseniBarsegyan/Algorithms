using DataStructures.CustomQueue;
using Xunit;

namespace DataStructures.Tests
{
    public class CustomQueueTests
    {
        [Fact]
        public void EmptyQueueShouldHaveZeroLength()
        {
            var queue = new CustomQueue<int>();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void QueueAddElementCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void QueueAddElementsCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(19);
            Assert.Equal(3, queue.Count);
        }

        [Fact]
        public void QueueRemoveElementCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Dequeue();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void QueueRemoveElementsCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(19);
            queue.Dequeue();
            queue.Dequeue();
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void QueueRemoveSeveralElementsCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(7);
            queue.Enqueue(18);
            queue.Enqueue(25);
            queue.Dequeue();
            var lastElement = queue.Dequeue();
            Assert.Equal(18, lastElement);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void QueuePeekElementCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(7);
            var lastElement = queue.Peek();
            Assert.Equal(7, lastElement);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void QueuePeekSeveralElementsWorkCorrectly()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(7);
            queue.Enqueue(9);
            queue.Enqueue(11);
            queue.Peek();
            queue.Peek();
            var lastElement = queue.Peek();
            Assert.Equal(7, lastElement);
            Assert.Equal(3, queue.Count);
        }
    }
}