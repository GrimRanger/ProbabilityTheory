using Graphs.Interfaces.Graph;
using Graphs.Interfaces.Providers;

namespace Graphs.Graph
{
    public class Graphs : IGraph
    {
        private readonly int _count;
        private readonly int[,] _adjacencyMatrix;
        private readonly IGraphProvider _graphProvider;

        public Graphs(IGraphProvider graphProvider)
        {
            _graphProvider = graphProvider;
            _count = graphProvider.VertexCount;
            _adjacencyMatrix = new int[_count, _count];
            for (int i = 0; i < _count; ++i)
                for (int j = 0; j < _count; ++j)
                    _adjacencyMatrix[i, j] = graphProvider.GetEdge(i, j).Weight;
        }

        public int VertexCount
        {
            get { return _count; }
        }

        public IVertex GetRoot()
        {
            return GetVertex(0);
        }

        public bool EdgeContains(int indexOfVertex1, int indexOfVertex2)
        {
            return _adjacencyMatrix[indexOfVertex1, indexOfVertex2] != 0;
        }

        public IVertex GetVertex(int index)
        {
           return _graphProvider.GetVertex(index);
        }

        public IVertex[] GetVertices()
        {
            return _graphProvider.GetVertexs();
        }

        public IEdge GetEdge(int indexOfVertex1, int indexOfVertex2)
        {
            return _graphProvider.GetEdge(indexOfVertex1, indexOfVertex2);
        }

        public IEdge[] GetEdges()
        {
            return _graphProvider.GetEdges();
        }
    }
}
