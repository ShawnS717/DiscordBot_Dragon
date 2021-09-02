using DiscordBot_Dragon.lib;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_Dragon.bot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public ConfigSettings Config { get; private set; }

        /// <summary>
        /// Makes a new discord bot object from the DsharpPlus library
        /// </summary>
        /// <param name="config">A Config struct object</param>
        public Bot(ConfigSettings config)
        {
            Config = config;
        }

        public async Task RunAsync()
        {
            var discordConfig = new DiscordConfiguration()
            {

            };
        }
    }
}
