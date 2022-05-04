using System.Text.Json.Nodes;

namespace WeatherApp;

public class WeatherAPIClient: IWeatherAPIClient
{
    private readonly string _apiKey;
    public WeatherAPIClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public JsonNode GetWeatherDataBetween(DateTime startDate, DateTime endDate)
    {
        var formattedStartDate = startDate.ToString("yyyy-MM-dd");
        var formattedEndDate = endDate.ToString("yyyy-MM-dd");
        var url = $"https://api.weatherapi.com/v1/history.json?key={_apiKey}&q=Hyderabad&dt={formattedStartDate}&end_dt={formattedEndDate}";

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var response = new HttpClient().Send(requestMessage);
        
        using var reader = new StreamReader(response.Content.ReadAsStream());
        return JsonNode.Parse(reader.ReadToEnd())!;
    }
}