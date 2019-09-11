using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void CaseInsensitive(WeatherForecastMin weatherForecast)
        {
            string json;
            WeatherForecastMin weatherForecast1;
            weatherForecast1 = weatherForecast;
            PrintTitle("Case insensitive property name matching");
            var optionsUpperCase = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy()
            };
            json = JsonSerializer.Serialize(weatherForecast1, optionsUpperCase);
            PrintJsonInput(json);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastMin>(json, options);
            PrintPropertyValues(weatherForecast);
        }
    }
}