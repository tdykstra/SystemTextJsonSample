using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Complex object to illustrate multiple serialization capabilities.
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureC = 25,
                Summary = "Hot",
                SummaryField = "Hot",
                DatesAvailable = new List<DateTimeOffset>() { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },

                TemperatureRanges2 = new Dictionary<string, int> { { "Cold", 20 }, { "Hot", 40 } },
                TemperatureRanges =
                    new Dictionary<string, HighLowTemps>
                    {
                        { "Cold", new HighLowTemps { High = new Temperature { Celsius = 20 }, Low = new Temperature { Celsius = -10 } } },
                        { "Hot", new HighLowTemps { High = new Temperature { Celsius = 60 }, Low = new Temperature { Celsius = 20 } } }},
                SummaryWords = new string[] { "Cool", "Windy", "Humid" }
            };
            // Json version of the preceding object, but includes an element for a field
            // to illustrate that fields are ignored during deserialization.
            string weatherForecastJson =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""temperatureC"": 25,
  ""Summary"": ""Hot"",
  ""SummaryField"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
    ""Cold"": {
      ""High"": {
        ""Celsius"": 20
      },
      ""Low"": {
        ""Celsius"": -10
      }
    },
    ""Hot"": {
      ""High"": {
        ""Celsius"": 60
      },
      ""Low"": {
        ""Celsius"": 20
      }
    }
  },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}";

            var weatherForecastMin = new WeatherForecastMin { Date = DateTime.Parse("2019-08-01"), TemperatureC = 25, Summary = "Hot" };
            var weatherForecastPptyNameAttr = new WeatherForecastPptyNameAttr { Date = DateTime.Parse("2019-08-01"), TemperatureC = 25, Summary = "Hot and windy", WindSpeed = 35 };
            var weatherForecastDerived = new WeatherForecastDerived { Date = DateTime.Parse("2019-08-01"), TemperatureC = 25, Summary = "Hot and windy", WindSpeed = 35 };
            var weatherForecastReadOnlyPpty = new WeatherForecastReadOnlyPpty { Date = DateTime.Parse("2019-08-01"), TemperatureC = 25, Summary = "Hot" };
            var weatherForecastJsonIgnoreAttr = new WeatherForecastJsonIgnoreAttr { Date = DateTime.Parse("2019-08-01"), TemperatureC = 25, Summary = "Hot", WindSpeed = 77 };
            var weatherForecastDictCamel = new WeatherForecastDictCamel { Date = DateTime.Parse("2019-08-01"), TemperatureC = 25, Summary = "Hot", TemperatureRanges = new Dictionary<string, int> { { "Cold", 20 }, { "Hot", 40 } } };

            byte[] jsonUtf8 = JsonSerializer.SerializeToUtf8Bytes(weatherForecastMin, new JsonSerializerOptions { WriteIndented = true });

            var weatherForecasts = new List<WeatherForecastMin>
            {
                weatherForecastMin,
                new WeatherForecastMin { Date = DateTime.Parse("2019-09-30"), TemperatureC = 10, Summary = "Cold" }
            };


            CamelCaseDictionaryKeys(weatherForecast);
            Console.ReadLine();

            int selection;
            do
            {
                selection = DisplayMenu();
                switch (selection)
                {
                    case 1:
                        SerializeToString(weatherForecast);
                        SerializeToUtf8(weatherForecastMin);
                        break;
                    case 2:
                        DeserializeFromString(weatherForecastJson);
                        break;
                    case 3:
                        WriteIndentedJSON(weatherForecastMin);
                        break;
                    case 4:
                        AllowCommentsTrailingCommas();
                        break;
                    case 5:
                        SpecifyJsonPropertyNames(weatherForecastPptyNameAttr);
                        CamelCasePropertyNames(weatherForecastMin);
                        CustomNamingPolicy(weatherForecastMin);
                        CamelCaseDictionaryKeys(weatherForecast);
                        break;
                    case 6:
                        ExcludeSelectedProperties(weatherForecastJsonIgnoreAttr);
                        ExcludeReadOnlyProperties(weatherForecastReadOnlyPpty);
                        ExcludeNullValueProperties(weatherForecastMin);
                        break;
                    case 7:
                        CaseInsensitive(weatherForecastMin);
                        break;
                    case 8:
                        IncludePropertiesOfDerivedClass(weatherForecastDerived);
                        break;
                    case 9:
                        UseJsonWriter();
                        break;
                    case 10:
                        UseJsonReader(jsonUtf8);
                        break;
                };
            } while (selection != 0);
        }

        private static int DisplayMenu()
        {
            Console.WriteLine("Select a scenario");
            Console.WriteLine();
            Console.WriteLine("1. Serialize");
            Console.WriteLine("2. Deserialize");
            Console.WriteLine("3. Format JSON output");
            Console.WriteLine("4. Allow comments and trailing commas");
            Console.WriteLine("5. Customize JSON names");
            Console.WriteLine("6. Exclude properties");
            Console.WriteLine("7. Deserialize case insensitive");
            Console.WriteLine("8. Include derived class properties");
            Console.WriteLine("9. Utf8JsonWriter");
            Console.WriteLine("10. Utf8JsonReader");
            Console.WriteLine();
            Console.WriteLine("Select:");
            var result = Console.ReadLine();
            int selection = 0;
            int.TryParse(result, out selection);
            return selection;
        }

        private static void PrintJsonInput(string json)
        {
            Console.WriteLine($"JSON input:\n{json}\n");
        }

        private static void PrintFormattedJsonOutput(string json)
        {
            Object jsonObject = JsonSerializer.Deserialize<Object>(json);
            json = JsonSerializer.Serialize(jsonObject, jsonObject.GetType(), new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine($"Formatted JSON output:\n{json}\n");
        }

        private static void PrintPropertyValues(object weatherForecast)
        {
            Console.WriteLine("weatherForecast property values:");
            if (weatherForecast is WeatherForecast)
            {
                Console.WriteLine(weatherForecast.ToString());
            }
            else
            {
                var properties = weatherForecast.GetType().GetProperties();
                foreach (var property in properties)
                {
                    Console.WriteLine($"  {property.Name}: {property.GetGetMethod().Invoke(weatherForecast, null)}");
                }
            }
            Console.WriteLine();
        }

        private static void PrintTitle(string title)
        {
            Console.WriteLine($"\n{title}");
            Console.WriteLine(new string('-', title.Length));
            Console.WriteLine();
        }
    }
}
