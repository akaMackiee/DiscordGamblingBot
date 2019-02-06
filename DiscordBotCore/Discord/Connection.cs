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
        private readonly CommandHandler _command;

        public Connection(DiscordLogger logger, DiscordSocketClient client, CommandHandler command)
        {
            _logger = logger;
            _client = client;
            _command = command;
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
