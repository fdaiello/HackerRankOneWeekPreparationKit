using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankOneWeekPreparationKit
{
    public class TrieNode
    {
        public TrieNode()
        {
            Children = new TrieNode['j'-'a'+1];
            End = false;
            HasChild = false;
        }
        public TrieNode[] Children { get; set; }
        public bool End { get; set; }
        public bool HasChild { get; set; }
    }
}
