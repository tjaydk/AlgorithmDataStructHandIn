using Doubling.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubling
{
    class Program
    {
        private static long selSortActualTime = 0;
        private static long insSortActualTime = 0;
        private static long mergeSortActualTime = 0;
        private static MergeSort<int> mergeSort = new MergeSort<int>();
        private static SelectionSort<int> selSort = new SelectionSort<int>();
        private static InsertionSort<int> insSort = new InsertionSort<int>();

        static void Main(string[] args)
        {
            
            int n = 1000; // sets the initial N value
            int iterations = 5;

            

            for (int i = 1; i <= iterations; i++)
            {

                calculateTimesForInsertionSort(n, i);
                calculateTimesForSelectionSort(n, i);
                hypothesizeOnMergeSort(n, i);

                //double N for next iteration
                n = n * 2;
            }

            while (true) { }
        }

        public static void calculateTimesForInsertionSort(int n, int i)
        {
            Stopwatch watch = new Stopwatch();

            int[] randomArray = generateRandomArray(n);
            int[] selSortArr;

            watch.Start();
            selSortArr = (int[])selSort.sort(randomArray);
            watch.Stop();
            //on first iteration we store the time, and every other iteration we can calculate expected and will print it
            if (i == 1)
            {
                selSortActualTime = watch.ElapsedMilliseconds;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Selection Sort on " + n + " sized array.");
                //use the value from last iteration and quadrate it
                Console.WriteLine("Expected time for sorting was: " + (selSortActualTime * 4) + "ms");
                //set the new time and print it as the actual time
                selSortActualTime = watch.ElapsedMilliseconds;
                Console.WriteLine("Actual time for sorting was: " + selSortActualTime);
            }
        }

        public static void calculateTimesForSelectionSort(int n, int i)
        {
            Stopwatch watch = new Stopwatch();

            int[] randomArray = generateRandomArray(n);
            int[] insSortArr;

            watch.Start();
            insSortArr = (int[])insSort.sort(randomArray);
            watch.Stop();
            //on first iteration we store the time, and every other iteration we can calculate expected and will print it
            if (i == 1)
            {
                insSortActualTime = watch.ElapsedMilliseconds;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Insertion Sort on " + n + " sized array.");
                //use the value from last iteration and quadrate it
                Console.WriteLine("Expected time for sorting was: " + (insSortActualTime * 4) + "ms");
                //set the new time and print it as the actual time
                insSortActualTime = watch.ElapsedMilliseconds;
                Console.WriteLine("Actual time for sorting was: " + insSortActualTime);
            }
        }

        public static void hypothesizeOnMergeSort(int n, int i)
        {
            Stopwatch watch = new Stopwatch();

            int[] randomArray = generateRandomArray(n);
            int[] mergeSortArr;

            watch.Start();
            mergeSortArr = (int[])mergeSort.sort(randomArray);
            watch.Stop();

            if (i == 1)
            {
                mergeSortActualTime = watch.ElapsedMilliseconds;
            } else
            {
                Console.WriteLine();
                Console.WriteLine("Merge Sort on " + n + " sized array.");
                Console.WriteLine("Actual time for sorting was: " + watch.ElapsedMilliseconds);

                double ratio = ((double)mergeSortActualTime / (double)watch.ElapsedMilliseconds);
                
                Console.WriteLine("Ratio was: " + ratio);

                //set the new actual time
                mergeSortActualTime = watch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// TReturns int array of size N filled with random numbers between 0-9
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] generateRandomArray(int n)
        {
            Random ran = new Random();
            int[] randomArray = new int[n];
            for (int j = 0; j < n; j++)
            {
                randomArray[j] = ran.Next(10);
            }
            return randomArray;
        }
    }
}
