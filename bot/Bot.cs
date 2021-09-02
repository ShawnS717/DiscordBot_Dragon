using DiscordBot_Dragon.lib;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
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
                TokenType = TokenType.Bot,
                Token = Config.Token,
                AutoReconnect = Config.AutoReconnect,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Error
            };
            var commandsConfig = new CommandsNextConfiguration()
            {
                CaseSensitive = Config.CommandsAreCaseSensitive,
                DmHelp = Config.DmHelp,
                EnableMentionPrefix = Config.EnableMentionPrefix,
                EnableDms = false,
                StringPrefixes = new string[] { Config.Prefix }
            };

            Client = new DiscordClient(discordConfig);

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                //defaults are fine
            });

            Commands = Client.UseCommandsNext(commandsConfig);
            //when commands are created register them
            //Commands.RegisterCommands<ClassName>();

            Client.Ready += OnReady;

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnReady(DiscordClient sender, ReadyEventArgs e)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Bot is connected and running");
            Console.WriteLine("----------------------------");

            return Task.CompletedTask;
        }
    }
}
