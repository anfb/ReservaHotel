using ReservaHotelCore.Enums;
using ReservaHotelCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservaHotelCore.Service
{
    public static class BookingRequestService
    {
        public static List<Hotel> Hotels = new List<Hotel>();
        
        public static string GetCheapestHotel(string textRequest)
        {
            BookingRequest bookingRequest = new BookingRequest(textRequest);
            int numberDayOfWeek = bookingRequest.dates.Count(dWk => dWk.DayOfWeek != DayOfWeek.Saturday && dWk.DayOfWeek != DayOfWeek.Sunday);
            int numberDayWeekend = bookingRequest.dates.Count(dWnd => dWnd.DayOfWeek == DayOfWeek.Sunday || dWnd.DayOfWeek == DayOfWeek.Saturday);

            if (bookingRequest.customType.Equals(CustomType.Regular))
            {
                Hotels.Add(new Hotel("Parque das flores", 3, 110*numberDayOfWeek, 90*numberDayWeekend));
                Hotels.Add(new Hotel("Jardim Botânico", 4, 160*numberDayOfWeek, 60*numberDayWeekend));
                Hotels.Add(new Hotel("Mar Atlântico", 5, 220*numberDayOfWeek, 150*numberDayWeekend));
            }
            else
            {
                Hotels.Add(new Hotel("Parque das flores", 3, 80 * numberDayOfWeek, 80 * numberDayWeekend));
                Hotels.Add(new Hotel("Jardim Botânico", 4, 110 * numberDayOfWeek, 50 * numberDayWeekend));
                Hotels.Add(new Hotel("Mar Atlântico", 5, 100 * numberDayOfWeek, 40 * numberDayWeekend));
            }

            Hotel hotel =  Hotels.OrderBy(h => h.totalPrice)
                                    .ThenByDescending(h => h.Classification).FirstOrDefault();

            return hotel.HotelName;
        }

    }
}
