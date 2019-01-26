using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using AnthemRankBot.Modules;
using Discord.Rest;

namespace AnthemRankBot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();



        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            _client.ReactionAdded += OnReactionAdded;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            Global.client = _client;
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        public static async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == Global.roleMessageIdToTrack && reaction.UserId != 536945570535702539)
            {
                string rank1Emote = Utilities.GetFormattedAlert("Rank1_Emote");
                string rank2Emote = Utilities.GetFormattedAlert("Rank2_Emote");
                string rank3Emote = Utilities.GetFormattedAlert("Rank3_Emote");
                string rank4Emote = Utilities.GetFormattedAlert("Rank4_Emote");

                string rank1Name = Utilities.GetFormattedAlert("Rank1_Name");
                string rank2Name = Utilities.GetFormattedAlert("Rank2_Name");
                string rank3Name = Utilities.GetFormattedAlert("Rank3_Name");
                string rank4Name = Utilities.GetFormattedAlert("Rank4_Name");

                if (reaction.Emote.Name == rank1Emote) //adds red role
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    foreach (var currentRole in user.Roles)
                    {
                        if (currentRole.Name == rank2Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank3Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank4Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }
                    }

                    var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == rank1Name); //gets the role corresponding to the emoji

                    await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                    var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                    await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                }

                if (reaction.Emote.Name == rank2Emote) //adds orange role
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    foreach (var currentRole in user.Roles)
                    {
                        if (currentRole.Name == rank1Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank3Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank4Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }
                    }

                    var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == rank2Name); //gets the role corresponding to the emoji

                    await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                    var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                    await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                }

                if (reaction.Emote.Name == rank3Emote) //adds yellow role 
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    foreach (var currentRole in user.Roles)
                    {
                        if (currentRole.Name == rank1Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank2Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank4Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }
                    }

                    var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == rank3Name); //gets the role corresponding to the emoji

                    await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                    var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                    await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                }

                if (reaction.Emote.Name == rank4Emote) //adds green role 
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    foreach (var currentRole in user.Roles)
                    {
                        if (currentRole.Name == rank1Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank2Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }

                        if (currentRole.Name == rank3Name)
                        {
                            await Roles.RemoveRoleAndSendMessage(user, currentRole); //calls role removal and send message with parameters 
                        }
                    }

                    var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == rank4Name); //gets the role corresponding to the emoji

                    await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                    var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                    await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                }
            }
            if (reaction.MessageId == Global.platformMessageIdToTrack && reaction.UserId != 536945570535702539)
            {
                string platform1Emote = Utilities.GetFormattedAlert("Platform1_Emote");
                string platform2Emote = Utilities.GetFormattedAlert("Platform2_Emote");
                string platform3Emote = Utilities.GetFormattedAlert("Platform3_Emote");

                string platform1Name = Utilities.GetFormattedAlert("Platform1_Name");
                string platform2Name = Utilities.GetFormattedAlert("Platform2_Name");
                string platform3Name = Utilities.GetFormattedAlert("Platform3_Name");

                if (reaction.Emote.Name == platform1Emote) //adds red role
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    var platformRole = user.Guild.Roles.FirstOrDefault(r => r.Name == platform1Name);

                    if (user.Roles.Contains(platformRole))
                    {
                        await Roles.RemoveRoleAndSendMessage(user, platformRole); //calls role removal and send message with parameters 
                        var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                        await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                    }
                    if (!user.Roles.Contains(platformRole))
                    {
                        var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == platform1Name); //gets the role corresponding to the emoji

                        await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                        var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                        await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                    }
                }
                if (reaction.Emote.Name == platform2Emote) //adds red role
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    var platformRole = user.Guild.Roles.FirstOrDefault(r => r.Name == platform2Name);

                    if (user.Roles.Contains(platformRole))
                    {
                        await Roles.RemoveRoleAndSendMessage(user, platformRole); //calls role removal and send message with parameters 
                        var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                        await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                    }
                    if (!user.Roles.Contains(platformRole))
                    {
                        var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == platform2Name); //gets the role corresponding to the emoji

                        await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                        var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                        await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                    }
                }
                if (reaction.Emote.Name == platform3Emote) //adds red role
                {
                    var user = reaction.User.Value as SocketGuildUser;
                    var textChannel = channel as SocketTextChannel;

                    var platformRole = user.Guild.Roles.FirstOrDefault(r => r.Name == platform3Name);

                    if (user.Roles.Contains(platformRole))
                    {
                        await Roles.RemoveRoleAndSendMessage(user, platformRole); //calls role removal and send message with parameters 
                        var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                        await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                    }
                    if (!user.Roles.Contains(platformRole))
                    {
                        var newRole = user.Guild.Roles.FirstOrDefault(r => r.Name == platform3Name); //gets the role corresponding to the emoji

                        await Roles.AddRoleAndSendMessage(user, newRole); //cals role and send message with parameters 

                        var reactionMsg = await textChannel.GetMessageAsync(reaction.MessageId) as IUserMessage; // gets the message on which the reaction has to be removed
                        await reactionMsg.RemoveReactionAsync(reaction.Emote, user); //removes the reaction 
                    }
                }
            }
        }


        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
