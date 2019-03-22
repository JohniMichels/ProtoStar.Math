using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Math.ODE
{
    public static class IntegrationExtensions
    {
        public static IEnumerable<TransientState> Integrate(
            this ITransientEquation transientEquation, 
            IList<double> initialState,
            double timeStep,
            IExplicitSolver solver)=>
            transientEquation.Integrate(new TransientState() { Time = 0, Point = initialState }, timeStep, solver);


        public static IEnumerable<TransientState> Integrate(
            this ITransientEquation transientEquation,
            IList<double> initialState,
            Func<TransientState, double> timeStep,
            IExplicitSolver solver) =>
            transientEquation.Integrate(new TransientState() { Time = 0, Point = initialState }, timeStep, solver);
        

        public static IEnumerable<TransientState> Integrate(
            this ITransientEquation transientEquation,
            TransientState initialState,
            double timeStep,
            IExplicitSolver solver)
        {            
            while (true)
            {
                yield return initialState;
                initialState = solver.FindNext(transientEquation, initialState, timeStep);
            }
        }

        public static IEnumerable<TransientState> Integrate(
            this ITransientEquation transientEquation,
            TransientState initialState,
            Func<TransientState, double> timeStep,
            IExplicitSolver solver)
        {            
            while (true)
            {
                yield return initialState;
                initialState = solver.FindNext(transientEquation, initialState, timeStep(initialState));
            }
        }

    }
}
