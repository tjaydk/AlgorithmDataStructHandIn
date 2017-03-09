using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubling.SortingAlgorithms
{
    public class MergeSort<T> where T : IComparable<T>
    {
        private static IList<T> aux;

        public IList<T> sort(IList<T> a)
        { 
            // Do lg N passes of pairwise merges.
            int N = a.Count;
            aux = a;
            for (int sz = 1; sz < N; sz = sz + sz)
            { 
                // sz: subarray size
                for (int lo = 0; lo < N - sz; lo += sz + sz) // lo: subarray index
                    merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
            }
            return aux;
        }

        private void merge(IList<T> a, int lo, int mid, int hi)
        { 
            // Merge a[lo..mid] with a[mid+1..hi].
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            { 
                // Copy a[lo..hi] to aux[lo..hi].
                aux[k] = a[k];
            }
            for (int k = lo; k <= hi; k++)
            {
                // Merge back to a[lo..hi].
                if (i > mid)                    a[k] = aux[j++];
                else if (j > hi)                a[k] = aux[i++];
                else if (less(aux[j], aux[i]))  a[k] = aux[j++];
                else                            a[k] = aux[i++];
            }
        }

        private bool less(T v, T w)
        {
            return v.CompareTo(w) < 0;
        }
    }
}
