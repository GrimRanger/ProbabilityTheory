using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.Interfaces.Algoritms;
using Graphs.Interfaces.Graph;

namespace Graphs.Algoritms
{
    public class MinimalCut : IAlgoritm
    {
        private readonly IGraph _graph;
        private readonly Random _random;

        public MinimalCut(IGraph graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
            _random = new Random();

        }

        public void MinimalCutFind()
        {
            List<IVertex> vertices = _graph.GetVertices().ToList();
            List<IEdge> edges = _graph.GetEdges().ToList();
            //повторять, пока в G более двух вершин:
            while (_graph.VertexCount > 2)
            {
                //выбрать случайное ребро (u, v)
                int edgesCount = edges.Count;
                var edgeIndex = _random.Next(0, edgesCount);
                IEdge edge = edges[edgeIndex];
                edges.RemoveAt(edgeIndex);
                Console.WriteLine("Merging " + edge.Source.Index + " " + edge.Target.Index);
                //Merge
                //    foreach (var edge in Vertices[secondVertex])
                //    {
                //        if (!Vertices[firstVertex].Contains(edge))
                //            Vertices[firstVertex].Add(edge);
                //    }

                //    //change all the occurences of the secondVertex to the first
                //    foreach (var vertex in Vertices)
                //    {
                //        if (vertex.Value.Contains(secondVertex))
                //        {
                //            vertex.Value.Remove(secondVertex);
                //            vertex.Value.Add(firstVertex);
                //        }
                //    }
                //    //Remove Self Loops
                //    Vertices[firstVertex].RemoveAll(_ => _ == firstVertex);
                //    Vertices.Remove(secondVertex);
                //}

                //удалить все ребра между u и v


            }
        }


    }
}