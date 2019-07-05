// Copyright � 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using Xunit;

namespace ProtoStar.Math.Tests
{
    public class RangeUT
    {
        #region Public Methods

        [Theory]
        [InlineData(1, 3, 2, false)]
        [InlineData(2, 4, 1, false)]
        [InlineData(1, 5, 1, false)]
        [InlineData(1, 5, 5, false)]
        [InlineData(1, 3, 3.2, true)]
        [InlineData(-10, -3, -1, true)]
        public void IsAbove(double lower, double upper, double value, bool isInside) =>
            Assert.Equal(isInside, (new Range<double>() { Minimum = lower, Maximum = upper }).IsAbove(value));

        [Theory]
        [InlineData(1, 3, 0, true)]
        [InlineData(2, 4, 2, false)]
        [InlineData(1, 2, 0, true)]
        [InlineData(1, 5, 0, true)]
        [InlineData(1, 3, -1, true)]
        public void IsBellow(double lower, double upper, double value, bool isBellow) =>
            Assert.Equal(isBellow, (new Range<double>() { Minimum = lower, Maximum = upper }).IsBellow(value));

        [Theory]
        [InlineData(1, 3, 2, true)]
        [InlineData(2, 4, 1, false)]
        [InlineData(1, 5, 1, true)]
        [InlineData(1, 5, 5, true)]
        [InlineData(1, 3, 3.2, false)]
        public void IsInside(double lower, double upper, double value, bool isAbove) =>
            Assert.Equal(isAbove, (new Range<double>() { Minimum = lower, Maximum = upper }).IsInside(value));


        [Theory]
        [InlineData(0,1,2, ProtoStar.Math.RelativePosition.Above)]
        [InlineData(0,1,0.5,ProtoStar.Math.RelativePosition.Inside)]
        [InlineData(0,1,-1,ProtoStar.Math.RelativePosition.Bellow)]
        public void RelativePosition(
            double minValue,
            double maxValue,
            double targetValue,
            RelativePosition expectedRelativePosition)
        {
            Assert.Equal(
                expectedRelativePosition,
                new Range<double>(minValue,maxValue).RelativePosition(targetValue));
        }

        #endregion Public Methods
    }
}