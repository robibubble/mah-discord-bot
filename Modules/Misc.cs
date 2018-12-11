using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace mah_discord_bot.Modules
{

    public class Misc : ModuleBase<SocketCommandContext>
    {
      
        [Command("SayImportant")]
        public async Task SayImportant([Remainder]string message)
        {
            var embed = new EmbedBuilder();

            embed.WithTitle(Context.User.Username + "Has Something Important to say...");
            embed.WithDescription(message);
            embed.WithColor(new Color(Color.Red.RawValue));

            await Context.Channel.SendMessageAsync("", false, embed);

        }
    }
}
