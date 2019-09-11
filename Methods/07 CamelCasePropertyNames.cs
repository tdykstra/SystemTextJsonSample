using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void CamelCasePropertyNames(WeatherForecastMin weatherForecast)
        {
            string json;
            PrintTitle("CamelCase JSON property names");
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            json = JsonSerializer.Serialize(weatherForecast, options);
            PrintFormattedJsonOutput(json);
            PrintJsonInput(json);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastMin>(json, options);
            PrintPropertyValues(weatherForecast);
        }
    }
}