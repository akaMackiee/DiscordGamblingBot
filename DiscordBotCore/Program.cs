using DiscordBotCore.Storage;
using System;
using System.Threading.Tasks;

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
