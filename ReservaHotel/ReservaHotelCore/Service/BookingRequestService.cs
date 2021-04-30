using ReservaHotelCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaHotelCore.Service
{
    public class BookingRequestService
    {
        public BookingRequest bookingRequest { get; set; }
        public BookingRequestService(string textRequest)
        {
            bookingRequest = new BookingRequest(textRequest);
        }


    }
}
