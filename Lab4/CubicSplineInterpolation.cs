using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal struct SplineF
    {
        public float a, b, c, d, x;
    }

    internal class CubicSplineInterpolation : InterpolationBase
    {
        public CubicSplineInterpolation(Vector2[] args) : base(args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Cubic spline interpolation requires at least 2 base values");
            }
            Array.Sort(_controlPoints, (a, b) => a.X.CompareTo(b.X));

            _splines = new SplineF[args.Length];

            float[] xs, ys;

            Utils.Split(args, out xs, out ys);
            PrepareSplines(xs, ys);
        }

        private SplineF[] _splines;
        

        public override float GetValue(float x)
        {
            if (_splines == null)
                return float.NaN;

            var n = _splines.Length;

            SplineF spline;
            if (x <= _splines[0].x)
            {
                spline = _splines[0];
            }
            else if (x >= _splines[n - 1].x)
            {
                spline = _splines[n - 1];
            }
            else
            {
                // Binary search
                int i = 0;
                int j = n - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (x <= _splines[k].x)
                    {
                        j = k;
                    }
                    else
                    {
                        i = k;
                    }
                }
                spline = _splines[j];
            }

            float dx = x - spline.x;

            return spline.a + (spline.b + (spline.c / 2.0f + spline.d * dx / 6.0f) * dx) * dx;
        }

        private void PrepareSplines(float[] x, float[] y)
        {
            var n = x.Length;
            // Инициализация массива сплайнов
            _splines = new SplineF[n];
            for (int i = 0; i < n; ++i)
            {
                _splines[i].x = x[i];
                _splines[i].a = y[i];
            }
            _splines[0].c = _splines[n - 1].c = 0.0f;

            // Решение СЛАУ относительно коэффициентов сплайнов c[i] методом прогонки для трехдиагональных матриц
            // Вычисление прогоночных коэффициентов - прямой ход метода прогонки
            float[] alpha = new float[n - 1];
            float[] beta = new float[n - 1];
            alpha[0] = beta[0] = 0.0f;
            for (int i = 1; i < n - 1; ++i)
            {
                float hi = x[i] - x[i - 1];
                float hi1 = x[i + 1] - x[i];
                float A = hi;
                float C = 2.0f * (hi + hi1);
                float B = hi1;
                float F = 6.0f * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                float z = (A * alpha[i - 1] + C);
                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }

            // Нахождение решения - обратный ход метода прогонки
            for (int i = n - 2; i > 0; --i)
            {
                _splines[i].c = alpha[i] * _splines[i + 1].c + beta[i];
            }

            // По известным коэффициентам c[i] находим значения b[i] и d[i]
            for (int i = n - 1; i > 0; --i)
            {
                float hi = x[i] - x[i - 1];
                _splines[i].d = (_splines[i].c - _splines[i - 1].c) / hi;
                _splines[i].b = hi * (2.0f * _splines[i].c + _splines[i - 1].c) / 6.0f + (y[i] - y[i - 1]) / hi;
            }
        }
    }
}
