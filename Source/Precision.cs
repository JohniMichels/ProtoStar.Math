// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels
using System.Collections.Generic;

namespace ProtoStar.Math
{
    /// <summary>
    /// This class defines a precision system for numeric derivation, integration and error calculus.
    /// </summary>
    public class Precision : IEqualityComparer<double>
    {
        #region Public Properties

        /// <summary>
        /// Defines a linear acceptable difference between two numbers to consider them equal.
        /// </summary>
        public double AbsoluteDeviation { get; set; } = 0.00000001;

        /// <summary>
        /// This property is used when hashing a double.
        /// <para>
        /// The greater this value is, the more likelly it is to have a collision hash between two
        /// values, but harder to make two equal values on this precision different.
        /// </para>
        /// </summary>
        public double CollisionHash { get; set; } = 128;

        /// <summary>
        /// Defines a geometric acceptable difference between two numbers to consider them equal.
        /// </summary>
        public double RelativeDeviation { get; set; } = 0.000001;

        /// <summary>
        /// Defines which deviation will be considered:
        /// <para>Linear (Absolute) | Geometric (Relative) | Most strict (both) | Least strict (Any)</para>
        /// </summary>
        public DeviationMode UsingDeviation { get; set; } = DeviationMode.Absolute;

        #endregion Public Properties

        #region Public Methods

        public bool AbsoluteEquals(double left, double right)
        {
            return System.Math.Abs(left - right) <= AbsoluteDeviation;
        }

        /// <summary>
        /// Hashes a <c>Double</c> in a linear scale.
        /// </summary>
        /// <param name="obj">A <c>Double</c> to be hashed.</param>
        /// <returns>The hashed value.</returns>
        public int AbsoluteHash(double obj)
        {
            return (int)(obj / (CollisionHash * 2 * AbsoluteDeviation));
        }

        public bool Equals(double x, double y)
        {
            switch (UsingDeviation)
            {
                case DeviationMode.Absolute:
                    return AbsoluteEquals(x, y);

                case DeviationMode.Relative:
                    return RelativeEquals(x, y);

                case DeviationMode.Any:
                    return AbsoluteEquals(x, y) || RelativeEquals(x, y);

                case DeviationMode.Both:
                    return AbsoluteEquals(x, y) && RelativeEquals(x, y);

                default:
                    return x.Equals(y);
            }
        }

        /// <summary>
        /// Overrides the standard hashing of a <c>Double</c> creating collisions between numbers
        /// that are closer than the defined deviation.
        /// </summary>
        /// <param name="obj">A <c>Double</c> to be hashed.</param>
        /// <returns></returns>
        public int GetHashCode(double obj)
        {
            switch (UsingDeviation)
            {
                case DeviationMode.Absolute:
                    return AbsoluteHash(obj);

                case DeviationMode.Relative:
                    return RelativeHash(obj);

                case DeviationMode.Any:
                    return System.Math.Min(AbsoluteHash(obj), RelativeHash(obj));

                case DeviationMode.Both:
                    return System.Math.Max(AbsoluteHash(obj), RelativeHash(obj));

                default:
                    return obj.GetHashCode();
            }
        }

        public bool RelativeEquals(double left, double right)
        {
            if (right == 0) { return left == 0 ? true : false; }

            return System.Math.Abs(left / right - 1) <= RelativeDeviation;
        }

        /// <summary>
        /// Hashes a <c>Double</c> in a geometric scale.
        /// </summary>
        /// <param name="obj">A <c>Double</c> to be hashed.</param>
        /// <returns>The hashed value.</returns>
        public int RelativeHash(double obj)
        {
            return (int)System.Math.Log(System.Math.Abs(obj), (1 + RelativeDeviation * 2 * CollisionHash));
        }

        #endregion Public Methods
    }
}