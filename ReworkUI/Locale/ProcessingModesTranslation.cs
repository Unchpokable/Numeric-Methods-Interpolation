using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReworkUI.Locale
{
    public class ProcessingModesTranslation
    {
        public static string TranslateProcessingMode(object type)
        {
            if (!type.GetType().IsEnum)
                throw new ArgumentException("Given type must be an enum type");

            switch (type)
            {
                case InterpolationType.Lagrange:
                    return "Интерполяция Лагранжа";
                case InterpolationType.Newton:
                    return "Интерполяция Ньютона";
                case InterpolationType.CubicSpline:
                    return "Интерполяция Кубическим Сплайном";
                case SmoothingType.LinearLeastSquares:
                    return "Сглаживание Лин. методом Наим. Квадратов";
                case SmoothingType.NonLinearLeastSquares:
                    return "Сглаживание Нелин. методом Наим. Квадратов";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
