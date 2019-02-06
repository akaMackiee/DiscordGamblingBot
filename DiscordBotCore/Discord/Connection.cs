using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Discord.Services;

namespace DiscordBotCore.Discord
{
    public class Connection
    {
        private readonly DiscordSocketClient _client;
        private readonly DiscordLogger _logger;
        private readonly CommandHandler _handler;

        public Connection(DiscordLogger logger, DiscordSocketClient client)
        {
            _logger = logger;
            _client = client;
        }

        internal async Task ConnectAsync(GamblingBotConfig config)
        {
            _client.Log += _logger.Log;

            await _client.LoginAsync(TokenType.Bot, config.Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}
