using System;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new[] { 6, 7, 34, 12, 16, 69, 10 };
            InsertionSort(array);

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        // Bubble sorting algorithm. Worst-case and average complexity of O(n2). 
        // Ineffecient for large amount of data.
        private static void BubbleSort(int[] array)
        {
            bool flag = false;

            do
            {
                flag = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        flag = true;
                    }
                }
            }
            while (flag);
        }

        // Selection sorting algorithm. Complexity is O(n2) for best, average, and worst case scenarios.
        // Ineffecient for large amount of data.
        private static void SelectionSort(int[] array)
        {
            int minIndex;
            int temp;

            for (int i = 0; i < array.Length - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        // Insertion sorting algorithm. Complexity is O(n). In worst cases O(n2) - when it sorted in reverse direction.
        // Ineffecient for large amount of data.
        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j+1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
