
using System;
using System.Text.Json.Serialization;

class WeatherForecastPptyNameAttr : WeatherForecastMin
{
    [JsonPropertyName("Wind")]
    public int WindSpeed { get; set; }
}