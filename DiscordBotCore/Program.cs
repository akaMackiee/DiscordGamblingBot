using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;

namespace DiscordBotCore
{
    internal class Program
    {
        private static void Main()
        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello sugar");
        }
    }
}
