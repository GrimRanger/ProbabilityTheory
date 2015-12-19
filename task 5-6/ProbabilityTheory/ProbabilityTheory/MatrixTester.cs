using System;
using MathNet.Numerics.LinearAlgebra;

namespace ProbabilityTheory
{
    public class MatrixTester
    {
        private readonly Random _random;

        public MatrixTester()
        {
            _random = new Random();
        }

        public bool IsEqual(double[,] arrayA, double[,] arrayB, double[,] arrayC, int n)
        {
            var A = Matrix<double>.Build.DenseOfArray(arrayA);
            var B = Matrix<double>.Build.DenseOfArray(arrayB);
            var C = Matrix<double>.Build.DenseOfArray(arrayC);

            var vector = new double[n];
            for (int i = 0; i < vector.Length; ++i)
            {
                vector[i] = _random.Next(0, 2);
            }
            Vector<double> x = Vector<double>.Build.DenseOfArray(vector);

            var y = B*x;
            var z = A*y;
            var t = C*x;

            if (Equals(t, z))
                return true;

            return false;
        }
    }
}
