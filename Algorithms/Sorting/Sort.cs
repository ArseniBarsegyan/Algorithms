using System;

namespace Sorting
{
    public static class Sort
    {
        /// <summary>
        /// Bubble sorting algorithm. Worst-case and average complexity of O(n2). Ineffecient for large amount of data.
        /// </summary>
        /// <param name="array">input array.</param>
        public static int[] BubbleSort(this int[] array)
        {
            bool flag;

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
            return array;
        }

        /// <summary>
        /// Selection sorting algorithm. Complexity is O(n2) for best, average, and worst case scenarios.
        /// <para>
        /// Ineffecient for large amount of data.
        /// </para>
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] SelectionSort(this int[] array)
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
            return array;
        }
         
        /// <summary>
        /// Insertion sorting algorithm. Complexity is O(n). In worst cases O(n2) - when it sorted in reverse direction.
        /// <para>
        /// Ineffecient for large amount of data.
        /// </para>
        /// </summary>
        /// <param name="array"></param>
        public static int[] InsertionSort(this int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            return array;
        }

        /// <summary>
        /// Merge sorting algorithm. Complexity is O(n*log(n)). 
        /// <para>
        /// Useful for sorting linked lists, for arrays need extra temporary storage space for each half during iteration.
        /// </para>
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] MergeSort(this int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        public static int[] MergeSort(this int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
            return array;
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

            while (i < n1 && j < n2)
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

            while (i < n1)
            {
                array[k] = Left[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                array[k] = Right[j];
                j++;
                k++;
            }
        }

        /// <summary>
        /// QuickSort sorting algorithm with random pivot. 
        /// <para>
        /// Quite efficient for large-sized data sets and its average and worst case complexity are of O(n2), where n - number of items.
        /// </para> 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left">index of element to start with</param>
        /// <param name="right">last element to end with</param>
        public static int[] QuickSort(this int[] array, int left, int right)
        {
            int l = left;
            int r = right - 1;
            int size = right - left;

            if (size > 1)
            {
                Random random = new Random();
                int pivot = array[random.Next(0, size) + l];

                while (l < r)
                {
                    while (array[r] > pivot && r > l)
                    {
                        r--;
                    }
                    while (array[l] < pivot && l <= r)
                    {
                        l++;
                    }
                    if (l < r)
                    {
                        int temp = array[l];
                        array[l] = array[r];
                        array[r] = temp;
                        l++;
                    }
                }
                QuickSort(array, left, l);
                QuickSort(array, r, right);
            }
            return array;
        }
    }
}