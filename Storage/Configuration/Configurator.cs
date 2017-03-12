using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Storage.Configuration
{
    public static class Configurator
    {
        public static Dictionary<string, string> Config => JsonConvert.DeserializeObject<Dictionary<string, string>>(
            File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "../Storage/config.json")
        ));
    }
}