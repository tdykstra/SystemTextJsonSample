using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void ExcludeSelectedProperties(WeatherForecastJsonIgnoreAttr weatherForecast)
        {
            string json;
            PrintTitle("Exclude selected properties by using [JsonIgnore] attribute");
            PrintPropertyValues(weatherForecast);
            json = JsonSerializer.Serialize(weatherForecast);
            PrintFormattedJsonOutput(json);
        }
    }
}