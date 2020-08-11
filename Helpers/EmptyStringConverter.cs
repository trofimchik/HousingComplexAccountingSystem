﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ComplexPractice.Helpers
{
    public class EmptyStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType,
              object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                return string.IsNullOrEmpty(value as string) ? parameter : value;
            }
            else
            {
                return ((int)value == 0) ? parameter : value;
            }
        }

        public object ConvertBack(object value, Type targetType,
               object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
