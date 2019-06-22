using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.Algorithms.Strings
{
    class BruteForceSubstringSearch
    {
        public BruteForceSubstringSearch()
        {

        }

        public int Search(string text, string pattern)
        {
            int plen = pattern.Length;

            if (plen == 0)
            {
                Console.Write("Empty pattern");
                return -1;
            }
            for (int i = 0; i < text.Length - plen + 1; ++i)
            {
                int j = 0;
                while(j < plen)
                {
                    if (text[i + j] != pattern[j])
                    {
                        break;
                    }
                    ++j;
                }
                if (j==plen)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}