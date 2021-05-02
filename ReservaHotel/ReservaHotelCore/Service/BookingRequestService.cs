using ReservaHotelCore.Enums;
using ReservaHotelCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservaHotelCore.Service
{
    public class BookingRequestService
    {
        public string GetCheapestHotel(string textRequest)
        {
            List<Hotel> hotels = new List<Hotel>();

            BookingRequest bookingRequest = new BookingRequest(textRequest);

            hotels.Add(new Hotel(
                hotelName: "Parque das flores", 
                classification: 3, 
                taxWeek: (bookingRequest.CustomerType == CustomerType.Regular ? 110 : 80)*bookingRequest.NumberWeekDays, 
                taxWeekend: (bookingRequest.CustomerType == CustomerType.Regular ? 90 : 80)*bookingRequest.NumberWeekendDays));
            hotels.Add(new Hotel(
                hotelName: "Jardim Botânico", 
                classification: 4, 
                taxWeek: (bookingRequest.CustomerType == CustomerType.Regular ? 160 : 110)*bookingRequest.NumberWeekDays, 
                taxWeekend: (bookingRequest.CustomerType == CustomerType.Regular ? 60 : 50)*bookingRequest.NumberWeekendDays));
            hotels.Add(new Hotel(
                hotelName: "Mar Atlântico", 
                classification: 5, 
                taxWeek: (bookingRequest.CustomerType == CustomerType.Regular ? 220 : 100)*bookingRequest.NumberWeekDays, 
                taxWeekend: (bookingRequest.CustomerType == CustomerType.Regular ? 150 : 40)*bookingRequest.NumberWeekendDays));

            return hotels.OrderBy(h => h.totalPrice).ThenByDescending(h => h.Classification).FirstOrDefault().HotelName;
        }

    }
}
