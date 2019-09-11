using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void ExcludeReadOnlyProperties(WeatherForecastReadOnlyPpty weatherForecast)
        {
            string json;
            PrintTitle("Exclude read-only properties");
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true
            };
            json = JsonSerializer.Serialize(weatherForecast, options);
            PrintFormattedJsonOutput(json);
        }
    }
}