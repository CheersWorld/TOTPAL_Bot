using System;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace DiscordBot
{
    class Program
    {
        static DiscordClient DISCORD_CLIENT;
        static CommandsNextModule COMMANDS;
        static ConsoleLogger LOGGER = new ConsoleLogger();
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        

        static async Task MainAsync(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;
            DISCORD_CLIENT = new DiscordClient(new DiscordConfiguration
                {

                    Token = "Njk1NDA3NjE3MTA2NzcxOTg5.XoZvow.Ub5K_I07NjuQYumyxCZuPdLfsZ8",
                    TokenType = TokenType.Bot

                });
            LOGGER.WriteMessageColor("Registered Bot", "green", true);
            /*DISCORD_CLIENT.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };*/
            COMMANDS = DISCORD_CLIENT.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });

            COMMANDS.RegisterCommands<CommandsManager>();
            LOGGER.WriteMessageColor("Commands registered", "green", true);
            await DISCORD_CLIENT.ConnectAsync();
            await Task.Delay(-1);
        }

    }
}
