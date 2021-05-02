using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaHotelCore.Models
{
    public class Hotel
    {
        public string HotelName { get; set; }
        public int Classification { get; set; }
        public double TaxWeek { get; set; }
        public double TaxWeekend { get; set; }
        public double totalPrice { 
            get 
            { 
                return this.TaxWeek + this.TaxWeekend; 
            } 
        }

        public Hotel(string hotelName, int classification, double taxWeek, double taxWeekend)
        {
            this.HotelName = hotelName;
            this.Classification = classification;
            this.TaxWeek = taxWeek;
            this.TaxWeekend = taxWeekend;
        }

    }
}
