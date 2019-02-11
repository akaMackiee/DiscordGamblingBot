using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBotCore.Discord.Entities;

namespace DiscordBotCore.Discord.Services
{
    public class CommandHandler
    {
        public CommandHandler(IServiceProvider services, DiscordSocketClient client, CommandService service, GamblingBotConfig botConfig)
        {
            _service = service;
            _client = client;
            _services = services;
            _botConfig = botConfig;
        }

        DiscordSocketClient _client;
        CommandService _service;
        IServiceProvider _services;
        GamblingBotConfig _botConfig;

        public async Task InitializeAsync()
        {
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix(_botConfig.Prefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
