using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CustomDatePicker.DatePickerControl
{
    /// <summary>
    /// Interaction logic for DatePickerUC.xaml
    /// </summary>
    public partial class DatePickerUC : UserControl
    {
        public static readonly DependencyProperty DPFormatProperty = DependencyProperty.Register("DPFormat", typeof(string), typeof(DatePickerClass));

        public static readonly DependencyProperty SeparatorProperty = DependencyProperty.Register("Seperator", typeof(string), typeof(DatePickerClass));

        public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register("SelectedDate", typeof(Nullable<DateTime>),
            typeof(DatePickerUC), new FrameworkPropertyMetadata(new Nullable<DateTime>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnSelectedDateChanged)));

        public string DPFormat
        {
            get { return this.GetValue(DPFormatProperty) as string; }
            set { this.SetValue(DPFormatProperty, value); }
        }

        public string Seperator
        {
            get { return this.GetValue(SeparatorProperty) as string; }
            set { this.SetValue(SeparatorProperty, value); }
        }

        public DateTime? SelectedDate
        {
            get { return this.GetValue(SelectedDateProperty) as Nullable<DateTime>; }
            set { this.SetValue(SelectedDateProperty, value); }
        }

        public DatePickerUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// Method to restrict any other separator other than the one required for the specified format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex;
            bool isModelValid = true;

            var pattern = string.Format("[0-9{0}]+$", ConfigurationManager.AppSettings["DateSepator"]);
            regex = new Regex(pattern);

            if (!string.IsNullOrWhiteSpace(e.Text) && !regex.IsMatch(e.Text))
                isModelValid = false;

            if (!isModelValid)
                e.Handled = true;
            else
                e.Handled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DatePickerUC;
            if (control != null)
                control.CustomDatePicker.SelectedDate = control.SelectedDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = sender as DatePicker;
            if (!t.SelectedDate.HasValue)
                t.DisplayDate = DateTime.Now;

            if (t.SelectedDate.HasValue)
            {
                if (CustomDatePicker.SelectedDate.HasValue)
                {
                    BindingExpression bindingExpression = BindingOperations.GetBindingExpression(CustomDatePicker, DatePicker.SelectedDateProperty);
                    bindingExpression = BindingOperations.GetBindingExpression(CustomDatePicker, DatePicker.SelectedDateProperty);
                    BindingExpressionBase bindingExpressionBase = BindingOperations.GetBindingExpressionBase(CustomDatePicker, DatePicker.SelectedDateProperty);
                    Validation.ClearInvalid(bindingExpressionBase);
                }
            }
        }

        /// <summary>
        /// Method to restrict user input for dates less than 1900 year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            var t = sender as DatePicker;

            if (t.SelectedDate.HasValue && t.SelectedDate.Value.Year < 1900)
            {
                MessageBox.Show("Please select a valid date.");
                t.SelectedDate = null;
                t.DisplayDate = DateTime.Now;
            }
        }
    }
}
