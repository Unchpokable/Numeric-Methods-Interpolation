using Lab4;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ReworkUI.Converters
{
    public class EnumToLocalizedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !value.GetType().IsEnum)
                return null;

            try
            {
                string result = TranslateProcessingMode(value);
                return result;
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not needed for a one-way conversion
            throw new NotImplementedException();
        }

        private static string TranslateProcessingMode(object type)
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
