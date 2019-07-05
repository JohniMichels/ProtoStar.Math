// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

namespace ProtoStar.Math
{
    public struct Range<T> : IRange<T>
    {
        #region Public Properties

        public Range(T minimum, T maximum)
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
        }

        public T Maximum { get; set; }

        public T Minimum { get; set; }

        #endregion Public Properties
    }
}