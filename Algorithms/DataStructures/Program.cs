using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            int n = Convert.ToInt32(input1);
            UnionFind uf = new UnionFind(n);

            string input5 = Console.ReadLine();
            int l = Convert.ToInt32(input5);

            for (int i = 0; i < l; ++i)
            {
                string input2 = Console.ReadLine();
                var splitinput2 = input2.Split(' ');
                int p = Convert.ToInt32(splitinput2[0]);
                int q = Convert.ToInt32(splitinput2[1]);
                uf.Union(p,q);
           
            }

            string input3 = Console.ReadLine();
            int m = Convert.ToInt32(input3);

            for (int i = 0; i < m; ++i)
            {
                string input4 = Console.ReadLine();
                var splitinput4 = input4.Split(' ');
                int p = Convert.ToInt32(splitinput4[0]);
                int q = Convert.ToInt32(splitinput4[1]);
                Console.WriteLine(uf.Connected(p, q));
            }
            Console.ReadKey();
        }
    }
}
