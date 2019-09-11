using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void CustomNamingPolicy(WeatherForecastMin weatherForecast)
        {
            string json;
            PrintTitle("Custom JSON property naming policy");
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy()
            };
            json = JsonSerializer.Serialize(weatherForecast, options);
            PrintFormattedJsonOutput(json);
            PrintJsonInput(json);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastMin>(json, options);
            PrintPropertyValues(weatherForecast);
        }
    }
}