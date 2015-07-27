using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Nod.Library
{
    public static class NodCalc
    {
        #region Delegates

        private delegate int Algorithm(int first, int second);

        private static Algorithm euclideanAlgorithm = Euclidean;

        private static Algorithm euclideanBinaryAlgorithm = EuclideanBinary;

        private delegate int ParamsAlhorithm(int[] args, Algorithm algorithm);

        private static ParamsAlhorithm paramsAlhorithm =
            delegate(int[] args, Algorithm algorithm)
            {
                int result = args[0];
                for (int i = 0; i < args.Length - 1; i++)
                {
                    result = algorithm(result, args[i + 1]);
                }
                return result;
            };

        #endregion

        #region Public methods

        public static int Euclidean(int first, int second)
        {
            if (first == 0)
            {
                if (second == 0)
                    return 0;
                else
                    return second;
            }
            else if (second == 0)
                return first;
                
            if (first < second)
                Swap<int>(ref first, ref second);

            int remainder;
            do
            {
                Math.DivRem(first, second, out remainder);
                first = second;
                second = remainder;
            } while (remainder != 0);

            return first;
        }

        public static int Euclidean(out TimeSpan timeElapsed, int first, int second)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = euclideanAlgorithm(first, second);

            stopWatch.Stop();
            timeElapsed = stopWatch.Elapsed;

            return result;
        }

        public static int Euclidean(out TimeSpan timeElapsed, params int[] args)
        {
            if (args == null)
                throw new ArgumentNullException("params int[] args", "Expecting arguments to be int");

            if (args.Length < 2)
                throw new ArgumentException("args", "Operation requires at least two arguments");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = paramsAlhorithm(args, euclideanAlgorithm);

            stopWatch.Stop();
            timeElapsed = stopWatch.Elapsed;

            return result;
        }

        public static int Euclidean(params int[] args)
        {
            if (args == null)
                throw new ArgumentNullException("params int[] args", "Expecting arguments to be int");

            if (args.Length < 2)
                throw new ArgumentException("args", "Operation requires at least two arguments");

            int result = paramsAlhorithm(args, euclideanAlgorithm);

            return result;
        }

        public static int EuclideanBinary(int first, int second)
        {
            if (first == 0)
            {
                if (second == 0)
                    return 0;
                else
                    return second;
            }
            else if (second == 0)
                return first;
            

            int shift;
            for (shift = 0; ((first | second) & 1) == 0; ++shift)
            {
                first >>= 1;
                second >>= 1;
            }
            while ((first & 1) == 0)
                first >>= 1;

            do
            {
                while ((second & 1) == 0)
                    second >>= 1;

                if (first > second)
                    Swap<int>(ref first, ref second);

                second = second - first;
            } while (second != 0);

            return first << shift;
        }

        public static int EuclideanBinary(out TimeSpan timeElapsed, int first, int second)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = euclideanBinaryAlgorithm(first, second);

            stopWatch.Stop();
            timeElapsed = stopWatch.Elapsed;

            return result;
        }

        public static int EuclideanBinary(out TimeSpan timeElapsed, params int[] args)
        {
            if (args == null)
                throw new ArgumentNullException("params int[] args", "Expecting arguments to be int");

            if (args.Length < 2)
                throw new ArgumentException("args", "Operation requires at least two arguments");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = paramsAlhorithm(args, euclideanBinaryAlgorithm);

            stopWatch.Stop();
            timeElapsed = stopWatch.Elapsed;

            return result;
        }

        public static int EuclideanBinary(params int[] args)
        {
            if (args == null)
                throw new ArgumentNullException("params int[] args", "Expecting arguments to be int");

            if (args.Length < 2)
                throw new ArgumentException("args", "Operation requires at least two arguments");

            int result = paramsAlhorithm(args, euclideanBinaryAlgorithm);

            return result;
        }

        #endregion
        
        #region Private methods

        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        #endregion
    }
}
