using System;
using System.Collections.Generic;
using Graphs.Interfaces.Algoritms;
using Graphs.Interfaces.Graph;

namespace Graphs.Algoritms
{
    public class DFSAlgoritm : IAlgoritm
    {
        private readonly IGraph _graph;
        private bool[] _visitedvertex;

        public DFSAlgoritm(IGraph graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
            _visitedvertex = new bool[_graph.VertexCount];

        }

        private IVertex GetUnvisitedChildNode(IVertex vertex)
        {

            int index = vertex.Index;
            int j = 0;

            while (j < _graph.VertexCount)
            {
                if (_graph.EdgeContains(index, j) && (_visitedvertex[j] == false))
                {
                    return _graph.GetVertex(j);
                }
                j++;
            }
            return null;
        }

        public void DepthFirstSearch()
        {
            var vertexStack = new Stack<IVertex>();
            var root = _graph.GetRoot();
            vertexStack.Push(root);

            _visitedvertex[root.Index] = true;
          
            //printNode(rootNode);
            while (vertexStack.Count > 0)
            {
                IVertex vertex = vertexStack.Peek();
                IVertex child = GetUnvisitedChildNode(vertex);
            
                if (child != null)
                {
                    _visitedvertex[child.Index] = true;
                   // printNode(child);
                    vertexStack.Push(child);
                }
                else
                {
                    vertexStack.Pop();
                }
            }
            ClearVisitedArray();
        }

        private void ClearVisitedArray()
        {
            _visitedvertex = new bool[_graph.VertexCount];
        }
    }
}