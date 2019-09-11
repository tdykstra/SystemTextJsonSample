using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void IncludePropertiesOfDerivedClass(WeatherForecastDerived weatherForecast2b)
        {
            string json;
            WeatherForecastMin weatherForecast = weatherForecast2b;
            PrintTitle("Include properties of a derived class");
            PrintPropertyValues(weatherForecast);
            json = JsonSerializer.Serialize(weatherForecast);
            PrintFormattedJsonOutput(json);
            json = JsonSerializer.Serialize<WeatherForecastMin>(weatherForecast);
            PrintFormattedJsonOutput(json);
            json = JsonSerializer.Serialize(weatherForecast, weatherForecast.GetType());
            PrintFormattedJsonOutput(json);
        }
    }
}