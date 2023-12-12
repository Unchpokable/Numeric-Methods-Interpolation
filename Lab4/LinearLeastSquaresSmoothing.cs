using Lab4;
using MathNet.Numerics.LinearAlgebra;

namespace Lab4
{
    internal class LinearLeastSquaresSmoothing : ApproximationAlgorithmBase
    {
        public LinearLeastSquaresSmoothing(Vector2[] controlPoints) : base(controlPoints)
        {
            // Perform the least squares fitting to find the coefficients
            _coefficients = FitLinear(controlPoints);
        }
        
        private Vector<double> _coefficients;

        public override float GetValue(float x)
        {
            // Evaluate the linear function at the given x-coordinate
            double result = _coefficients[0] * x + _coefficients[1];

            return (float)result;
        }

        // Helper method to fit a linear function using least squares
        private Vector<double> FitLinear(Vector2[] data)
        {
            // Build the design matrix
            var designMatrix = BuildLinearDesignMatrix(data);

            // Build the target vector
            var targetVector = BuildTargetVector(data);

            // Solve the system of linear equations using QR decomposition
            var decomposition = designMatrix.QR();
            var coefficients = decomposition.Solve(targetVector);

            return coefficients;
        }

        // Helper method to build the design matrix for a linear function
        private Matrix<double> BuildLinearDesignMatrix(Vector2[] data)
        {
            int n = data.Length;
            var designMatrix = Matrix<double>.Build.Dense(n, 2);

            for (int i = 0; i < n; i++)
            {
                designMatrix[i, 0] = data[i].X; // X term
                designMatrix[i, 1] = 1.0; // Constant term
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