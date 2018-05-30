# WPF-Custom-DatePicker
WPF datepicker with configurable date format that will remain uniform throughout the application

For the designed date picker control, the date format has been placed in App.config. 

The watermark for the datepicker would show according to the format. 

On click of submit button, the view model property value is displayed.

The SetDateFormat() in DatePickerClass sets the date format on load of the control. The date format would be uniform throught the application.

To use the datepicker control in xaml, include the namespace xmlns:dp="clr-namespace:CustomDatePicker.DatePickerControl". 
The control can be used by using the <dp:DatePickerUC></dp:DatePickerUC>


Validations
1) Restricts input of alphabets and special characters
2) Restricts any separator input apart from what is supplied. e.g if the date format is MM-dd-yyyy, "/" input is restricted.
3) If the user enters any date that is less than the year 1900, validation message will be shown.



