using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankOneWeekPreparationKit
{
    public class GraphNode
    {
        public GraphNode(int value)
        {
            Value = value;
            edges = new List<GraphNode>();
        }
        public int Value { get; set; }

        public List<GraphNode> edges;

        public void AddEdge(GraphNode node)
        {
            if (!edges.Contains(node))
            {
                edges.Add(node);
            }
        }
    }
}
