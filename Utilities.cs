using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace mah_discord_bot
{
    class Utilities
    {

        static Utilities()
        {
            string json = File.ReadAllText("SystemLang\\alerts.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static string GetAlert(string key)
        {
            return key;
        }
    }
}
