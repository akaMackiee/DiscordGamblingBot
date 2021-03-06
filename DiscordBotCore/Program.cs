﻿using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;
using System.Threading.Tasks;
using DiscordBotCore.Discord.Handlers;

namespace DiscordBotCore
{
    internal class Program
    {
        private static async Task Main()
        {
            Unity.RegisterTypes();

            var storage = Unity.Resolve<IDataStorage>();
            var botConfig = storage.RestoreObject<BotConfig>("Config/ConfigFile");
            var connection = Unity.Resolve<Connection>();
            var CommandHandler = Unity.Resolve<CommandHandler>();

            Console.WriteLine("Prefix: " + botConfig.cmdPrefix);
            await connection.ConnectAsync(new GamblingBotConfig
            {
                Token = botConfig.BotToken
            });
            await CommandHandler.InitializeAsync();
        }
    }
}
