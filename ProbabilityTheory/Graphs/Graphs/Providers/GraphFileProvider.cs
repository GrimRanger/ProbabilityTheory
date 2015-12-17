using System;
using System.Collections.Generic;
using System.IO;
using Graphs.Graph;
using Graphs.Interfaces.Graph;
using Graphs.Interfaces.Providers;
using Graphs.Interfaces.Providers.MatrixReader;

namespace Graphs.Providers
{
    public class GraphFileProvider : IGraphProvider
    {
        private int _size;
        private int[,] _adjacencyMatrix;

        public void ReadFile(string fileName, IMatrixReader reader)
        {
            char[] delimiterChars = {' ', '\\', '\t'};
            try
            {
                var streamReader = new StreamReader(fileName);
                var sizeString = streamReader.ReadLine();
                if (sizeString != null)
                    _size = int.Parse(sizeString);

                _adjacencyMatrix = new int[_size, _size];
                string line;
                var i = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] coef = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < coef.Length; ++j)
                    {
                        reader.ReadNextValue(_adjacencyMatrix, i, j, coef[j]);
                    }
                    i++;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEdge GetEdge(int indexOfVertex1, int indexOfVertex2)
        {
            var vertex1 = new Vertex(indexOfVertex1);
            var vertex2 = new Vertex(indexOfVertex2);
            var edge = new Edge(vertex1, vertex2, _adjacencyMatrix[indexOfVertex1, indexOfVertex2]);

            return edge;
        }

        public IEdge[] GetEdges()
        {
            var edges = new List<Edge>();
            for (var i = 0; i < _size; ++i)
            {
                for (var j = 0; j < _size; ++j)
                {
                    if (_adjacencyMatrix[i, j] > 0)
                    {
                        var vertex1 = new Vertex(i);
                        var vertex2 = new Vertex(j);
                        var edge = new Edge(vertex1, vertex2, _adjacencyMatrix[i, j]);
                        edges.Add(edge);
                    }
                }
            }
            return edges.ToArray();
        }

        public int VertexCount
        {
            get { return _size; }
        }

        public IVertex[] GetVertexs()
        {
            IVertex[] result = new IVertex[_size];
            for (int i = 0; i < _size; ++i)
            {
                result[i] = GetVertex(i);
            }

            return result;
        }

        public IVertex GetVertex(int index)
        {
            Vertex result = new Vertex(index);

            return result;
        }
    }
}