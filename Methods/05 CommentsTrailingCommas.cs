using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void AllowCommentsTrailingCommas()
        {
            PrintTitle("Allow comments and trailing commas");
            string json =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureC"": 25, // Fahrenheit 77
  ""Summary"": ""Hot"", /* Zharko */
}";
            PrintJsonInput(json);
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };
            WeatherForecastMin weatherForecast = JsonSerializer.Deserialize<WeatherForecastMin>(json, options);
            PrintPropertyValues(weatherForecast);
        }
    }
}