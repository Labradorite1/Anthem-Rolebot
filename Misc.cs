using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using NReco.ImageGenerator;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace BeepBoopBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("Rank")]
        public async Task Rank()
        {
            string rank1EmoteId = Utilities.GetFormattedAlert("Rank1_EmoteID");
            string rank2EmoteId = Utilities.GetFormattedAlert("Rank2_EmoteID");
            string rank3EmoteId = Utilities.GetFormattedAlert("Rank3_EmoteID");
            string rank4EmoteId = Utilities.GetFormattedAlert("Rank4_EmoteID");

            var embed = new EmbedBuilder();
            embed.WithTitle("Class Role Assignment");
            embed.WithDescription( $"<{rank1EmoteId}> Colossus \n <{rank2EmoteId}> Interceptor \n <{rank3EmoteId}> Ranger \n <{rank4EmoteId}> Storm");
            embed.WithColor(new Color(0, 0, 255));
            var sent = await Context.Channel.SendMessageAsync("", embed: embed);
            RestUserMessage msg = sent;
            Global.roleMessageIdToTrack = msg.Id;

            var Emoji1= new Emoji(rank1EmoteId);
            var Emoji2 = new Emoji(rank2EmoteId);
            var Emoji3 = new Emoji(rank3EmoteId);
            var Emoji4 = new Emoji(rank4EmoteId);

            await sent.AddReactionAsync(Emoji1);
            await sent.AddReactionAsync(Emoji2);
            await sent.AddReactionAsync(Emoji3);
            await sent.AddReactionAsync(Emoji4);
        }

        [Command("Platform")]
        public async Task Platform()
        {
            string platform1EmoteId = Utilities.GetFormattedAlert("Platform1_EmoteID");
            string platform2EmoteId = Utilities.GetFormattedAlert("Platform2_EmoteID");
            string platform3EmoteId = Utilities.GetFormattedAlert("Platform3_EmoteID");

            var embed = new EmbedBuilder();
            embed.WithTitle("Platform Role Assignment");
            embed.WithDescription($"<{platform1EmoteId}> PC \n <{platform2EmoteId}> Playstation \n <{platform3EmoteId}> Xbox");
            embed.WithColor(new Color(0, 0, 255));  
            var sent = await Context.Channel.SendMessageAsync("", embed: embed);

            RestUserMessage msg = sent;
            Global.platformMessageIdToTrack = msg.Id;

            var Emoji1 = new Emoji(platform1EmoteId);
            var Emoji2 = new Emoji(platform2EmoteId);
            var Emoji3 = new Emoji(platform3EmoteId);

            await sent.AddReactionAsync(Emoji1);
            await sent.AddReactionAsync(Emoji2);
            await sent.AddReactionAsync(Emoji3);
        }
 

        /*
        public async Task AddRole1()
        {
            var user = Context.User;
            var roleObject = Context.Guild.Roles.FirstOrDefault(r => r.Name == "Role1");
            await (user as SocketGuildUser).AddRoleAsync(roleObject);
            await Context.Channel.SendMessageAsync("hello");
        }
        */
    }
}
