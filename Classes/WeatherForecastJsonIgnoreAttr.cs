
using System;
using System.Text.Json.Serialization;

class WeatherForecastJsonIgnoreAttr : WeatherForecastMin
{
    [JsonIgnore]
    public int WindSpeed { get; set; }
}