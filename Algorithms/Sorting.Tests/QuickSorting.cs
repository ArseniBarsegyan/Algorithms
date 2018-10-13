using Xunit;

namespace Sorting.Tests
{
    public class QuickSorting
    {
        [Fact]
        public void QuickSortingTest1()
        {
            int[] array = { 5, 3 };
            int[] expectedArray = { 3, 5 };
            int[] sortedArray = array.QuickSort(0, array.Length);
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void QuickSortingTest2()
        {
            int[] array = { 3, 5, 3 };
            int[] expectedArray = { 3, 3, 5 };
            int[] sortedArray = array.QuickSort(0, array.Length);
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void QuickSortingTest3()
        {
            int[] array = { 3, 5, 3 };
            int[] expectedArray = { 3, 3, 5 };
            int[] sortedArray = array.QuickSort(0, array.Length);
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void QuickSortingTest4()
        {
            int[] array = { 5, 3, 3 };
            int[] expectedArray = { 3, 3, 5 };
            int[] sortedArray = array.QuickSort(0, array.Length);
            Assert.Equal(expectedArray, sortedArray);
        }

        [Fact]
        public void QuickSortingTest5()
        {
            int[] array = { 3, 5, 10, 1, 2, 67, 14, 99, 6, 3 };
            int[] expectedArray = { 1, 2, 3, 3, 5, 6, 10, 14, 67, 99 };
            int[] sortedArray = array.QuickSort(0, array.Length);
            Assert.Equal(expectedArray, sortedArray);
        }
    }
}