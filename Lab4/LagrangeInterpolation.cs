namespace Lab4
{
    internal class LagrangeInterpolation : InterpolationBase
    {
        public LagrangeInterpolation(Vector2[] controlPoints) : base(controlPoints) { }

        public override float GetValue(float x)
        {
            var result = 0.0f;

            for (var j = 0; j < _controlPoints.Length; j++)
            {
                result += GetInner(x, j);
            }

            return result;
        }

        private float GetInner(float x, int j)
        {
            var dividend = 1.0f;
            var divisor = 1.0f;

            for (var k = 0; k < _controlPoints.Length; k++)
            {
                if (k == j)
                    continue;

                dividend *= (x - _controlPoints[k].X);
                divisor *= (_controlPoints[j].X - _controlPoints[k].X);
            }

            return (dividend / divisor) * _controlPoints[j].Y;
        }
    }
}
