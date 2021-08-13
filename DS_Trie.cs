using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DS_Trie
    {
        static readonly int ALPHABET_SIZE = 26;
        class TrieNode
        {
            public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
            public bool isEndOfWord;
            public TrieNode()
            {
                isEndOfWord = false;
                for (int i = 0; i < ALPHABET_SIZE; i++)
                    children[i] = null;
            }
        };
        static TrieNode root;
        static void insert(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;
            for(level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();
                pCrawl = pCrawl.children[index];
            }
            pCrawl.isEndOfWord = true;
        }
        static bool search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;
            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null) return false;
                pCrawl = pCrawl.children[index];
            }
            return (pCrawl.isEndOfWord);
        }
    }
}
