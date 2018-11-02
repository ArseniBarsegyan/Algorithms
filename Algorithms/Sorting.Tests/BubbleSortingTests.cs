using Xunit;

namespace Sorting.Tests
{
    public class BubbleSortingTests
    {
        [Fact]
        public void BubbleTest1()
        {
            int[] array = { 5, 3 };
            int[] expectedArray = { 3, 5 };
            int[] sortedArray = array.BubbleSort(); ;
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void BubbleTest2()
        {
            int[] array = { 3, 5, 3 };
            int[] expectedArray = { 3, 3, 5 };
            int[] sortedArray = array.BubbleSort(); ;
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void BubbleTest3()
        {
            int[] array = { 3, 5, 3 };
            int[] expectedArray = { 3, 3, 5 };
            int[] sortedArray = array.BubbleSort(); ;
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void BubbleTest4()
        {
            int[] array = { 5, 3, 3 };
            int[] expectedArray = { 3, 3, 5 };
            int[] sortedArray = array.BubbleSort(); ;
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void BubbleTest5()
        {
            int[] array = { 3, 5, 10, 1, 2, 67, 14, 99, 6, 3 };
            int[] expectedArray = { 1, 2, 3, 3, 5, 6, 10, 14, 67, 99 };
            int[] sortedArray = array.BubbleSort(); ;
            Assert.Equal(expectedArray, sortedArray);
        }
    }
}
