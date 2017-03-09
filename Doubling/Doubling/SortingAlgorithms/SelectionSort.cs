using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubling.SortingAlgorithms
{
    class SelectionSort<T> where T : IComparable<T>
    {
        public IList<T> sort(IList<T> a)
        { 
            // Sort a[] into increasing order.
            int N = a.Count; // array length
            for (int i = 0; i < N; i++)
            { 
                // Exchange a[i] with smallest entry in a[i+1...N).
                int min = i; // index of minimal entr.
                for (int j = i + 1; j < N; j++)
                    if (less(a[j], a[min])) min = j;
                exch(a, i, min);
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

        private void show<T>(IList<T> a)
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
