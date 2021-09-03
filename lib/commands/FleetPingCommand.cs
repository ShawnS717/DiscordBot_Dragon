using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_Dragon.lib.commands
{
    public class FleetPingCommand: BaseCommandModule
    {
        [Command("createping")]
        [Description("Creates a fleet ping for everyone with the provided information. information is entered space separated so if you need a space, use the underscore-> \"_\"")]
        [RequireRoles(RoleCheckMode.Any, "F.C.", "Admins"/*Admins is for testing purposes*/)]//TODO: set to whatever is the fc name
        public async Task CreatePing(
            CommandContext ctx,
            [Description("The name of the fleet")]
            string fleetName,
            [Description("Where the fleet should form")]
            string formUpOn,
            [Description("Name of the communication channel")]
            string commsName,
            [Description("What time the fleet is starting (in eve time, just the number)")]
            int time,
            [Description("Purpose of the fleet. ex:PvP, PvE, etc")]
            string fleetType,
            [Description("The kinds of ships involved")]
            params string[] ships)
        {
            string fc = ctx.Member.Nickname;

            var targetChannelName = "discord-bot-test";
            DiscordChannel targetChannel = ctx.Guild.Channels.Where(x => x.Value.Name == targetChannelName).FirstOrDefault().Value;

            var embed = new DiscordEmbedBuilder()
            {
                Title = "Fleet Ping",
                Description =
                $"**Fleet Name**: {fleetName}\n" +
                $"**Form Up**: {formUpOn}\n" +
                $"**Comm's**: {commsName}\n" +
                $"**Time**: {time} Eve time\n" +
                $"**Fleet Type**: {fleetType}\n" +
                $"**Ships**: " + string.Join(" | ", ships),
                Color = DiscordColor.HotPink
            };
            await targetChannel.SendMessageAsync("@everyone\n", embed).ConfigureAwait(false);
        }
    }
}
