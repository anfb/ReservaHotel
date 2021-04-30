using ReservaHotelCore.Enums;
using ReservaHotelCore.Service;
using System;
using Xunit;

namespace ReservaHotelTest
{
    public class InputStringTest
    {
        [Fact]
        public void InputRegularClientTest()
        {
            string input = "Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            BookingRequestService inputRequest = new BookingRequestService(input);
            Assert.Equal(CustomType.Regular, inputRequest.bookingRequest.customType);

        }

        [Fact]
        public void InputRewardClientTest()
        {

        }
    }
}
