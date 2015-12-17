namespace Graphs.Interfaces.Graph
{
    public interface IGraph
    {
        int VertexCount { get; }
        IVertex GetRoot();
        IEdge[] GetEdges();
        IVertex[] GetVertices();
        IVertex GetVertex(int i);
        IEdge GetEdge(int indexOfVertex1, int indexOfVertex2);
        bool EdgeContains(int index, int i);
    }
}
