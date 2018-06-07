using System;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new[] { 6, 7, 34, 12, 16, 69, 10 };
            MergeSort(array);

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        // Bubble sorting algorithm. Worst-case and average complexity of O(n2). 
        // Ineffecient for large amount of data.
        public static void BubbleSort(int[] array)
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
        public static void SelectionSort(int[] array)
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
        public static void InsertionSort(int[] array)
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

        // Merge sorting algorithm. Complexity is O(n*log(n)). 
        // Useful for sorting linked lists, for arrays need extra temporary storage space for each half during iteration.
        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] Left = new int[n1];
            int[] Right = new int[n2];

            // Copy elements from array to new arrays (divide on 2 parts)
            for (int ii = 0; ii < n1; ii++)
            {
                Left[ii] = array[left + ii];
            }

            for (int ii = 0; ii < n2; ii++)
            {
                Right[ii] = array[middle + 1 + ii];
            }

            int i = 0, j = 0, k = left;

            while(i < n1 && j < n2)
            {
                if (Left[i] <= Right[j])
                {
                    array[k] = Left[i];
                    i++;
                }
                else
                {
                    array[k] = Right[j];
                    j++;
                }
                k++;
            }

            while(i < n1)
            {
                array[k] = Left[i];
                i++;
                k++;
            }
            while(j < n2)
            {
                array[k] = Right[j];
                j++;
                k++;
            }
        }
    }
}
