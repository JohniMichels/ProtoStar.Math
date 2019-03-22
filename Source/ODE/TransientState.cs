using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Math.ODE
{
    public struct TransientState    
    {
        public IList<double> Point { get; set; }
        public double Time { get; set; }

        public TransientState(
            IList<double> state,
            double time)
        {
            Point = state;
            Time = time;
        }

        public TransientState(IList<double> state):this(state,0.0){}

    }
}
