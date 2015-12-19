using System;
using System.IO;
using ProbabilityTheory;

namespace TestApp.Tasks
{
    public class Task6MatrixEqual
    {
        private StreamReader StartRead(string fileName)
        {
            return new StreamReader(fileName);
        }

        private double[,] ReadMatrix(StreamReader streamReader, int size)
        {
            char[] delimiterChars = { ' ', '\\', '\t' };

            double[,] matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                var line = streamReader.ReadLine();
                if (line == "")
                    return null;

                if (line != null)
                {
                    var numbers = line.Split(delimiterChars);

                    for (int j = 0; j < numbers.Length; ++j)
                    {
                        double temp = float.Parse(numbers[j]);
                        matrix[i, j] = temp;
                    }
                }
            }

            return matrix;
        }

        public void TestMatrix()
        {
            Console.WriteLine("Please, enter any key to start!");
            var matrixTester = new MatrixTester();
            while (true)
            {
                var fileName = "test2.txt";
                var streamReader = StartRead(fileName);
                if (streamReader != null)
                {
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
                    Console.WriteLine();
                    Console.WriteLine("Repeat?");
                    var line = Console.ReadLine();
                    if (line == "no")
                        break;
                }
            }
        }
    }
}
