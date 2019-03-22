using Xunit;
using System;

namespace ProtoStar.Math.Tests
{
    public class PrecisionTest
    {
        [Theory]
        [InlineData(1.0,1.2,0.21,true)]
        [InlineData(1.0,1.3,0.21,false)]
        [InlineData(-1.0,-1.2,0.21,true)]
        [InlineData(-1.0,-1.3,0.21,false)]
        public void AbsolutePrecisionEquals(double left, double right, double precision, bool areEqual)
        {
            var prec = new Precision(){
                AbsoluteDeviation=precision
            };
            Assert.Equal(areEqual,prec.AbsoluteEquals(left,right));
        }

        [Theory]
        [InlineData(100.0,101,0.015,true)]
        [InlineData(100.0,102,0.015,false)]
        public void RelativePrecisionEquals(double left, double right, double precision, bool areEqual)
        {
            var prec = new Precision(){
                RelativeDeviation=precision
            };
            Assert.Equal(areEqual,prec.RelativeEquals(left,right));
        }

    }
}