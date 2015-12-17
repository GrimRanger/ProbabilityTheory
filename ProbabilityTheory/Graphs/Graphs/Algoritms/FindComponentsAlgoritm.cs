using System;
using System.Collections.Generic;
using System.Linq;
using Graphs.Extensions;
using Graphs.Interfaces.Algoritms;
using Graphs.Interfaces.Graph;

namespace Graphs.Algoritms
{
    public class FindComponentsAlgoritm : IAlgoritm
    {
        private const int Empty = -1;

        private  IGraph _graph;
        private bool[] _visitedVertex;
        private int[] _visitedTimeVertex;
        private int[] _parents;
        private int[] _indexOfReturn;
        private  Components _components;

        private void DepthFirstSearch(IVertex root)
        {
            var componentStack = new Stack<IVertex>();
            var vertexStack = new Stack<IVertex>();
          
            int currentTime = 0;
            vertexStack.Push(root);

            _visitedVertex[root.Index] = true;
            _visitedTimeVertex[root.Index] = currentTime++;
            _indexOfReturn[root.Index] = _visitedTimeVertex[root.Index];
            IVertex lastVertex = null;
            while (vertexStack.Count > 0)
            {
             
                IVertex vertex = vertexStack.Peek();
                IVertex child = GetUnvisitedChildNode(vertex);

                if (ComponentExists(vertex, lastVertex))
                    CreateComponent(vertex, componentStack);

                if (child != null)
                {
                    _parents[child.Index] = vertex.Index;
                    _visitedVertex[child.Index] = true;
                    _visitedTimeVertex[child.Index] = currentTime++;
                    vertexStack.Push(child);
                }
                else
                {
                    vertexStack.Pop();
                    componentStack.Push(vertex);
                    _indexOfReturn[vertex.Index] = GetIndexOfReturn(vertex);
                }
                lastVertex = vertex;
            }
       
        }

        private void CreateComponent(IVertex currentVertex, Stack<IVertex> componentStack)
        {
            var component = new Component();
            while (componentStack.Count > 0)
            {
                component.Vertex.Add(componentStack.Pop());
            }

            component.Vertex.Add(currentVertex);
            _components.Add(component);
        }

        private bool ComponentExists(IVertex currentVertex, IVertex lastVertex)
        {
            if (lastVertex == null)
                return false;
            if (_visitedTimeVertex[currentVertex.Index] >= _visitedTimeVertex[lastVertex.Index])
                return false;

            return _visitedTimeVertex[currentVertex.Index] <= _indexOfReturn[lastVertex.Index];
        }

        private IVertex GetUnvisitedChildNode(IVertex vertex)
        {
            int index = vertex.Index;
            int j = 0;

            while (j < _graph.VertexCount)
            {
                if (_graph.EdgeContains(index, j) && (_visitedVertex[j] == false))
                {
                    return _graph.GetVertex(j);
                }
                j++;
            }
            return null;
        }

        private int GetIndexOfReturn(IVertex vertex)
        {
            int index = vertex.Index;
            int j = 0;
            var minNalue = _visitedTimeVertex[index];

            while (j < _graph.VertexCount)
            {
                if (_graph.EdgeContains(index, j))
                {
                    if (_parents[index] != Empty && _visitedTimeVertex[j] != Empty && _parents[index] != j)
                        minNalue = Math.Min(minNalue, _visitedTimeVertex[j]);
                     if (_parents[j] != Empty && _parents[j] == index)
                        minNalue = Math.Min(minNalue, _indexOfReturn[j]);
                }
                j++;
            }
            return minNalue;
        }

        private void ClearArrays()
        {
            _visitedVertex = new bool[_graph.VertexCount];
            _visitedVertex = Enumerable.Repeat(false, _graph.VertexCount).ToArray();

            _visitedTimeVertex = new int[_graph.VertexCount];
            _visitedTimeVertex = Enumerable.Repeat(Empty, _graph.VertexCount).ToArray();
          
            _parents = new int[_graph.VertexCount];
            _parents = Enumerable.Repeat(Empty, _graph.VertexCount).ToArray();

            _indexOfReturn = new int[_graph.VertexCount];
            _indexOfReturn = Enumerable.Repeat(_graph.VertexCount, _graph.VertexCount).ToArray();
        }

        public Components FindComponents(IGraph graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");

            _graph = graph;
            ClearArrays();

            _components = new Components();
            var root = _graph.GetRoot();
            DepthFirstSearch(root);
            for (int i = 0; i < _graph.VertexCount; ++i)
                if (!_visitedVertex[i])
                    DepthFirstSearch(_graph.GetVertex(i));

            return _components;
        }
    }
}
