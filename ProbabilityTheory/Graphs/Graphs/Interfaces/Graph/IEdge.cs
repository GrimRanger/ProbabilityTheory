using System;

namespace Graphs.Interfaces.Graph
{
    public interface IEdge : IComparable
    {
        IVertex Source { get; }
        IVertex Target { get; }
        bool IsDirected { get; set; }
        int Weight { get; }
    }
}
