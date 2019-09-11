                
using System;
using System.Text.Json.Serialization;

class WeatherForecastReadOnlyPpty : WeatherForecastMin
{
    public WeatherForecastReadOnlyPpty()
    {
        SummaryReadOnly = "Neither hot nor cold";
    }
    public string SummaryReadOnly { get; private set; }
}