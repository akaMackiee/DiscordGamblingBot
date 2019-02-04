using Discord.WebSocket;
using System;
using System.Collections.Generic;

namespace DiscordBotCore.Discord.Entities
{
    public class GamblingBotConfig
    {
        public string Token { get; set; }
        public DiscordSocketConfig SocketConfig { get; set; }
    }
}
