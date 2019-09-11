using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void SerializeToUtf8(WeatherForecastMin weatherForecast)
        {
            PrintTitle("Serialize to UTF8");
            PrintPropertyValues(weatherForecast);
            Console.WriteLine("With generic type parameter:");
            byte[] jsonUTF8 = JsonSerializer.SerializeToUtf8Bytes<WeatherForecastMin>(weatherForecast);
            PrintFormattedJsonOutput(Encoding.UTF8.GetString(jsonUTF8));
            Console.WriteLine("With generic type inference:");
            jsonUTF8 = JsonSerializer.SerializeToUtf8Bytes((weatherForecast));
            PrintFormattedJsonOutput(Encoding.UTF8.GetString(jsonUTF8));
        }
    }
}