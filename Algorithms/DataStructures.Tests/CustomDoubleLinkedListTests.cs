using DataStructures.CustomDoubleLinkedList;
using Xunit;

namespace DataStructures.Tests
{
    public class CustomDoubleLinkedListTests
    {
        [Fact]
        public void AddMethodShouldAddElementCorrectly()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(4);
            list.Add(6);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void AddFirstMethodShouldAddElementCorrectly()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(4);
            list.AddFirst(6);
            Assert.Equal(6, list.First);
        }

        [Fact]
        public void RemoveMethodShouldWorkCorrectly()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(4);
            list.Add(6);
            list.Remove(4);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfElementExistsInList()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(4);
            list.Add(6);
            
            Assert.True(list.Contains(4));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfElementNotExistsInList()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(4);
            list.Add(6);
            list.Remove(4);

            Assert.False(list.Contains(4));
        }

        [Fact]
        public void SwapShouldWorkCorrectlyForFirstAndLastElementsInList()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(5);
            list.Swap(1, 5);

            Assert.Equal(5, list.First);
            Assert.Equal(1, list.Last);
        }

        [Fact]
        public void SwapShouldWorkCorrectlyForFirstElementAndElementInTheMiddle()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Swap(1, 3);

            Assert.Equal(3, list.First);
            Assert.Equal(5, list.Last);
        }

        [Fact]
        public void SwapShouldWorkCorrectlyForLastElementAndElementInTheMiddle()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Swap(3, 5);

            Assert.Equal(1, list.First);
            Assert.Equal(3, list.Last);
        }

        [Fact]
        public void SwapShouldWorkCorrectlyForNearbyElements()
        {
            var list = new CustomDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Swap(4, 5);

            Assert.Equal(4, list.Last);
        }
    }
}