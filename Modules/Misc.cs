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

            embed.WithTitle(Context.User.Username + " Says...");
            embed.WithDescription(message);
            embed.WithColor(new Color(Color.DarkBlue.RawValue));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

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

            
            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("hello")]
        public async Task hello()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle(Utilities.GetFomrattedAlert("hello_&USERNAME", Context.User.Username));

            switch (Context.User.Username)
            {
                case "Roobix13":
                    embed.WithDescription("Daddy is here");
                    break;
                case "Adueee":
                    embed.WithDescription("Sah Dudes ");
                    break;
                case "Bhishma":
                    embed.WithDescription("Netflix anyway lol");
                    break;
                case "waldo":
                    embed.WithDescription(":RRRRRRRRRREEEEEEEEEEEEEEEEE:");
                    break;
                case "Nifas22":
                    embed.WithDescription("Fifa anyway lol");
                    break;
                default:
                    embed.WithDescription("Im big gaye");
                    break;
            }
            await Context.Channel.SendMessageAsync("", false, embed);
        }

    }
}
