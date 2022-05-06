using System;
using System.Text.Json.Nodes;

namespace WeatherApp
{
    public interface IWeatherAPIClient
    {
        JsonNode GetWeatherDataBetween(DateTime startDate, DateTime endDate);
    }
}