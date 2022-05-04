using Xunit;
using Moq;
using WeatherApp;
using System;
using System.Text.Json.Nodes;

namespace WeatherApp.Tests{
    public class TestWeatherApp
    {
        [Fact]
        public void TestAverageTemperatureBetweenTwoDates()
        {
            var stubApiClient = new Mock<IWeatherAPIClient>();
            var startDate = DateTime.Parse("2022-05-02");
            var endDate = DateTime.Parse("2022-05-02");
            stubApiClient.Setup(apiClient => apiClient.GetWeatherDataBetween(startDate, endDate))
                .Returns(JsonNode.Parse(@"{
                    ""forecast"": {
                        ""forecastday"": [
                            {
                                ""day"": {
                                    ""avgtemp_c"": 34
                                }
                            },
                             {
                                ""day"": {
                                    ""avgtemp_c"": 38
                                }
                            }
                        ]}}"
                    )
                );
            var weatherapp = new WeatherApp(stubApiClient.Object);
            
            var result = weatherapp.GetAvgTempBetween(startDate, endDate);

            Assert.Equal(36, result);
        }
    }
}
