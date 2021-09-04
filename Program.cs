using DiscordBot_Dragon.lib;
using System;
using System.IO;

namespace DiscordBot_Dragon
{
    class Program
    {
        private static void ConfigSetupFromUser(ConfigSettings config)
        {
            Console.WriteLine("What is the token for the bot you wish to use? Y/N");
            Console.WriteLine("This can be found at:");
            Console.WriteLine("https://discord.com/developers/applications -> click the bot you want to use -> click \"Bot\" on the left (under OAuth2) -> click \"copy\" under token");
            config.Token = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("What prefix do you want for commands?");
            config.Prefix = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Do you want commands to be case sensitive? Y/N");
            config.CommandsAreCaseSensitive = Console.ReadLine().ToLower() == "true" ? true : false;
            Console.Clear();

            Console.WriteLine("Can mentioning the bot be used to call commands? Y/N");
            config.EnableMentionPrefix = Console.ReadLine().ToLower() == "true" ? true : false;
            Console.Clear();

            Console.WriteLine("If someone uses the \"help\" command, should it be sent in a DM? Y/N");
            config.DmHelp = Console.ReadLine().ToLower() == "true" ? true : false;
            Console.Clear();

            Console.WriteLine("If the bot unexpectedly looses connection, do you want it to auto-reconnect? Y/N");
            config.AutoReconnect = Console.ReadLine().ToLower() == "n" ? false : true;
            Console.Clear();
        }
        static void Main(string[] args)
        {
            var configFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DiscordBot", "Config.txt");
            var config = new ConfigSettings(configFileLocation);

            //for testing
            Console.WriteLine(configFileLocation);

            //do they have a config file
            if (File.Exists(configFileLocation))
            {
                //if they do, ask the user if they want to use the current config or not
                bool redo = true;
                do
                {
                    Console.WriteLine("Would you like to use the current config? Y/N");
                    var response = Console.ReadLine();

                    if (response.ToLower() == "y")
                    {
                        config.UpdateFromConfigFile();
                        redo = !redo;
                    }
                    else if (response.ToLower() == "n")
                    {
                        Console.Clear();
                        ConfigSetupFromUser(config);
                        redo = !redo;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong character(s) used");
                    }
                } while (redo == true);

            }
            else
            {
                //if not, prompt and walk the user through config setup AND SAVE IT
                Console.Clear();
                Console.WriteLine("We're missing a config file so let's make that.");
                Console.WriteLine("just 6 questions and we'll be done.\n");

                ConfigSetupFromUser(config);
                config.SaveToConfigFile();
            }

            var bot = new Bot(config);
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
