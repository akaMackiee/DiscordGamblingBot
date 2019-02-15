using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBotCore.Discord.Entities;

namespace DiscordBotCore.Discord
{
    public class Connection
    {
        DiscordSocketClient _client;
        DiscordLogger _logger;

        public Connection(DiscordSocketClient client, DiscordLogger logger)
        {
            _client = client;
            _logger = logger;
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
