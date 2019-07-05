using System;
// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Collections.Generic;

namespace ProtoStar.Math
{
    [Flags]
    public enum RelativePosition
    {
        Inside = 0,
        Outside = 1,
        Above = 3,
        Bellow = 5
    }

    public static class RangeExtensions
    {
        #region Public Methods

        public static bool IsAbove<T>(this IRange<T> range, T value, IComparer<T> comparer)=>
            comparer.Compare(range.Maximum, value) < 0;

        public static bool IsAbove<T>(this IRange<T> range, T value)=>
            range.IsAbove(value, Comparer<T>.Default);

        public static bool IsBellow<T>(this IRange<T> range, T value, IComparer<T> comparer)=>
            comparer.Compare(value, range.Minimum) < 0;

        public static bool IsBellow<T>(this IRange<T> range, T value)=>
            range.IsBellow(value, Comparer<T>.Default);
        

        public static bool IsInside<T>(this IRange<T> range, T value, IComparer<T> comparer)=>
            !(range.IsAbove(value, comparer) || range.IsBellow(value, comparer));

        public static bool IsInside<T>(this IRange<T> range, T value)=>
            range.IsInside(value, Comparer<T>.Default);
    
        public static RelativePosition RelativePosition<T>(this IRange<T> range, T value, IComparer<T> comparer)
        {
            if (range.IsBellow(value, comparer)) { return ProtoStar.Math.RelativePosition.Bellow; }
            if (range.IsAbove(value, comparer)) { return ProtoStar.Math.RelativePosition.Above; }
            return ProtoStar.Math.RelativePosition.Inside;
        }

        public static RelativePosition RelativePosition<T>(this IRange<T> range, T value)=>
            range.RelativePosition(value, Comparer<T>.Default);
        

        #endregion Public Methods
    }
}
