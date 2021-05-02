using ReservaHotelCore.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReservaHotelTest
{
    public class BookingHotelTest
    {
        BookingRequestService bookingRequestService;

        public BookingHotelTest()
        {
            bookingRequestService = new BookingRequestService();
        }

        [Fact]
        public void GetCheapestHotel_ParqueDasFlores()
        {
            string input = "Regular: 16Mar2020(mon), 17Mar2020(tue), 18Mar2020(wed)";
            Assert.Equal("Parque das flores", bookingRequestService.GetCheapestHotel(input));
        }

        [Fact]
        public void GetCheapestHotel_JardimBotanico()
        {
            string input = "Regular: 20Mar2020(fri), 21Mar2020(sat), 22Mar2020(sun)";
            Assert.Equal("Jardim Botânico", bookingRequestService.GetCheapestHotel(input));
        }

        [Fact]
        public void GetCheapestHotel_MarAtlantico()
        {
            string input = "Reward: 26Mar2020(thur), 27Mar2020(fri), 28Mar2020(sat)";
            Assert.Equal("Mar Atlântico", bookingRequestService.GetCheapestHotel(input));
        }
    }
}
