using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace ReworkUI.Model
{
    internal class FunctionProcessor
    {
        public event EventHandler Finished;

        public FunctionProcessor(Vector2[] controlPoints) : this()
        {
            _controlPoints = controlPoints;
        }

        public FunctionProcessor()
        {
            Steps = new List<string>();
        }

        public List<string> Steps { get; }

        private Vector2[] _controlPoints;

        public float Step { get; set; }

        public void AssignControlPoints(Vector2[] controlPoints)
        {
            _controlPoints = controlPoints;
        }

        public OxyPlot.PlotModel InterpolateRange(InterpolationType type)
        {
            if (_controlPoints == null)
                return null;

            Func<float, float> interpolator = null;

            switch (type)
            {
                case InterpolationType.Lagrange:
                    interpolator = Interpolation.OfLagrange(_controlPoints);
                    break;
                case InterpolationType.Newton:
                    interpolator = Interpolation.OfNewton(_controlPoints);
                    break;
                case InterpolationType.CubicSpline:
                    interpolator = Interpolation.CubicSpline(_controlPoints);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return ProcessFunction(interpolator);
        }

        public OxyPlot.PlotModel SmoothRange(SmoothingType type)
        {
            if (_controlPoints == null)
                return null;

            Func<float, float> interpolator = null;

            switch (type)
            {
                case SmoothingType.NonLinearLeastSquares:
                    interpolator = Smoothing.NonLinearLeastSquares(_controlPoints);
                    break;
                case SmoothingType.LinearLeastSquares:
                    interpolator = Smoothing.LinearLeastSquares(_controlPoints);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return ProcessFunction(interpolator);
        }

        private PlotModel ProcessFunction(Func<float, float> interpolator)
        {
            var model = new PlotModel();

            var controlPointsSeries = new ScatterSeries()
                { MarkerType = MarkerType.Circle, Title = "Опорные значения", MarkerFill = OxyColors.LawnGreen };

            foreach (var point in _controlPoints)
                controlPointsSeries.Points.Add(new ScatterPoint(point.X, point.Y));

            var interpolationSeries = new LineSeries() { Color = OxyColors.LightBlue, Title = "Аппроксимированная функция" };

            var minx = _controlPoints.Select(x => x.X).Min();
            var maxx = _controlPoints.Select(x => x.X).Max();

            for (var x = minx; x <= maxx; x += Step)
            {
                var interpX = interpolator.Invoke(x);
                interpolationSeries.Points.Add(new DataPoint(x, interpX));
                Steps.Add($"x = {x:0.0000}, y = {interpX:0.0000}");
            }

            model.Series.Add(controlPointsSeries);
            model.Series.Add(interpolationSeries);

            OnFinished();

            return model;
        }

        protected virtual void OnFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }
    }
}
