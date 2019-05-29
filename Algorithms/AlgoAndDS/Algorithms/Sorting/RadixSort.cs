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
        public void LSD(string[] strings)
        {
            int w = strings[0].Length;
            List<int> a = new List<int>();
            string[] aux = new string[strings.Length];

            for (int i=w-1;i>=0;--i)
            {
                KeyIndexedSort(strings,aux, i);
            }
        }

        public void KeyIndexedSort(string[] arr, string[] aux,int d,int R=256)
        {
            int len = arr.Length;
            char[] count = new char[R+1];            
            
            for (int i = 0; i < len; ++i)
            {
                count[arr[i][d] + 1]++;
            }

            for (int i = 1; i <= R; ++i)
            {
                count[i] += count[i-1];
            }

            for (int i = 0; i < len; ++i)
            {
                aux[count[arr[i][d]]++] = arr[i];
            }

            for (int i = 0; i < len; ++i)
            {
                arr[i] = aux[i];
            }
        }
    }
}
