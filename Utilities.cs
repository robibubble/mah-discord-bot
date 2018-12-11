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

        private static Dictionary<string,string> alerts;

        static Utilities()
        {
            string json = File.ReadAllText("SystemLang\\alerts.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            alerts = data;
        }

        public static string GetAlert(string key)
        {
            if (key != "")
            {
                return alerts[key];
            }
            else
            {
                return "";
            }
        }
    }
}
