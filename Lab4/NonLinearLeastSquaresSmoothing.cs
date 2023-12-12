using System;
using MathNet.Numerics.LinearAlgebra;

namespace Lab4
{
    internal class NonLinearLeastSquaresSmoothing : ApproximationAlgorithmBase
    {
        public NonLinearLeastSquaresSmoothing(Vector2[] controlPoints) : base(controlPoints)
        {
            _coefficients = FitPolynomial(controlPoints, 2);
        }

        private Vector<double> _coefficients;

        public override float GetValue(float x)
        {
            var result = 0d;

            for (var i = 0; i < _coefficients.Count; i++)
            {
                result += _coefficients[i] * Math.Pow(x, i);
            }

            return (float)result;
        }

        private Vector<double> FitPolynomial(Vector2[] data, int degree)
        {
            // Build the design matrix
            var designMatrix = BuildDesignMatrix(data, degree);

            // Build the target vector
            var targetVector = BuildTargetVector(data);

            // Solve the system of linear equations using QR decomposition
            var decomposition = designMatrix.QR();
            var coefficients = decomposition.Solve(targetVector);

            return coefficients;
        }

        // Helper method to build the design matrix
        private Matrix<double> BuildDesignMatrix(Vector2[] data, int degree)
        {
            int n = data.Length;
            var designMatrix = Matrix<double>.Build.Dense(n, degree + 1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= degree; j++)
                {
                    designMatrix[i, j] = Math.Pow(data[i].X, j);
                }
            }

            return designMatrix;
        }

        // Helper method to build the target vector
        private Vector<double> BuildTargetVector(Vector2[] data)
        {
            int n = data.Length;
            var targetVector = Vector<double>.Build.Dense(n);

            for (int i = 0; i < n; i++)
            {
                targetVector[i] = data[i].Y;
            }

            return targetVector;
        }
    }
}
