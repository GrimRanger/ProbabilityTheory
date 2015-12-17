using System;

namespace Graphs.Interfaces.Graph
{
    public interface IVertex : IComparable
    {
        int Index { get; }
        string Name { get; set; }
    }
}
