using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.Algorithms.Strings
{
    class RabinKarpSubstringSearch
    {
        int radix;
        int Q;

        public RabinKarpSubstringSearch()
        {
            radix = 26;
            Q = 1000000007;
        }

        public int Search(string text, string pattern)
        {
            int patternHash = ComputeHash(pattern);
            int textlen = text.Length;
            int patternlen = pattern.Length;

            if (textlen < patternlen)
            {
                Console.Write("Pattern length less than text length");
                return -1;
            }

            int textHash = ComputeHash(text.Substring(0, patternlen));

            if (textHash == patternHash)
            {
                if(text.Substring(0,patternlen).Equals(pattern))
                    return 0;
            }

            int rm = (int)Math.Pow(radix, patternlen - 1)%Q;

            for (int i=1;i<textlen-patternlen+1;++i)
            {
                int prevChar = (int)(text[i-1] - 'a');
                int lastChar = (int)(text[i + patternlen-1] - 'a');
                textHash = ((((textHash - prevChar * rm + Q ) % Q) * radix)%Q + lastChar)%Q;

                if (textHash == patternHash)
                {
                    if(text.Substring(i, patternlen).Equals(pattern))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
        public int ComputeHash(string pattern)
        {
            int hash = 0;
        
            for (int i=0;i<pattern.Length;++i)
            {
                hash = (hash * radix)%Q + (int)(pattern[i]-'a')%Q;
            }
            return hash;
        }
    }
}
