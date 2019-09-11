using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void SpecifyJsonPropertyNames(WeatherForecastPptyNameAttr weatherForecast)
        {
            string json;
            PrintTitle("Specify JSON property names");
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            json = JsonSerializer.Serialize(weatherForecast, options);
            PrintFormattedJsonOutput(json);
            PrintJsonInput(json);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastPptyNameAttr>(json, options);
            PrintPropertyValues(weatherForecast);
        }
    }
}