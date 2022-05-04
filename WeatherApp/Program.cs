﻿// See https://aka.ms/new-console-template for more information



var apiKey = "<your-api-key>";
var today = DateTime.Now;
var lastWeekDate = DateTime.Now.AddDays(-5);
WeatherApp.IWeatherAPIClient weatherAPIClient = new WeatherApp.WeatherAPIClient(apiKey);
var avgTemp = new WeatherApp.WeatherApp(weatherAPIClient).GetAvgTempBetween(lastWeekDate, today);
Console.WriteLine(avgTemp);