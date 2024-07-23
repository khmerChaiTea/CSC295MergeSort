using System;
using System.Diagnostics;

namespace CSC295MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            //// CTRL + K + C = shortcut for comment
            //int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            //int[] arr2 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            //int[] arr3 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            //int[] arrSorted1 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            //int[] arrSorted2 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            //int[] arrSorted3 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //InsertionSort(arr1);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Insertion Sort: {stopwatch.ElapsedTicks}");

            //stopwatch.Restart();
            //stopwatch.Start();
            //BubbleSort(arr2);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Bubble Sort: {stopwatch.ElapsedTicks}");

            //stopwatch.Restart();
            //stopwatch.Start();
            //SelectionSort(arr3);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Selection Sort: {stopwatch.ElapsedTicks}");

            //Console.WriteLine("Please select a sorting algorithm");
            //Console.WriteLine("1: Bubble Sort");
            //Console.WriteLine("2: Selection Sort");
            //Console.WriteLine("3: Insertion Sort");
            //Console.WriteLine("4: Merge Sort");

            //string? userSelection = Console.ReadLine();

            //Student student1 = new Student("Melissa", 4.0);
            //Student student2 = new Student("Rich", 3.0);
            //Student student3 = new Student("Adam", 3.8);

            //Student[] students = { student1, student2, student3 };

            //switch (userSelection)
            //{
            //    case "1":
            //        BubbleSort(students);
            //        break;
            //    case "2":
            //        // call selection sort method
            //        break;
            //    case "3":
            //        // call insertion sort method
            //        break;
            //    default:
            //        // none of the cases matched
            //        break;
            //}

            //PrintArray(students);

            int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
            //MergeSort(mergeArray);
            //Console.WriteLine();
            QuickSort(mergeArray);
            Console.WriteLine();
        }

        public static void QuickSort(int[] arr)
        {
            if (arr == null) return;
            if (arr.Length == 0) return;
            QuickSortHelper(arr, 0, arr.Length - 1);
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        public static void PrintArray(Student[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item.name}: {item.gpa} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Utilizes a quick sort algotihm to sort the passed in array
        /// </summary>
        /// <param name="arr"> the array which should be sorted </param>
        /// <param name="low"> the smaller index of the (sub)array</param>
        /// <param name="high"> the larger index of the (sub)array</param>
        public static void QuickSortHelper(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition return pivot location to us
                int pivotIndex = Partition(arr, low, high);

                // Call QuickSort again on the new subarrays passed on pivots position
                QuickSortHelper(arr, low, pivotIndex - 1);
                QuickSortHelper(arr, pivotIndex + 1, high);
            }
        }

        public static int Partition(int[] arr, int low, int high) 
        {
            int pivot = arr[high];  // setting pivot as last value
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot) 
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, ++i, high);
            return i;
        }

        public static void Swap(int[] arr, int i, int j) 
        {
            // Swap - could also move this into a helper method
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        // Responsible for splitting the array up and then merged them together
        // Called itself recursively
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;    // example of early return

            int mid = arr.Length / 2;
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                leftSubArray[i] = arr[i];
            }

            for (int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i - mid] = arr[i];
            }

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);
            Merge(arr, leftSubArray, rightSubArray);
        }

        public static void Merge(int[] arr, int[] leftArr, int[] rightArr)
        {
            int arrIndex = 0, leftIndex = 0, rightIndex = 0;

            // While the leftArr has values and the right array has values
            // we will evaluate which value is lesser - and make assignments
            while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
            {
                if (leftArr[leftIndex] <= rightArr[rightIndex])
                {
                    arr[arrIndex++] = leftArr[leftIndex++];
                }
                else
                {
                    arr[arrIndex++] = rightArr[rightIndex++];
                }
            }

            // Copy remaining elements from left array, if any
            while(leftIndex < leftArr.Length)
            {
                arr[arrIndex++] = leftArr[leftIndex++];
            }

            // Copy remaining elements from right array, if any
            while (rightIndex < rightArr.Length)
            {
                arr[arrIndex++] = rightArr[rightIndex++];
            }
        }

        public static void InsertionSort(int[] arr)
        {
            // A for loop to iterate the array to sort the elements
            // Overall worst case scenario O(n ^ 2)
            // Best case scenario O(n)
            for (int i = 1; i < arr.Length; i++)    // O(n) <--- O(n - 1)
            {
                // Temporary store an elements in the 'temp' variable
                int temp = arr[i];

                // Evaluate the elements to the left of the array with 'temp' element
                // In this case we start at index 1 and the array started with index 0
                int priorIndex = i - 1;

                // If out prior element is greater than our stored ('temp') element
                // and we have not reached the end of the array
                while (priorIndex >= 0 && arr[priorIndex] > temp)   // O(n)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                arr[priorIndex + 1] = temp;

            }
            Console.WriteLine();
        }

        public static int BubbleSort(int[] arr)
        {
            int totalOuterIterations = 0;
            int temp;
            // Overall O(n^2) runtime - Big O
            // Big Omega - O(n^2)
            for (int i = 0; i < arr.Length - 1; i++) // O(n) how many times we need to go though the unsorted array
            {
                totalOuterIterations++;
                int swaps = 0;
                for (int j = 0; j < arr.Length - 1 - i; j++)  // O(n)
                {
                    // we need to swap
                    if (arr[j] > arr[j + 1])           // can modify if '>' change to '<'
                    {
                        swaps++;
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }

                if (swaps == 0) break; // break out of the for loop
            }

            return totalOuterIterations;
        }

        public static void BubbleSort(Student[] arr)
        {
            Student temp;
            for (int i = 0; i < arr.Length - 1; i++) // how many times we need to go though the unsorted array  
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    // we need to swap  
                    if (arr[j].gpa < arr[j + 1].gpa)
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            // minIndex keeps track of the smallest index in each iteration
            // temp is used as temporary storage
            int minIndex, temp;

            // O(n) how many times we need to go though the unsorted array
            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i; // set the minIndex equal to current smallest index
                for (int j = i; j < arr.Length; j++) // loop through each element starting at i
                {
                    // if the element is smaller than the current minIndex
                    if (arr[j] < arr[minIndex])
                    {
                        // swap
                        minIndex = j;
                    }
                }

                // swap elements
                // swap current i (which is smallest position with the smallest/min element)
                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
}