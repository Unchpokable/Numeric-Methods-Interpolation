namespace Lab4
{
    public abstract class InterpolationBase
    {
        protected InterpolationBase(Vector2[] controlPoints)
        {
            _controlPoints = controlPoints;
        }

        public abstract float GetValue(float x);

        protected Vector2[] _controlPoints;
    }
}
