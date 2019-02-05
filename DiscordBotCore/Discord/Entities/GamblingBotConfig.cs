using Discord.WebSocket;

namespace DiscordBotCore.Discord.Entities
{
    public class GamblingBotConfig
    {
        public string Token { get; set; }
        public DiscordSocketConfig SocketConfig { get; set; }
    }
}
