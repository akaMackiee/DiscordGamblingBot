using Discord;
using System.Threading.Tasks;
using System;

namespace DiscordBotCore.Discord
{
    public class DiscordLogger
    {
        ILogger _logger;

        public DiscordLogger(ILogger logger)
        {
            _logger = logger;
        }

        public Task Log(LogMessage logMsg)
        {
            _logger.Log(logMsg.Message);
            Console.WriteLine(logMsg);
            return Task.CompletedTask;
        }
    }
}
