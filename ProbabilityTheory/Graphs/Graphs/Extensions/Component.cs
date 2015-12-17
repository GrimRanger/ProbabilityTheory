using System.Collections.Generic;
using Graphs.Interfaces.Graph;

namespace Graphs.Extensions
{
    public class Component
    {
        public List<IVertex> Vertex { get; private set; }

        public Component()
        {
            this.Vertex = new List<IVertex>();
        }
    }
}