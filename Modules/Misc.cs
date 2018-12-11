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
      
        [Command("say")]
        public async Task say([Remainder]string message)
        {
            var embed = new EmbedBuilder();

            if (message == "hi" && message == "hi guys")
            {
                embed.WithTitle(Context.User.Username + " Says Hi ");
                embed.WithThumbnailUrl("https://pbs.twimg.com/media/Bnnn6C8IEAA9rhs.jpg:large");
            }
            else
            {
                embed.WithTitle(Context.User.Username + " Says...");
                embed.WithDescription(message);
                embed.WithColor(new Color(Color.DarkBlue.RawValue));
            }

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("random")]
        public async Task random([Remainder]string message)
        {
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            Random randNr = new Random();
            string slection = options[randNr.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("Choise for " + Context.User.Username);
            embed.WithDescription(slection);
            embed.WithColor(new Color(Color.DarkGreen.RawValue));
            //embed.WithThumbnailUrl("https://pbs.twimg.com/media/Bnnn6C8IEAA9rhs.jpg:large");

            await Context.Channel.SendMessageAsync("", false, embed);

        }
    }
}
