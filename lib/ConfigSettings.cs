using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_Dragon.lib
{
    public class ConfigSettings
    {
        public string Token { get; internal set; }
        public string Prefix { get; internal set; }
        public bool AutoReconnect { get; internal set; }
        public bool CommandsAreCaseSensitive { get; internal set; }
        public bool DmHelp { get; internal set; }
        public bool EnableMentionPrefix { get; internal set; }

        public ConfigSettings() { }
        public ConfigSettings(
            string token,
            string prefix,
            bool autoReconnect,
            bool commandsAreCaseSensitive,
            bool dmHelp,
            bool enableMentionPrefix
            )
        {
            Token = token;
            Prefix = prefix;
            AutoReconnect = autoReconnect;
            CommandsAreCaseSensitive = commandsAreCaseSensitive;
            DmHelp = dmHelp;
            EnableMentionPrefix = enableMentionPrefix;
        }

        public void WriteToConfigFile()
        {

        }

        public void ReadFromConfigFile()
        {

        }
    }
}
