using Discord.WebSocket;
using Discord;
using System;

namespace DiscordBotCore.Discord
{
    public static class SocketConfig
    {
        public static DiscordSocketConfig GetDefault()
        {
            return new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            };
        }

        public static DiscordSocketConfig GetNew()
        {
            return new DiscordSocketConfig();
        }
    }
}
