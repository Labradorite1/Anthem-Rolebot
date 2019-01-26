using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnthemRankBot.Modules;

namespace AnthemRankBot.Modules
{
    class Roles
    {
        public static async Task AddRoleAndSendMessage(SocketGuildUser user, SocketRole role)
        {
            await user.AddRoleAsync(role);
        }

        public static async Task RemoveRoleAndSendMessage(SocketGuildUser user, SocketRole role)
        {
            await user.RemoveRoleAsync(role);
        }
    }
}
  
