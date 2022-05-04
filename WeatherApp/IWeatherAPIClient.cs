using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace WeatherApp
{
    public interface IWeatherAPIClient
    {
        JsonNode GetWeatherDataBetween(DateTime startDate, DateTime endDate);
    }
}