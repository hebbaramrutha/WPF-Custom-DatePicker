using CustomDatePicker.DatePickerControl.Extensions;
using System;

namespace CustomDatePicker
{
    public class MainVM
    {
        public MainVM()
        {
            var joiningDate = "14/11/1990 00:00:00";
            DateOfJoining = joiningDate.ToDateTimeCurrentCulture();
        }

        private DateTime? _dateOfBirth;
        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value == _dateOfBirth) return;
                _dateOfBirth = value;
            }
        }

        private DateTime? _dateOfJoining;
        public DateTime? DateOfJoining
        {
            get { return _dateOfJoining; }
            set
            {
                if (value == _dateOfJoining) return;
                _dateOfJoining = value;
            }
        }
    }
}
