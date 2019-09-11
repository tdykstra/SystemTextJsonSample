using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void DeserializeFromString(string json)
        {
            PrintTitle("Deserialize from string");
            PrintJsonInput(json);
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);
            PrintPropertyValues(weatherForecast);
        }
    }
}