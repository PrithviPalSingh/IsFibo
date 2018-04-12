using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IsFibo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(FindFibonacciNumberUsingRecurrsion(40));
            //Console.WriteLine(DateTime.Now);

            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(FindFibonacciNumberUsingDP(4));
            //Console.WriteLine(DateTime.Now);

            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(FindFibonacciNumberUsingDPSpaceOptimized(4));
            //Console.WriteLine(DateTime.Now);

            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(FindFibonacciNumberUsingBaseMatrix(4));
            //Console.WriteLine(DateTime.Now);

            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(FindFibonacciNumberUsingMemoization(40));
            //Console.WriteLine(DateTime.Now);

            //Console.WriteLine(DateTime.Now);
            //IsFibo(34);
            //Console.WriteLine(DateTime.Now);

            ModifiedFibonacci mf = new ModifiedFibonacci();
            string[] tokens_t1 = Console.ReadLine().Split(' ');
            int t1 = Convert.ToInt32(tokens_t1[0]);
            int t2 = Convert.ToInt32(tokens_t1[1]);
            int n = Convert.ToInt32(tokens_t1[2]);
            BigInteger result = mf.fibonacciModifiedUsingRecurssion(t1, t2, n);
            Console.WriteLine(result);

            Console.Read();
        }

        /// <summary>
        /// Using recursion
        /// Time complexity: T(n) = T(n-1) + T(n-2) which is exponential.
        /// Space complexity: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long FindFibonacciNumberUsingRecurrsion(long n)
        {
            if (n <= 1)
            {
                return n;
            }

            return FindFibonacciNumberUsingRecurrsion(n - 1) + FindFibonacciNumberUsingRecurrsion(n - 2);
        }

        /// <summary>
        /// Using Dynamic Programming
        /// Time Complexity: O(n)
        /// Extra Space: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long FindFibonacciNumberUsingDP(long n)
        {
            /* Declare an array to store Fibonacci numbers. */
            int[] f = new int[n + 1];
            int i;

            /* 0th and 1st number of the series are 0 and 1*/
            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                /* Add the previous 2 numbers in the series
                   and store it */
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }

        /// <summary>
        /// We can optimize the space used in method 2 by storing the previous two numbers 
        /// only because that is all we need to get the next Fibonacci number in series.
        /// Time Complexity: O(n)
        /// Extra Space: O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int FindFibonacciNumberUsingDPSpaceOptimized(int n)
        {
            int a = 0, b = 1, c, i;
            if (n == 0)
                return a;
            for (i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return b;
        }

        /// <summary>
        ///  Using power of the matrix {{1,1},{1,0}}
        ///  This another O(n) which relies on the fact that if we n times multiply 
        ///  the matrix M = {{1,1},{1,0}} to itself (in other words calculate power(M, n )), 
        ///  then we get the (n+1)th Fibonacci number as the element at row and column (0, 0) in the resultant matrix.
        ///  Time Complexity: O(n)
        ///  Extra Space: O(1)
        ///  SECOND CASE:
        ///  Time Complexity: O(Logn)
        ///  Extra Space: O(Logn) if we consider the function call stack size, otherwise O(1).
        /// 
        /// </summary>
        /// <returns></returns>
        static int FindFibonacciNumberUsingBaseMatrix(int n)
        {
            int[,] F = { { 1, 1 }, { 1, 0 } };
            if (n == 0)
                return 0;
            power(F, n - 1);
            return F[0, 0];
        }

        static void multiply(int[,] F, int[,] M)
        {
            int x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            int y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            int z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            int w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }

        static void power(int[,] F, int n)
        {
            int i;
            int[,] M = { { 1, 1 }, { 1, 0 } };

            // n - 1 times multiply the matrix to {{1,0},{0,1}}
            for (i = 2; i <= n; i++)
            {
                multiply(F, M);
            }

            /* - optimized way
                if( n == 0 || n == 1)
                    return;
                int M[2][2] = {{1,1},{1,0}};
 
                power(F, n/2);
                multiply(F, F);
 
                if (n%2 != 0)
                    multiply(F, M);
              */

        }

        static int[] fArray = new int[100];
        // Returns n'th fibonacci number using table f[]
        static int FindFibonacciNumberUsingMemoization(int n)
        {
            // Base cases
            if (n == 0)
                return 0;
            if (n == 1 || n == 2)
                return (fArray[n] = 1);

            // If fib(n) is already computed
            if (fArray[n] != 0)
                return fArray[n];

            int k = ((n & 1) == 1) ? (n + 1) / 2 : n / 2;

            // Applyting above formula [Note value n&1 is 1
            // if n is odd, else 0.
            fArray[n] = ((n & 1) == 1) ? (FindFibonacciNumberUsingMemoization(k) * FindFibonacciNumberUsingMemoization(k) +
                FindFibonacciNumberUsingMemoization(k - 1) * FindFibonacciNumberUsingMemoization(k - 1))
                   : (2 * FindFibonacciNumberUsingMemoization(k - 1) + FindFibonacciNumberUsingMemoization(k)) * FindFibonacciNumberUsingMemoization(k);

            return fArray[n];
        }

        static void IsFibo(long number)
        {            
            if (IsPerfectSquare(5 * (number * number) + 4) || IsPerfectSquare(5 * (number * number) - 4))
            {
                Console.WriteLine("IsFibo");
            }
            else
            {
                Console.WriteLine("IsNotFibo");
            }
        }

        static bool IsPerfectSquare(double sqaure)
        {
            return (Math.Sqrt(sqaure)) % 1 == 0 ? true : false;            
        }
    }
}
