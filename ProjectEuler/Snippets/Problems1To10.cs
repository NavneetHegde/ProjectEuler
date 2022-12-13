using System.Diagnostics;
using System.Reflection.Emit;

namespace Snippets
{
    public static class Problems1To10
    {
        /// <summary>
        /// Find the sum of all the multiples of 3 or 5 below maxNumber
        /// </summary>
        public static void Problems1(int maxNumber = 1000)
        {
            long multipleCount = 0;
            var watch = Stopwatch.StartNew();
            for (int n = 0; n < maxNumber; n++)
            {
                //1. multiple of 3 and 5 
                if (n % 3 == 0 || n % 5 == 0)
                    multipleCount += n; //2. Sum of all multiples
            }
            watch.Stop();
            Console.WriteLine(multipleCount);
            Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");

        }

        /// <summary>
        /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
        /// find the sum of the even-valued terms.
        /// </summary>
        /// <param name="maxNumber"></param>
        public static void Problems2(int maxNumber = 4000000)
        {
            //1. start finding the fibonacci
            var watch = Stopwatch.StartNew();
            int fibPrev = 0;
            int fibPrevPrev = 1;
            int fib = 0;
            long fibEvenSum = 0;
            while (fib <= maxNumber)
            {
                fib = fibPrevPrev + fibPrev;
                //2. if it's even sum it
                if (fib % 2 == 0)
                    fibEvenSum += fib;
                fibPrev = fibPrevPrev;
                fibPrevPrev = fib;
            }
            watch.Stop();
            Console.WriteLine(fibEvenSum);
            Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");

        }
    }
}