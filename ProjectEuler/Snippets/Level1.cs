using System.Diagnostics;

namespace Snippets;

public static class Level1
{
    /// <summary>
    /// Find the sum of all the multiples of 3 or 5 below maxNumber
    /// </summary>
    /// <param name="maxNumber"></param>
    /// <remarks>O(n)</remarks>
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
    /// <remarks>O(n)</remarks>
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

    /// <summary>
    /// The largest prime factor of the number 600851475143
    /// </summary>
    /// <param name="maxNumber"></param>
    /// <remarks>O(sqrt(n))</remarks>
    public static void Problems3(long input = 600851475143)
    {
        var watch = Stopwatch.StartNew();
        int? maxPrimeFactor = null;
        long maxNumber = input;
        //1. check for factors of 2
        while (maxNumber % 2 == 0)
        {
            maxNumber /= 2;
            maxPrimeFactor = 2;
            //Console.Write(maxPrimeFactor + " ");
        }

        //2. check all odd factor for primality
        for (int i = 3; i <= Math.Sqrt(input) + 1; i += 2)
        {
            while (maxNumber % i == 0)
            {
                maxNumber /= i;
                maxPrimeFactor = i;
                //Console.Write(maxPrimeFactor + " ");
            }
        }
        watch.Stop();
        Console.WriteLine(maxPrimeFactor);
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");

    }

    /// <summary>
    /// The largest palindrome made from the product of two 3-digit numbers
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n*n)</remarks>
    public static void Problems4()
    {
        var watch = Stopwatch.StartNew();
        List<int> palindromes = new List<int>();
        int lastPalindrome = 0;

        bool IsPalindrome(int v)
        {
            if (v.ToString() == string.Join("", v.ToString().ToCharArray().Reverse()))
                return true;

            return false;
        };

        for (int i = 999; i > 100; i--)
        {
            for (int j = 999; j > 100; j--)
            {
                // we ignore check if mult is less than last palindrome found
                // using this logic we cut 527582 mult to 9193 mult
                if ((i * j) < lastPalindrome)
                {
                    break;
                }

                if (IsPalindrome(i * j))
                {
                    palindromes.Add(i * j);
                    lastPalindrome = i * j;
                    break;
                }
            }
        }

        watch.Stop();
        Console.WriteLine(palindromes.Max());
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// The smallest positive number that is evenly divisible by all of the numbers from 1 to 20
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n)</remarks>
    public static void Problems5()
    {
        var watch = Stopwatch.StartNew();
        //int count = 0;
        int smallestNumber = 1;
        for (int j = 2; j < 999999999; j += 2)
        {
            //count++;
            for (int i = 20; i > 1; i -= 1)
            {
                //count++;
                if (j % i != 0)
                    break;
                else if (i == 2)
                {
                    smallestNumber = j;
                    goto foundNUmber;
                }
            }
        }

    foundNUmber:
        watch.Stop();
        //Console.WriteLine(count);
        Console.WriteLine(smallestNumber);
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// The difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n)</remarks>
    public static void Problems6(int input = 100)
    {
        var watch = Stopwatch.StartNew();
        //1. sum of squares ofr natural numbers
        int i = 1;
        long sum = 0;
        long squares = 0;
        while (i <= input)
        {
            sum += i;
            squares += (i * i);
            i++;
        }

        watch.Stop();
        Console.WriteLine((sum * sum) - squares);
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// The 10001 st prime number
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n+sqrt(m))</remarks>
    public static void Problems7(int primeNumberCount = 10001)
    {
        var watch = Stopwatch.StartNew();

        //1. sum of squares ofr natural numbers
        int primeNumber = 3;
        if (primeNumberCount == 1)
            primeNumber = 2;
        else if (primeNumberCount == 2)
            primeNumber = 3;
        else
        {
            long _primeNumberCount = 2;
            while (_primeNumberCount < primeNumberCount)
            {
                primeNumber += 2;
                if (IsPrime(primeNumber))
                {
                    _primeNumberCount++;
                }
            }
        }

        watch.Stop();
        Console.WriteLine($"{primeNumberCount}th prime is {primeNumber}");
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// Basic prime number check
    /// </summary>
    /// <param name="primeNumber"></param>
    /// <returns>bool</returns>
    private static bool IsPrime(long primeNumber)
    {
        // base case
        if (primeNumber == 1)
            return false;

        // base cases
        if (primeNumber == 2 || primeNumber == 3)
            return true;

        // base case
        if (primeNumber % 2 == 0 || primeNumber % 3 == 0)
            return false;

        long number = 3;
        while (number <= Math.Sqrt(primeNumber))
        {
            if (primeNumber % number == 0)
                return false;

            number += 2;
        }

        // didn't found any odd divisor other than itself
        return true;
    }
}