using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CustomDatePicker.DatePickerControl
{
    public class DatePickerClass : DatePicker
    {
        /// <summary>
        /// 
        /// </summary>d
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SetDateFormat();

            DatePickerTextBox box = base.GetTemplateChild("PART_TextBox") as DatePickerTextBox;
            box.ApplyTemplate();

            ContentControl watermark = box.Template.FindName("PART_Watermark", box) as ContentControl;
            string datePattern = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
            watermark.Content = datePattern.ToUpper();
        }

        /// <summary>
        /// <para>Checks for valid date format and sets to current thread culture</para>
        /// <para>else it sets to default date format (dd/MM/yyyy HH:mm:ss)</para>
        /// </summary>
        private void SetDateFormat()
        {
            if (ConfigurationManager.AppSettings["DateSepator"] != null && ConfigurationManager.AppSettings["DateFormat"] !=null)
            {
                char separator = ConfigurationManager.AppSettings["DateSepator"].ToString()[0];

                //To check if the date format has only two separators in the given format
                var isValidDateFormat = ConfigurationManager.AppSettings["DateFormat"].Count(x => x == separator) == 2 ? true : false;

                if (isValidDateFormat)
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                    var culture = new CultureInfo(currentCulture.Name);
                    var dtfInfo = new DateTimeFormatInfo
                    {
                        ShortDatePattern = ConfigurationManager.AppSettings["DateFormat"],
                        DateSeparator = ConfigurationManager.AppSettings["DateSepator"]
                    };

                    culture.DateTimeFormat = dtfInfo;
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
                else
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                    var culture = new CultureInfo(currentCulture.Name);
                    var dtfInfo = new DateTimeFormatInfo
                    {
                        ShortDatePattern = "DD/MM/YYYY", //Default date format if the format supplied is not valid
                        DateSeparator = "/"
                    };

                    culture.DateTimeFormat = dtfInfo;
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
        }
    }
}
