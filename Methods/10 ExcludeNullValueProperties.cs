using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void ExcludeNullValueProperties(WeatherForecastMin weatherForecast)
        {
            string json;
            PrintTitle("Exclude properties with null value");
            weatherForecast.Summary = null;
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };
            json = JsonSerializer.Serialize(weatherForecast, options);
            PrintFormattedJsonOutput(json);
            weatherForecast.Summary = "Hot";
        }
    }
}