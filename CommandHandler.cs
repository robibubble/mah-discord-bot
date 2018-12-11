using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace mah_discord_bot
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task AsyncInit(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage socketMessage)
        {
            var message = socketMessage as SocketUserMessage;

            if (message == null)
            {
                return;
            }

            var context = new SocketCommandContext(_client, message);

            int argumentPosition = 0;

            //If message has prefix or is mentioned ( $ || json )
            if (message.HasStringPrefix(Config.bot.cmdPrefix, ref argumentPosition) || message.HasMentionPrefix(_client.CurrentUser, ref argumentPosition))
            {
                var result = await _service.ExecuteAsync(context, argumentPosition);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
