using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrazilBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;

            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterZoxabelsCommand();
            RegisterPerssonCommand();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("", TokenType.Bot);
            });
        }

        private void RegisterZoxabelsCommand()
        {
            commands.CreateCommand("zoxabels")
                        .Do(async (e) =>
                            {
                                await e.Channel.SendMessage("I am shit and can only win with cancer strat");
                            });
        }
        
        private void RegisterTobakaZCommand()
        {
            commands.CreateCommand("tobakaz")
                        .Do(async (e) =>
                            {
                                await e.Channel.SendMessage("TobakaZ is the pink fluffy unicorn, standing in your backyard and eating all of your fabulous flowers");
                            });
        }

        private void RegisterPerssonCommand()
        {
            commands.CreateCommand("Persson")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I have the biggest dick");
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
