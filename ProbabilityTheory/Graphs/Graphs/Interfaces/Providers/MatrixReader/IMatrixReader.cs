namespace Graphs.Interfaces.Providers.MatrixReader
{
    public interface IMatrixReader
    {
        void ReadNextValue(int[,] matrix, int stringCounter, int wordCouner, string value);
    }
}