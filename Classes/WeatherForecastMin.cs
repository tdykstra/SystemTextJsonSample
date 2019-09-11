
using System;
using System.Text.Json.Serialization;

class WeatherForecastMin
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}