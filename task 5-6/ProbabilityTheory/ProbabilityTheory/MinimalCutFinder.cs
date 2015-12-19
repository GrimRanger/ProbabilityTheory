using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuickGraph;

namespace ProbabilityTheory
{
    public class MinimalCutFinder
    {
        private readonly Random _random;

        public MinimalCutFinder()
        {
         
            _random = new Random();
        }

        public void MinimalCutFind(AdjacencyGraph<int, Edge<int>> graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");

            List<int> results = new List<int>();

            for (int i = 1; i <= (graph.VertexCount * graph.VertexCount); i++)
            {
                while (graph.VertexCount > 2)
                {
                    // get the vertext to delete
                    int x = _random.Next(0, graph.VertexCount);
                    int vertexToDelete = graph.Vertices.ElementAt(x);

                    // get the target vertex to merge to
                    IEnumerable<Edge<int>> e = new List<Edge<int>>();
                    graph.TryGetOutEdges(vertexToDelete, out e);

                    int r = _random.Next(0, e.Count());
                    int vertexToMergeTo = e.ElementAt(r).Target;

                    // list of edges which need to be merged based on the vertex to delete
                    IEnumerable<Edge<int>> edgesToMerge = new List<Edge<int>>();
                    graph.TryGetOutEdges(vertexToDelete, out edgesToMerge);

                    // temp lists to store the edges to add and remove.
                    List<Edge<int>> edgesToRemove = new List<Edge<int>>();
                    List<Edge<int>> edgesToAdd = new List<Edge<int>>();

                    // for each edge, create a new edge linked to the target vertex.  If the target is the same remove.
                    foreach (Edge<int> edge in edgesToMerge)
                    {
                        if (vertexToMergeTo == edge.Target)
                        {
                            edgesToRemove.Add(edge);
                        }
                        else
                        {
                            Edge<int> newEdge = new Edge<int>(vertexToMergeTo, edge.Target);
                            edgesToAdd.Add(newEdge);
                            Edge<int> newEdgeB = new Edge<int>(edge.Target, vertexToMergeTo);
                            edgesToAdd.Add(newEdgeB);

                            edgesToRemove.Add(edge);
                            Edge<int> newEdgeD = null;
                            graph.TryGetEdge(edge.Target, edge.Source, out newEdgeD);
                            edgesToRemove.Add(newEdgeD);
                        }
                    }

                    // remove old vertexes
                    foreach (Edge<int> edge in edgesToRemove)
                    {
                        graph.RemoveEdge(edge);
                    }

                    // remove old vertexes
                    foreach (Edge<int> edge in edgesToAdd)
                    {
                        graph.AddEdge(edge);
                    }

                    graph.RemoveVertex(vertexToDelete);
                }
            }
            IEnumerable<Edge<int>> edges1 = new List<Edge<int>>();
            IEnumerable<Edge<int>> edges2 = new List<Edge<int>>();
            graph.TryGetOutEdges(graph.Vertices.ElementAt(0), out edges1);
            graph.TryGetOutEdges(graph.Vertices.ElementAt(1), out edges2);
            results.Add(edges1.Count());
            Console.Write(results.Min());

            Console.ReadLine();
        }

     
    }
}