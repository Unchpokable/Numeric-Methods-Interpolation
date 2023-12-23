using Lab4;
using System;
using System.Globalization;
using System.Windows.Data;
using ReworkUI.Locale;

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
                string result = ProcessingModesTranslation.TranslateProcessingMode(value);
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

        
    }
}
