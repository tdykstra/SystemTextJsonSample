
using System;
using System.Text.Json.Serialization;

class WeatherForecastDerived : WeatherForecastMin
{
    public int WindSpeed { get; set; }
}