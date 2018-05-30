using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDatePicker.DatePickerControl.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts String Date in Format (dd/MM/yyyy ) to Date
        /// Ex: 14/11/1990
        /// </summary>
        /// <param name="date">string to be parsed as date</param>
        /// <returns>Date in local format</returns>
        public static DateTime ToDateTimeCurrentCulture(this string date)
        {
            DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB"), DateTimeStyles.None, out DateTime validDate);
            return validDate;
        }

        /// <summary>
        /// Converts String Date in Format (dd/MM/yyyy) to Date
        /// Ex: 14/11/1990
        /// </summary>
        /// <param name="date">string to be parsed as date</param>
        /// <returns>Date in local format</returns>
        public static string ToDateCurrentCulture(this string date)
        {
            DateTime validDate;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB"), DateTimeStyles.None, out validDate))
            {
                return validDate.ToDateCurrentCulture();
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts DateTime to String Date
        ///Ex: 14/11/1990 16:30:50
        /// </summary>
        /// <param name="date">Date to be parsed as string</param>
        /// <returns>String Format of Date of Current Thread Culture</returns>
        public static string ToDateCurrentCulture(this DateTime date)
        {
            return date.ToString("d", CultureInfo.CurrentCulture);
        }

    }
}
