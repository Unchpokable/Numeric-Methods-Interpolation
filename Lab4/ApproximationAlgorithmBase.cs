namespace Lab4
{
    public abstract class ApproximationAlgorithmBase
    {
        protected ApproximationAlgorithmBase(Vector2[] controlPoints)
        {
            _controlPoints = controlPoints;
        }

        public abstract float GetValue(float x);

        protected Vector2[] _controlPoints;
    }
}
