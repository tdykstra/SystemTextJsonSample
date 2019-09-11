using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void CamelCaseDictionaryKeys(WeatherForecast weatherForecast)
        {
            PrintTitle("Camel case dictionary keys");
            PrintPropertyValues(weatherForecast);
            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            };
            string json = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine(json);
            PrintFormattedJsonOutput(json);
        }
    }
}