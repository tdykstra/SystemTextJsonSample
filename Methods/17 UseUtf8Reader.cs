using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    partial class Program
    {
        private static void UseJsonReader(byte[] jsonUtf8)
        {
            Utf8JsonReader reader = new Utf8JsonReader(jsonUtf8, isFinalBlock: true, state: default);

            while (reader.Read())
            {
                Console.Write(reader.TokenType);

                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                    case JsonTokenType.String:
                        {
                            string text = reader.GetString();
                            Console.Write(" ");
                            Console.Write(text);
                            break;
                        }

                    case JsonTokenType.Number:
                        {
                            int value = reader.GetInt32();
                            Console.Write(" ");
                            Console.Write(value);
                            break;
                        }

                        // Other token types elided for brevity
                }

                Console.WriteLine();
            }
        }
    }
}