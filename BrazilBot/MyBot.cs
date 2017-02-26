using Discord;
using Discord.Commands;

using System;
using System.Linq;


namespace BrazilBot
{
    class MyBot
    {
        DiscordClient _client;
        CommandService commands;

        private const string _TOKEN = "InsertTokenHere";

        public MyBot()
        {
            _client = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;

            });

            _client.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = _client.GetService<CommandService>();

            registerCommands();

            _client.UserJoined += async (s, e) => {
                // Check to make sure that the user is not a bot
                if (!e.User.IsBot)
                    // Say hola to the user that joined!
                    await e.Server.FindChannels("bottest").FirstOrDefault().SendMessage($"Hola {e.User.NicknameMention}!");
            };

            _client.UserUpdated += async (s, e) =>
            {
                TimeSpan timeElapsed = DateTime.Now - (DateTime)e.After.LastOnlineAt; //Calculate how long it has been since user was last online
                int minutes = Convert.ToInt32(timeElapsed.TotalMinutes); //Convert to minutes
                if (e.After.Status.Equals(UserStatus.Online) && (e.After.CurrentGame == null || e.Before.CurrentGame == null) && minutes > 10) //User has come online, did not enter/exit game and hasn't been online for more than 10 minutes.
                {
                    await e.Server.FindChannels("bottest").FirstOrDefault().SendMessage($"Hola {e.After.NicknameMention}!");
                }
            };

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(_TOKEN, TokenType.Bot);
            });

            
        }

        private void registerCommands()
        {
            commands.CreateCommand("zoxabels")
                        .Do(async (e) =>
                        {
                            await e.Channel.SendMessage("I am shit and can only win with cancer strat.");
                        });
            commands.CreateCommand("tobakaz")
                        .Do(async (e) =>
                        {
                            await e.Channel.SendMessage("TobakaZ is the pink fluffy unicorn, standing in your backyard and eating all of your fabulous flowers. Da.");
                        });
            commands.CreateCommand("Persson")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I am delusional and think I can beat push strat. I do however have the biggest dick.");
                });
            commands.CreateCommand("#")
                .Do(async (e) =>
                {
                    if (e.User.Name.Equals("`HashTag`"))
                    {
                        await e.Channel.SendMessage("#Sweet!");
                    }else
                    {
                        await e.Channel.SendMessage($"#WhatAPlayer {e.User.NicknameMention}!");
                    }
                    
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
