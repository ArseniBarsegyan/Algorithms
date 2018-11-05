using DataStructures.CustomStack;
using Xunit;

namespace DataStructures.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void EmptyStackShouldHaveZeroLength()
        {
            var queue = new CustomStack<int>();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void StackPushElementCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void StackPushElementsCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(3);
            stack.Push(9);
            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void StackPopElementCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Pop();
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void StackPopElementsCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(3);
            stack.Push(9);
            var lastElement = stack.Pop();
            Assert.Equal(2, stack.Count);
            Assert.Equal(9, lastElement);
        }

        [Fact]
        public void StackPeekElementCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Peek();
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void StackPeekElementsCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(3);
            stack.Push(9);
            stack.Peek();
            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void StackPopSeveralElementsWorkCorrectly()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(3);
            stack.Push(9);
            stack.Pop();
            var lastElement = stack.Pop();
            Assert.Equal(3, lastElement);
            Assert.Equal(1, stack.Count);
        }
    }
}
