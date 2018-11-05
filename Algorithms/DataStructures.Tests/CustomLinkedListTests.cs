using DataStructures.CustomLinkedList;
using Xunit;

namespace DataStructures.Tests
{
    public class CustomLinkedListTests
    {
        [Fact]
        public void EmptyListShouldHaveZeroLength()
        {
            var list = new CustomLinkedList<int>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void LinkedListAddElementsCorrectly()
        {
            var list = new CustomLinkedList<int>();
            list.Add(2);
            list.Add(5);
            list.Add(4);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void LinkedListRemoveElementsCorrectly()
        {
            var list = new CustomLinkedList<int>();
            list.Add(2);
            list.Add(5);
            list.Add(4);
            
            list.Remove(4);
            list.Remove(2);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void LinkedListContainsShouldReturnTrueIfElementExistsInList()
        {
            var list = new CustomLinkedList<int>();
            list.Add(2);
            list.Add(5);
            list.Add(9);

            Assert.True(list.Contains(5));
        }

        [Fact]
        public void LinkedListContainsShouldReturnFalseIfElementNotExistsInList()
        {
            var list = new CustomLinkedList<int>();
            list.Add(2);
            list.Add(5);
            list.Add(9);

            Assert.False(list.Contains(11));
        }

        [Fact]
        public void LinkedListContainsShouldReturnFalseIfElementWasRemovedFromList()
        {
            var list = new CustomLinkedList<int>();
            list.Add(2);
            list.Add(5);
            list.Add(9);
            list.Remove(5);

            Assert.False(list.Contains(5));
        }
    }
}