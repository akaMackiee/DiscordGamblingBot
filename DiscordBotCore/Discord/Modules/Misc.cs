using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBotCore.Discord.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]
        public async Task EchoMessage()
        {
            await Context.Channel.SendMessageAsync("Hello");
        }
    }
}
