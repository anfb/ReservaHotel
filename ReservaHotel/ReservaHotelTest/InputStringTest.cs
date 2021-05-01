using ReservaHotelCore.Enums;
using ReservaHotelCore.Models;
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
            BookingRequest inputRequest = new BookingRequest(input);
            Assert.Equal(CustomType.Regular, inputRequest.customType);
        }

        [Fact]
        public void InputRewardClientTest()
        {
            string input = "Reward: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            BookingRequest inputRequest = new BookingRequest(input);
            Assert.Equal(CustomType.Reward, inputRequest.customType);
        }

    }
}
