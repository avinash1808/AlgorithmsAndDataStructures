using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class UnionFind
    {
        private readonly int[] id;
        private readonly int[] weight;

        public UnionFind(int n)
        {
            id = new int[n];
            weight = new int[n];

            for (int i = 0; i < n; ++i)
            {
                id[i] = i;
                weight[i] = 1;
            }
        }

        private int Root(int i)
        {
            while (id[i] != i)
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }

        public bool Connected(int i, int j)
        {
            int iid = Root(i);
            int jid = Root(j);

            return iid == jid;
        }

        public void Union(int i, int j)
        {
            int iid = Root(i);
            int jid = Root(j);

            if (iid != jid)
            {
                if (weight[iid] < weight[jid])
                {
                    id[iid] = jid;
                    weight[jid] = weight[iid] + weight[jid];
                }
                else
                {
                    id[jid] = iid;
                    weight[iid] = weight[iid] + weight[jid];
                }            
            }
        }
    }
}
