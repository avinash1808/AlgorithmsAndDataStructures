using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class Trie
    {
        class Node
        {
            public bool end;
            public Node[] next;

            public Node()
            {
                this.end = false;
                this.next = new Node[26];
            }
        }

        private Node root;
        List<string> prefixStrings;

        public Trie()
        {
            root = new Node();
            prefixStrings = new List<string>();
        }

        public void Insert(string str)
        {
            this.Insert(root, str, 0);
        }

        private Node Insert(Node node, string str, int d)
        {
            if (node == null) node = new Node();
            if (d == str.Length)
            {
                node.end = true;
                return node;
            }

            int index = str[d] - 'a';
            node.next[index] = Insert(node.next[index], str, d + 1);
            return node;
        }

        public bool Search(string str)
        {
            return this.Search(root, str, 0);
        }

        private bool Search(Node node, string str, int d)
        {
            if (node == null) return false;
            if (d == str.Length)
            {
                return node.end;
            }

            int index = str[d] - 'a';
            return Search(node.next[index], str, d + 1);
        }

        public List<string> StringsWithPrefix(string pre)
        {
            StringsWithPrefix(root, pre, 0, "");
            return prefixStrings;
        }

        public List<string> SearchWild(string str)
        {
            SearchWild(root, str, 0, "");
            return prefixStrings;
        }

        private void SearchWild(Node node, string pre, int d, string curr)
        {
            if (d == pre.Length)
            {
                if (node.end)
                    prefixStrings.Add(curr);

                return;
            }

            if (pre[d] == '.')
            {
                for (int i = 0; i < 26; ++i)
                {
                    if (node.next[i] == null) continue;

                    char currchar = (char)('a' + i);
                    string newcurr = curr + currchar;

                    SearchWild(node.next[i], pre, d + 1, newcurr);
                }
            }

            else if (pre[d] == '*')
            {
                if (d == pre.Length - 1)
                {
                    SearchAllPossible(node, curr);
                }

                else
                {
                    SearchWild(node, pre, d + 1, curr);

                    for (int i = 0; i < 26; ++i)
                    {
                        if (node.next[i] == null) continue;

                        char currchar = (char)('a' + i);
                        string newcurr = curr + currchar;

                        SearchWild(node.next[i], pre, d, newcurr);
                    }
                }
            }
            else
            {
                int index = pre[d] - 'a';
                if (node.next[index] == null)
                {
                    return;
                }

                curr = curr + pre[d];
                SearchWild(node.next[index], pre, d + 1, curr);
            }
        }

        private void StringsWithPrefix(Node node, string pre, int d, string curr)
        {
            if (node.end)
            {
                prefixStrings.Add(curr);
            }
            if (d == pre.Length)
            {
                SearchAllPossible(node, curr);
                return;
            }

            int index = pre[d] - 'a';
            if (node.next[index] == null)
            {
                return;
            }

            curr = curr + pre[d];
            StringsWithPrefix(node.next[index], pre, d + 1, curr);
        }

        private void SearchAllPossible(Node node, string curr)
        {
            if (node.end)
            {
                prefixStrings.Add(curr);
            }
            for (int i = 0; i < 26; ++i)
            {
                if (node.next[i] == null) continue;

                char currchar = (char)('a' + i);
                string newcurr = curr + currchar;

                SearchAllPossible(node.next[i], newcurr);
            }
        }
    }
}
