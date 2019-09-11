using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSample
{
    class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToUpper();
        }
    }
}
