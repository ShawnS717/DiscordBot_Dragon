using DiscordBot_Dragon.lib;
using System;

namespace DiscordBot_Dragon
{
    class Program
    {
        static void Main(string[] args)
        {
            //temporary config settings
            var config = new ConfigSettings(
                token: "NjkzMjQzMTA3NjY3MzQ1NDYw.Xn6O9A.0pXsNfd4ETGbwTxwEtjI_G-SVTA",
                prefix: "%",
                autoReconnect: true,
                commandsAreCaseSensitive: false,
                dmHelp: false,
                enableMentionPrefix: true);

            var bot = new Bot(config);
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
