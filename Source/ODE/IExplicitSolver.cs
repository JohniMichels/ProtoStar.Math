using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Math.ODE
{
    public interface IExplicitSolver
    {
        TransientState FindNext(ITransientEquation transientEquation, TransientState state, double timeStep);
    }
}
