using DiscordBotCore.Discord;
using DiscordBotCore.Discord.Entities;
using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    internal class Program
    {
        private static async Task Main()

        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello sugar");

            var storage = Unity.Resolve<IDataStorage>();

            var connection = Unity.Resolve<Connection>();
            await connection.ConnectAsync(new GamblingBotConfig
            {
                Token = storage.RestoreObject<string>("Config/BotToken")
            });
        }
    }
}
