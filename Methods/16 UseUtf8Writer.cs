using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void UseJsonWriter()
        {
            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream, options))
                {
                    writer.WriteStartObject();
                    writer.WriteString("date", DateTimeOffset.UtcNow);
                    writer.WriteNumber("temp", 42);
                    writer.WriteEndObject();
                }

                string json = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine(json);
            }
        }
    }
}