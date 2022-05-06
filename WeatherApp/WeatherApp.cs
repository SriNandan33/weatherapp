namespace WeatherApp;

public class WeatherApp{
    private readonly IWeatherAPIClient _weatherApiClient;
    public WeatherApp(IWeatherAPIClient weatherAPIClient)
    {
        _weatherApiClient = weatherAPIClient;
    }


    public double GetAvgTempBetween(DateTime startDate, DateTime endDate)
    {
        var weatherDataResponse = _weatherApiClient.GetWeatherDataBetween(startDate, endDate);
        
        var readings = weatherDataResponse["forecast"]["forecastday"];
        var numOfReadings = readings.AsArray().Count;
        
        double sumOfTemps = 0;
        for(var i=0; i < numOfReadings; i++){
            sumOfTemps += (double)readings[i]["day"]["avgtemp_c"];
        }
        
        return Math.Round(sumOfTemps/numOfReadings, 2);
    }
}