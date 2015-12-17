using System;
using Graphs.Interfaces.Graph;

namespace Graphs.Graph
{
    public class Edge : IEdge
    {
        private readonly int _weight;
        private readonly IVertex _vertex1;
        private readonly IVertex _vertex2;

        public Edge(IVertex vertex1, IVertex vertex2, int weight)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _weight = weight;
        }

        public bool IsDirected { get; set; }

        public int Weight
        {
            get { return _weight; }
        }

        public IVertex Source
        {
            get { return _vertex1; }
        }

        public IVertex Target
        {
            get { return _vertex2; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            var edge = obj as Edge;
            if (edge != null)
                return Weight.CompareTo(edge.Weight);

            throw new ArgumentException("Object is not a Edge");
        }
    }
}
