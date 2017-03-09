using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubling.SortingAlgorithms
{
    public class InsertionSort<T> where T : IComparable<T>
    {
        public IList<T> sort(IList<T> a)
        { 
            // Sort a[] into increasing order.
            int N = a.Count;
            for (int i = 1; i < N; i++)
            { 
                // Insert a[i] among a[i-1], a[i-2], a[i-3]... ..
                for (int j = i; j > 0 && less(a[j], a[j - 1]); j--)
                    exch(a, j, j - 1);
            }
            return a;
        }

        private bool less(T v, T w)
        {
            return v.CompareTo(w) < 0;
        }


        private void exch<T>(IList<T> a, int i, int j)
        {
            T t = a[i]; a[i] = a[j]; a[j] = t;
        }

        private static void show<T>(IList<T> a)
        { 
            // Print the array, on a single line.
            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(a[i] + " ");
            Console.WriteLine();
        }

        public bool isSorted(IList<T> a)
        { 
            // Test whether the array entries are in order.
            for (int i = 1; i < a.Count; i++)
                if (less(a[i], a[i - 1])) return false;
            return true;
        }
    }
}
