using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void WriteIndentedJSON(WeatherForecastMin weatherForecast)
        {
            PrintTitle("Write indented JSON");
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(weatherForecast, options);
            PrintFormattedJsonOutput(json);
        }
    }
}