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
                    await e.Server.FindChannels("bottest").FirstOrDefault().SendMessage($"Hola {e.User.Name}!");
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
                            await e.Channel.SendMessage("I am shit and can only win with cancer strat. I am still better than Erik though.");
                        });
            commands.CreateCommand("tobakaz")
                        .Do(async (e) =>
                        {
                            await e.Channel.SendMessage("TobakaZ is the pink fluffy unicorn, standing in your backyard and eating all of your fabulous flowers. Da.");
                        });
            commands.CreateCommand("Persson")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I am delusional and think I can beat push strat. Also, I have the smallest dick in the world.");
                });
            commands.CreateCommand("#")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("#Sweet!");
                });
        }
 
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
