using Graphs.Interfaces.Providers.MatrixReader;

namespace Graphs.Providers.MatrixReader
{
    public class AdjacencyMatrixReader : IMatrixReader
    {
        public void ReadNextValue(int[,] matrix, int stringCounter, int wordCouner, string value)
        {
            int val = int.Parse(value);
            matrix[stringCounter, wordCouner] = val;
        }
    }
}
