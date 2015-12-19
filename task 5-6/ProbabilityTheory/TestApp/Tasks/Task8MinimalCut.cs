using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProbabilityTheory;
using QuickGraph;

namespace TestApp.Tasks
{
    public class Task8MinimalCut
    {
        static AdjacencyGraph<int, Edge<int>> ReadGraph(string filePath)
        {
            var graph = new AdjacencyGraph<int, Edge<int>>();

            foreach (string vertexAndEdges in File.ReadAllLines(filePath))
            {
                List<string> nums = vertexAndEdges.Split(' ').ToList();

                graph.AddVertex(Convert.ToInt32(nums[0]));

                for (int i = 1; i <= nums.Count - 1; i++)
                {
                    if (nums[i] != null && nums[i] != String.Empty)
                    {
                        Edge<int> edge = new Edge<int>(Convert.ToInt32(nums[0]), Convert.ToInt32(nums[i]));
                        graph.AddEdge(edge);
                    }
                }
            }
            return graph;
        }

        public void TestGraph()
        {
            var minimalCutFinder = new MinimalCutFinder();
            while (Console.ReadLine() != null)
            {
                var fileName = "kargerMinCut.txt";
                var graph = ReadGraph(fileName);
                minimalCutFinder.MinimalCutFind(graph);
            }
        }
    }
}
