using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace mah_discord_bot
{
    class Program
    {

        DiscordSocketClient _client;
        CommandHandler _cmdHandler;

        //Skip Main, Starts Async Instead
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config.bot.token == null || Config.bot.token == "")
            {
                return;
            }

            _client = new DiscordSocketClient(new DiscordSocketConfig{
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();

            _cmdHandler = new CommandHandler();
            await _cmdHandler.AsyncInit(_client);
            await Task.Delay(-1);

        }

        private async Task Log(LogMessage message)
        {
            Console.WriteLine(message.Message);
        }
    }
}
