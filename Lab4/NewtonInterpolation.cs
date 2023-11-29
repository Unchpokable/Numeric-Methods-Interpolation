namespace Lab4
{
    internal class NewtonInterpolation : InterpolationBase
    {
        public NewtonInterpolation(Vector2[] args) : base(args) { }

        public override float GetValue(float x)
        {
            int n = _controlPoints.Length;
            float[] coefficients = new float[n];

            for (int i = 0; i < n; i++)
            {
                coefficients[i] = _controlPoints[i].Y;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    coefficients[j] = (coefficients[j] - coefficients[j - 1]) / (_controlPoints[j].X - _controlPoints[j - i].X);
                }
            }

            float result = coefficients[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                result = result * (x - _controlPoints[i].X) + coefficients[i];
            }

            return result;
        }
    }
}
