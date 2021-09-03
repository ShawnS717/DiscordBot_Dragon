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
    public partial class FleetPingCommand: BaseCommandModule
    {
        [Command("createping")]
        [Description("Will create a discord ping for everyone with the given information. note: ALL ARGUMENTS ARE SPACE SEPERATED. If the argument name has a space in it, just substitute with an underscore")]
        [RequireRoles(RoleCheckMode.Any, "F.C.", "Admins"/*Admins is for testing purposes*/)]//TODO: set to whatever is the fc name
        public async Task CreatePing(
            CommandContext ctx,
            [Description("The name of the fleet")]
            string fleetName,
            [Description("Where the fleet should form")]
            string formUpOn,
            [Description("Name of the communication channel (or where participants can find it)")]
            string commsName,
            [Description("What time the fleet is starting")]
            string time,
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
                $"Fleet Name: {0}\n" +
                $"Form Up: {1}\n" +
                $"Comm's: {2}\n" +
                $"Time: {3}\n" +
                $"Fleet Type: {4}\n" +
                $"Ships: \n" + string.Join(" | ", ships)
            };
            await targetChannel.SendMessageAsync("@everyone\n", embed).ConfigureAwait(false);
        }
    }
}
