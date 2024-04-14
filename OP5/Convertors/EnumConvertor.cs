using OP5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OP5.Convertors
{
    public class EnumConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case ExamTableObject.Difficalties.Легкий:
                    return "Легкий";
                case ExamTableObject.Difficalties.Сложный:
                    return "Сложный";
                case ExamTableObject.Difficalties.Средний:
                    return "Средний";
            }
            return "Неопознано";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case "Легкий":
                    return ExamTableObject.Difficalties.Легкий;
                case "Сложный":
                    return ExamTableObject.Difficalties.Сложный;
                case "Средний":
                    return ExamTableObject.Difficalties.Средний;
            }
            return "Неопознано";
        }
    }
}
