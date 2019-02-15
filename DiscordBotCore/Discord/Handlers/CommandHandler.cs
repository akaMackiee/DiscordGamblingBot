using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using DiscordBotCore.Discord.Entities;

namespace DiscordBotCore.Discord.Handlers
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        DiscordLogger _logger;

        public CommandHandler(DiscordSocketClient client, DiscordLogger logger)
        {
            _client = client;
            _logger = logger;
        }

        internal async Task CommandHandlerAsync(GamblingBotConfig config)
        {

        }
    }
}
