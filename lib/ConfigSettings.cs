using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_Dragon.lib
{
    public class ConfigSettings
    {
        public string FilePath { get; set; }
        public string Token { get; internal set; }
        public string Prefix { get; internal set; }
        public bool AutoReconnect { get; internal set; }
        public bool CommandsAreCaseSensitive { get; internal set; }
        public bool DmHelp { get; internal set; }
        public bool EnableMentionPrefix { get; internal set; }

        public ConfigSettings() { }
        public ConfigSettings(string filepath)
        {
            FilePath = filepath;
        }
        public ConfigSettings(string[] input)
        {
            Token = input[0];
            Prefix = input[1];
            AutoReconnect = input[2].ToLower() == "false" ? false : true;
            CommandsAreCaseSensitive = input[3].ToLower() == "true" ? true : false;
            DmHelp = input[4].ToLower() == "true" ? true : false;
            EnableMentionPrefix = input[5].ToLower() == "true" ? true : false;
        }

        public void SaveToConfigFile()
        {
            var content = new StringBuilder();
            content.AppendLine($"Token:{Token}");
            content.AppendLine($"Prefix:{Prefix}");
            content.AppendLine($"AutoReconnect:{AutoReconnect}");
            content.AppendLine($"CommandsAreCaseSensitive:{CommandsAreCaseSensitive}");
            content.AppendLine($"DmHelp:{DmHelp}");
            content.AppendLine($"EnableMentionPrefix:{EnableMentionPrefix}");

            File.WriteAllText(FilePath, content.ToString());
        }

        public void UpdateFromConfigFile()
        {
            var fileContent = File.ReadAllText(FilePath).Split("\n");
            var formatedContent = new Dictionary<string, string>();

            foreach(var item in fileContent)
            {
                var splitLine = item.Split(":");
                formatedContent.Add(splitLine[0], splitLine[1]);
            }

            Token = formatedContent["Token"];
            Prefix = formatedContent["Prefix"];
            AutoReconnect = formatedContent["AutoReconnect"].ToLower() == "true" ? true : false;
            CommandsAreCaseSensitive = formatedContent["CommandsAreCaseSensitive"].ToLower() == "true" ? true : false;
            DmHelp = formatedContent["DmHelp"].ToLower() == "true" ? true : false;
            EnableMentionPrefix = formatedContent["EnableMentionPrefix"].ToLower() == "true" ? true : false;
        }
    }
}
