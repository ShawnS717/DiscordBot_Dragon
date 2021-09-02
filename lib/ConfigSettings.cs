using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_Dragon.lib
{
    public struct ConfigSettings
    {
        public string Token { get; init; }
        public string Prefix { get; init; }

        public ConfigSettings(string token, string prefix)
        {
            Token = token;
            Prefix = prefix;
        }
    }
}
