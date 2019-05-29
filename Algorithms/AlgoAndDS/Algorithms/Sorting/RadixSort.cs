using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.Algorithms.Sorting
{
    class RadixSort
    {
        public int charAt(string str, int d)
        {
            if (d < str.Length) return str[d];
            return 0;
        }

        public void MSD(string[] strings)
        {
            MSD(strings, 0, 0, strings.Length-1);
        }

        public void MSD(string[] strings, int d, int lo, int hi, int R = 256)
        {
            if (lo >= hi) return;

            string[] aux = new string[strings.Length];
            int[] count = new int[R + 1];
            KeyIndexedSort(strings, aux, d, count, lo, hi,R);

            for (int i = 0; i < R; ++i)
            {
                MSD(strings,d+1,count[i],count[i+1]-1);
            }

        }

        public void LSD(string[] strings, int R = 256)
        {
            int w = strings[0].Length;
            List<int> a = new List<int>();
            string[] aux = new string[strings.Length];
            
            for (int i=w-1;i>=0;--i)
            {
                int[] count = new int[R + 1];
                KeyIndexedSort(strings,aux, i,count,0,w-1,R);
            }
        }

        public void KeyIndexedSort(string[] strs, string[] aux,int d,int[] count,int lo, int hi,int R = 256)
        {        
            for (int i = lo; i <= hi; ++i)
            {
                count[charAt(strs[i],d) + 1]++;
            }

            for (int i = 1; i <= R; ++i)
            {
                count[i] += count[i-1];
            }

            for (int i = lo; i <= hi; ++i)
            {
                aux[lo+count[charAt(strs[i], d)]++] = strs[i];
            }

            for (int i = lo; i <= hi; ++i)
            {
                strs[i] = aux[i];
            }
        }
    }
}
