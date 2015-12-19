using TestApp.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Task5PrimeTester().TestPrimeNumber();
            new Task6MatrixEqual().TestMatrix();
        }
    }
}
