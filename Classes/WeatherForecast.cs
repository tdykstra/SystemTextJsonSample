
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public string SummaryField;
    public IList<DateTimeOffset> DatesAvailable { get; set;}
    public Dictionary<string, int> TemperatureRanges2 { get; set; }
    public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }

    public string [] SummaryWords { get; set; }
    public override string ToString()
    {
        var output = new StringBuilder();
        var properties = this.GetType().GetProperties();
        output.Append($"Date: {Date}\n");
        output.Append($"TemperatureC: {TemperatureC}\n");
        output.Append($"Summary: {Summary}\n");
        output.Append($"SummaryField: {SummaryField}\n");
        output.Append($"DatesAvailable: \n");
        foreach (DateTimeOffset date in DatesAvailable)
        {
            output.Append($"  {date}\n");
        }
        output.Append($"TemperatureRanges2: \n");
        foreach (KeyValuePair<string, int> kvp in TemperatureRanges2)
        {
            output.Append($"  {kvp.Key} {kvp.Value}\n");
        }
        output.Append($"TemperatureRanges: \n");
        foreach (KeyValuePair<string, HighLowTemps> kvp in TemperatureRanges)
        {
            output.Append($"  {kvp.Key} {kvp.Value.Low.Celsius} {kvp.Value.High.Celsius}\n");
        }
        output.Append($"SummaryWords: \n");
        foreach (string word in SummaryWords)
        {
            output.Append($"  {word}\n");
        }
        return output.ToString();
    }
}

public class HighLowTemps
{
    public Temperature High { get; set; }
    public Temperature Low { get; set; }
}

public class Temperature
{
    public int Celsius { get; set; }
}