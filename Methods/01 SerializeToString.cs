using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void SerializeToString(WeatherForecast weatherForecast)
        {
            string json;
            PrintTitle("Serialize to string");
            PrintPropertyValues(weatherForecast);
            json = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);
            json = JsonSerializer.Serialize(weatherForecast, new JsonSerializerOptions { DictionaryKeyPolicy = JsonNamingPolicy.CamelCase });
            Console.WriteLine($"JSON output:\n{json}\n");
            PrintFormattedJsonOutput(json);
        }
    }
}