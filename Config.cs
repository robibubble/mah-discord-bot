using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace mah_discord_bot
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";
        private const string path = configFolder + "\\" + configFile;

        public static BotConfig bot;

        static Config()
        {   
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            if(!File.Exists(path))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            else
            {
                string json = File.ReadAllText(path);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);

                if (bot.token == null)
                {
                    Console.WriteLine("Could not optain bot.token from {0}", path);
                }
                else if(bot.cmdPrefix == null)
                {
                    Console.WriteLine("Could not optain cmdPrefix from {0}", path);

                }
            }
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}
