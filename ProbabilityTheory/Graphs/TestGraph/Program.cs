using System;
using Graphs.Algoritms;
using Graphs.Extensions;
using Graphs.Providers;
using Graphs.Providers.MatrixReader;

namespace TestGraph
{
    class Program
    {
        private static void Test(string fileName)
        {
            var provider = new GraphFileProvider();
            provider.ReadFile(fileName, new AdjacencyMatrixReader());
            var graph = new Graphs.Graph.Graphs(provider);

            var blockAlgoritm = new FindComponentsAlgoritm();
            var componets = blockAlgoritm.FindComponents(graph);
            PrintComponents(componets);
        }

        private static void PrintComponents(Components componets)
        {
            for (var i = 0; i < componets.Count; ++i)
            {
                Console.WriteLine();
                for (var j = 0; j < componets[i].Vertex.Count; ++j)
                    Console.Write(componets[i].Vertex[j].Index + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            const string fileName = "test.txt";
            Test(fileName);
        }
    }
}
