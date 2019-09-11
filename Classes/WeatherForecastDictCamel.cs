
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

class WeatherForecastDictCamel
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public Dictionary<string, int> TemperatureRanges { get; set; }
}