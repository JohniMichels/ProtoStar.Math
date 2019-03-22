// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Collections.Generic;
using System.Linq;

namespace ProtoStar.Math
{
    public static class Primes
    {
        #region Private Properties

        private static List<int> PrimesList { get; set; } = new List<int>{
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        #endregion Private Properties

        #region Public Properties

        public static IEnumerable<int> EnumeratePrimes
        {
            get
            {
                foreach (int e in PrimesList) { yield return e; }
                while (true)
                {
                    ExpandPrimeList();
                    yield return PrimesList.Last();
                }
            }
        }

        #endregion Public Properties

        #region Private Methods

        private static void ExpandPrimeList()
        {
            PrimesList.Add(NextPrime());
        }

        private static int NextPrime()
        {
            int lastPrime = PrimesList.Last() + 2;

            while (!IsPrime(lastPrime))
            {
                lastPrime += 2;
            }
            return lastPrime;
        }

        #endregion Private Methods

        #region Public Methods

        public static bool IsPrime(int value)
        {
            if (value <= PrimesList.Last()) { return PrimesList.Contains(value); }
            if (value <= (PrimesList.Last() ^ 2)) { return PrimesList.TakeWhile((x) => x <= System.Math.Sqrt(value)).Any((x) => value % x == 0); }
            while (PrimesList.Last() < value)
            {
                ExpandPrimeList();
            }
            return PrimesList.Contains(value);
        }

        #endregion Public Methods
    }
}