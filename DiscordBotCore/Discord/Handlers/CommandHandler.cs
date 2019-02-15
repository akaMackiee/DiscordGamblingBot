using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using DiscordBotCore.Discord.Entities;
using Discord.Commands;
using System.Reflection;
using System;

namespace DiscordBotCore.Discord.Handlers
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        DiscordLogger _logger;
        CommandService _service;
        GamblingBotConfig _config;

        public CommandHandler(DiscordSocketClient client, DiscordLogger logger, CommandService service, GamblingBotConfig config)
        {
            _client = client;
            _logger = logger;
            _service = service;
            _config = config;
        }

        public async Task InitializeAsync()
        {
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            _client.MessageReceived += HandleCommandAsync;
        }

        internal async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;

            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix(_config.Prefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos, null);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
