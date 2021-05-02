using ReservaHotelCore.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ReservaHotelCore.Models
{
    public class BookingRequest
    {
        public const int CUSTOM_STRING_INDEX = 0;
        public const int DATES_STRING_INDEX = 1;
        public CustomerType CustomerType { get; private set; }
        public List<DateTime> Dates { get; private set; }
        public int NumberWeekDays { get { return Dates.Count(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday); } }
        public int NumberWeekendDays { get { return Dates.Count() - NumberWeekDays; } }

        public BookingRequest(string textRequest)
        {
            Dates = new List<DateTime>();
            DataValidation(textRequest);
        }

        private void DataValidation(string textRequest)
        {
            string[] inputStrings = textRequest.Split(':');

            try
            {
            this.CustomerType = (CustomerType)Enum.Parse(typeof(CustomerType), inputStrings[CUSTOM_STRING_INDEX]);

            }
            catch
            {
                throw new ArgumentException("Customer type should be Regular or Fidelidade.");
            }

            try
            {
                inputStrings[DATES_STRING_INDEX].Split(',').ToList().ForEach(d => 
                            Dates.Add(DateTime.ParseExact(d.Split('(')[0].Trim(), "ddMMMyyyy", CultureInfo.InvariantCulture)));

            }
            catch
            {
                throw new ArgumentException("Date format is invalid.");
            }
        }
    }
}
