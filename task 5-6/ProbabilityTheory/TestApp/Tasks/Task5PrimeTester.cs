using System;
using ProbabilityTheory;

namespace TestApp.Tasks
{
    public class Task5PrimeTester
    {
        public void TestPrimeNumber()
        {
            var probabilityPrimeTester = new ProbabilityPrimeTester();

            while (true)
            {
                Console.WriteLine("Please, enter the number!");
                var line = Console.ReadLine();
                int number = 0;
                if (line == "exit")
                    break;
                var parseResult = int.TryParse(line, out number);
                if (!parseResult || number < 2)
                    continue;
                var result = probabilityPrimeTester.IsPrime(number);
                if (result)
                    Console.WriteLine("{0}  is probably prime number", number);
                else
                {
                    Console.WriteLine("{0}  is probably not prime number", number);
                }
                Console.WriteLine();
            }
        }
    }
}
