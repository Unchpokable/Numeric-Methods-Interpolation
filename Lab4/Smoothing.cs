using System;

namespace Lab4
{
    public enum SmoothingType
    {
        NonLinearLeastSquares,
        LinearLeastSquares
    }

    public class Smoothing
    {
        public static Func<float, float> NonLinearLeastSquares(Vector2[] controlPoints)
        {
            return new NonLinearLeastSquaresSmoothing(controlPoints).GetValue;
        }

        public static Func<float, float> LinearLeastSquares(Vector2[] controlPoints)
        {
            return new LinearLeastSquaresSmoothing(controlPoints).GetValue;
        }
    }
}
