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
            Assert.Equal(CustomerType.Regular, inputRequest.CustomerType);
        }

        [Fact]
        public void InputRewardClientTest()
        {
            string input = "Reward: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            BookingRequest inputRequest = new BookingRequest(input);
            Assert.Equal(CustomerType.Reward, inputRequest.CustomerType);
        }

        [Fact]
        public void NumberOfDatesEnteredTest()
        {
            string input = "Reward: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            BookingRequest inputRequest = new BookingRequest(input);
            Assert.Equal(3, inputRequest.Dates.Count);
        }

        [Fact]
        public void CustomerExceptionTest()
        {
            string errorMessage = "Customer type should be Regular or Fidelidade.";

            string input = "Rew: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            Action action = () => new BookingRequest(input);
            ArgumentException exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal(errorMessage, exception.Message);
        }

        [Fact]
        public void DateFormatException()
        {
            string errorMessage = "Date format is invalid.";
            string input = "Reward: 36Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            Action action = () => new BookingRequest(input);
            ArgumentException exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
