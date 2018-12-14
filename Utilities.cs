using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace mah_discord_bot
{   
    //Reads from alerts.json
    class Utilities
    {
                
        private static Dictionary<string,string> alerts;

        //File 
        static Utilities()
        {
            string json = File.ReadAllText("SystemLang\\alerts.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            alerts = data;
        }

        //Enter the key from alerts.json that you want to read
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

        public static string GetFomrattedAlert(string key, params object[] parameter)
        {
            if (key != "")
            {
                return String.Format(alerts[key], parameter);
            }
            else
            {
                return "";
            }
        }

        public static string GetFomrattedAlert(string key, object parameter)
        {
            return GetFomrattedAlert(key, new object[] { parameter });
        }
    }
}
