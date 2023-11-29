using System;

namespace Lab4
{
    public enum InterpolationType
    {
        Lagrange,
        Newton
    }

    public class Interpolation
    {
        public static Func<float, float> OfLagrange(Vector2[] args)
        {
            return new LagrangeInterpolation(args).GetValue;
        }

        public static Func<float, float> OfNewton(Vector2[] args)
        {
            return new NewtonInterpolation(args).GetValue;
        }
    }
}
