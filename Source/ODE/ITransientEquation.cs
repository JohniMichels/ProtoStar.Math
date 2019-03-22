using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Math.ODE
{
    public interface ITransientEquation
    {
        IList<double> Derivative(IList<double> state);
    }
}
