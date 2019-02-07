using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Discord.Services;

namespace DiscordBotCore.Discord
{
    public class Connection
    {
        DiscordSocketClient _client;
        DiscordLogger _logger;
        CommandHandler _handler;

        public Connection(DiscordSocketClient client, DiscordLogger logger)
        {
            _client = client;
            _logger = logger;
        }

        internal async Task ConnectAsync(GamblingBotConfig config)
        {
            _client.Log += _logger.Log;

            await _client.LoginAsync(TokenType.Bot, config.Token);
            Global.Client = _client;
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}
