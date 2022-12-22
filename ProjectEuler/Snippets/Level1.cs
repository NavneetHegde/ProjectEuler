using System;
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
    /// Find the M adjacent digits in the 1000-digit number that have the greatest product. 
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n)</remarks>
    public static void Problems8(int totalAdjacentDigits = 13)
    {
        var watch = Stopwatch.StartNew();

        string digits = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        long maxDigit = 0;

        for (int i = 0; i < digits.Count() - totalAdjacentDigits; i++)
        {
            long _maxDigit = 1;
            for (int k = i; k < (i + totalAdjacentDigits); k++)
            {
                _maxDigit *= (int)Char.GetNumericValue(digits[k]);
            }
            if (_maxDigit > maxDigit)
                maxDigit = _maxDigit;
        }

        watch.Stop();
        Console.WriteLine($"Max {totalAdjacentDigits} digit product is {maxDigit}");
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// TODO : Need better approach
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n*n*n)</remarks>
    public static void Problems9()
    {
        var watch = Stopwatch.StartNew();
        int x = 5;
        int y = 4;
        int z = 3;
        for (int c = 100000; c > 5; c--)
        {
            for (int b = c - 1; b > 0; b--)
            {
                if (b + c > 1000)
                    continue;
                for (int a = b - 1; a > 0; a--)
                {
                    if (a + b + c != 1000)
                        continue;
                    int value = (a * a) + (b * b);
                    if (c * c == value)
                    {
                        x = c; y = b; z = a;
                        break;
                    }
                }
            }
        }

        watch.Stop();
        Console.WriteLine($"Triplets are {x} {y} {z} \n Sum is {x + y + z} \n and product is {x * y * z}");
        Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
    }

    /// <summary>
    /// Find the sum of all the primes below n.
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>O(n*n*n)</remarks>
    public static void Problems10(int number = 2000000)
    {
        var watch = Stopwatch.StartNew();

        //1. find all primes until the number
        long primeSum = 2 + 3 + 5;
        for (int i = 7; i < number; i += 2)
        {
            if (IsPrime(i))
                primeSum += i;
        }

        watch.Stop();
        Console.WriteLine($"Prime sum under {number} = {primeSum}");
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