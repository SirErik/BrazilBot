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

        private const string _TOKEN = "";

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

            _client.UserJoined += async (s, e) =>
            {
                // Check to make sure that the user is not a bot
                if (!e.User.IsBot)
                    // Say hola to the user that joined!
                    await e.Server.FindChannels("perssons_bil").FirstOrDefault().SendMessage($"Hola {e.User.NicknameMention}! Welcome to The Black WidowZ discord. Post all links in #links and enjoy your stay.");
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
                    if (e.User.Name.Equals("`Hash_Tag`"))
                    {
                        await e.Channel.SendMessage("#Sweet!");
                    }
                    else
                    {
                        await e.Channel.SendMessage($"#WhatAPlayer {e.User.NicknameMention}!");
                    }

                });
            commands.CreateCommand("seen")
                .Description("Returns the date the requested user was last seen")
                .Parameter("requestedUser", ParameterType.Required)
                .Do(async e =>
                {
                    User requestedUser = e.Server.FindUsers(e.GetArg("requestedUser")).FirstOrDefault();
                    if (requestedUser != null)
                    {
                        await e.Channel.SendMessage($"{requestedUser.Name} was last seen on {requestedUser.LastActivityAt}.");
                    }
                });
            commands.CreateCommand("ShitBot")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Dont blame me, blame the ones writing the code.");
                });
            commands.CreateCommand("bouncysheep")
           .Do(async (e) =>
           {
               await e.Channel.SendMessage("The most bounciest bouncer of the bouncy sheep.");
           });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
