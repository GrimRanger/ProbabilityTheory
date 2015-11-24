using System;

namespace ProbabilityTheory
{
    public class ProbabilityPrimeTester
    {
        public struct Params
        {
            public int S { get; set; }
            public int T { get; set; }
        }
        private readonly Random _random;

        public ProbabilityPrimeTester()
        {
            _random = new Random();
        }

        private Params GetParams(int number)
        {
            number = number - 1;
            int power = 0;
            while (number % 2 == 0)
            {
                number = number / 2;
                power++;
            }
            return new Params { S = power, T = number };
        }

        public bool IsPrime(int number)
        {
            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            var a = _random.Next(2, number);
            if (number % a == 0)
                return false;
            var numberParams = GetParams(number);
            if ((long)Math.Pow(a, numberParams.T) % number == 1)
                return true;

            for (var k = 0; k < numberParams.S; ++k)
            {
                var power = (long)Math.Pow(2, k) * numberParams.T;
                if ((long)Math.Pow(a, power) % number == number  - 1)
                    return true;
            }

            return false;
        }
    }
}
