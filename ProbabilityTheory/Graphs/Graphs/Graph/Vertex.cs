using System;
using Graphs.Interfaces.Graph;

namespace Graphs.Graph
{
    public class Vertex : IVertex
    {
        private readonly int _index;

        public int Index
        {
            get { return _index; }
        }

        public Vertex(int index)
        {
            _index = index;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            var vertex = obj as Vertex;
            if (vertex != null)
                return Index.CompareTo(vertex.Index);

            throw new ArgumentException("Object is not a Vertex");
        }
    }
}


