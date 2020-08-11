﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ComplexPractice.Helpers
{
    class DistinctConverterDELETE : IValueConverter
    {
        public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = value as IEnumerable;
            if (values == null)
                return null;
            return values.Cast<object>()/*.Where(x => !string.IsNullOrWhiteSpace(x.ToString()))*/.Distinct();
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
