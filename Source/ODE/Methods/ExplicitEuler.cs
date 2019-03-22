using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProtoStar.Math.ODE.Methods
{
    public class ExplicitEuler : IExplicitSolver
    {
        public TransientState FindNext(ITransientEquation transientEquation, TransientState point, double timeStep) => new TransientState()
        {
            Time = point.Time + timeStep,
            Point = point.Point.Zip(transientEquation.Derivative(point.Point), (y, dy) => y + dy * timeStep).ToArray()
        };
        
    }
}
