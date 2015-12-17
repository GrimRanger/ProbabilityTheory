using Graphs.Interfaces.Graph;

namespace Graphs.Interfaces.Providers
{
    public interface IGraphProvider
    {
        int VertexCount { get; }
        IVertex GetVertex(int index);
        IVertex[] GetVertexs();
        IEdge GetEdge(int indexOfVertex1, int indexOfVertex2);
        IEdge[] GetEdges();
    }
}
