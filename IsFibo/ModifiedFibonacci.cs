using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IsFibo
{
    /// <summary>
    /// t(i+2) = t(i) + t(i+1)^2
    /// </summary>
    class ModifiedFibonacci
    {
        public BigInteger fibonacciModified(BigInteger t1, BigInteger t2, int n)
        {
            for (int i = 0; i < n - 2; i++)
            {
                BigInteger t2Temp = t2;
                t2 = t1 + (t2 * t2);
                t1 = t2Temp;
            }

            return t2;
        }

        public BigInteger fibonacciModifiedUsingRecurssion(BigInteger t1, BigInteger t2, int n)
        {
            return fibonacciModifiedUsingRecurssionInner(t1, t2, n - 1);
        }

        private BigInteger fibonacciModifiedUsingRecurssionInner(BigInteger t1, BigInteger t2, int n)
        {
            if (n == 0)
            {
                return t1;
            }
            else if (n == 1)
            {
                return t2;
            }
            else
            {
                return (fibonacciModifiedUsingRecurssionInner(t1, t2, n - 1) * fibonacciModifiedUsingRecurssionInner(t1, t2, n - 1))
                    + fibonacciModifiedUsingRecurssionInner(t1, t2, n - 2);
            }


        }
    }
}
