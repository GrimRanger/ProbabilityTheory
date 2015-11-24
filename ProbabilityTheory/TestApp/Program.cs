using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProbabilityTheory;

namespace TestApp
{
    class Program
    {
        static double[,] ReadMatrix(StreamReader streamReader, int size)
        {
            char[] delimiterChars = { ' ', '\\', '\t' };

            double[,] matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                var line = streamReader.ReadLine();
                if (line == "")
                    return null;

                var numbers = line.Split(delimiterChars);

                for (int j = 0; j < numbers.Length; ++j)
                {
                    double temp = float.Parse(numbers[j]);
                    matrix[i, j] = temp;
                }
            }

            return matrix;
        }

        static StreamReader StartRead(string fileName)
        {
            return new StreamReader(fileName);
        }

        static void TestMatrix()
        {
            var matrixTester = new MatrixTester();
            while (Console.ReadLine() != null)
            {
                var fileName = "test2.txt";
                var streamReader = StartRead(fileName);
                var size = int.Parse(streamReader.ReadLine());
                streamReader.ReadLine();
                var A = ReadMatrix(streamReader, size);
                streamReader.ReadLine();
                var B = ReadMatrix(streamReader, size);
                streamReader.ReadLine();
                var C = ReadMatrix(streamReader, size);
                if (matrixTester.IsEqual(A, B, C, size))
                    Console.WriteLine("Matrix 3 is probably a product of matrices 1 and 2");
                else
                {
                    Console.WriteLine("Matrix 3 is probably not a product of matrices 1 and 2");
                }
            }
        }

        static void TestPrimeNumber()
        {
            var probabilityPrimeTester = new ProbabilityPrimeTester();

            var line = Console.ReadLine();
            while (line != null)
            {
                int number = 0;
                var parseResult = int.TryParse(line, out number);
                if (!parseResult)
                    continue;
                var result = probabilityPrimeTester.IsPrime(number);
                if (result)
                    Console.WriteLine("{0}  is probably prime number", number);
                else
                {
                    Console.WriteLine("{0}  is probably not prime number", number);
                }
                line = Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            // TestPrimeNumber();
            TestMatrix();
        }
    }
}
