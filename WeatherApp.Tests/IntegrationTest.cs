using System;
using Xunit;

namespace WeatherApp.Tests
{
    public class TestWeatherApp
    {
        [Fact]
        public void TestAverageTemperatureBetweenTwoDates(){
            // Arrange
            var startDate = DateTime.Parse("2022-05-02");
            var endDate = DateTime.Parse("2022-05-03");
            var apiKey = "d07fd64cd5c5495face164104221904";
            var weatherApp = new WeatherApp(apiKey);

            // Act
            var result = weatherApp.GetAvgTempBetween(startDate, endDate);

            //Assert
            Assert.Equal(37, result);
        }
    }
}