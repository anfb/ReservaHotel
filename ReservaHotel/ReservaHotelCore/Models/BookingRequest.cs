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
        public CustomType customType { get; set; }
        public List<DateTime> dates { get; set; }

        public BookingRequest(string textRequest)
        {
            dates = new List<DateTime>();
            DataValidation(textRequest);
        }

        private void DataValidation(string textRequest)
        {
            string[] inputStrings = textRequest.Split(':');
            if (Enum.IsDefined(typeof(CustomType), inputStrings[CUSTOM_STRING_INDEX]))
            {
                this.customType = inputStrings[CUSTOM_STRING_INDEX].Equals(CustomType.Regular) ? CustomType.Regular : CustomType.Reward;

                try
                {
                    (inputStrings[DATES_STRING_INDEX].Split(',')).ToList().ForEach(d => dates.Add(DateTime.ParseExact(d.Trim(), "ddMMMyyyy", CultureInfo.InvariantCulture)));
                }
                catch(ArgumentException e)
                {
                    
                }
            }
            else
            {
                throw new ArgumentException("Client type does note exist.");
            }
        }
    }
}
