using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace AnthemRankBot
{
    internal static class Global
    {
        internal static DiscordSocketClient client { get; set; }
        internal static ulong roleMessageIdToTrack { get; set; }
        internal static ulong platformMessageIdToTrack { get; set; }
    }
}
