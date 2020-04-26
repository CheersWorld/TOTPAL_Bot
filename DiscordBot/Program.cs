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
            try
            {
                MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            } catch
            {
                LOGGER.WriteMessageColor("Error on Startup", "red", true);
                Console.WriteLine();
                LOGGER.WriteMessageColor("  You most likely didn't supply a token", "red", false);
                Console.WriteLine();
                LOGGER.WriteMessageColor("  Cheak ReadMe for Instructions on how to deal with this", "red", false);
                Console.WriteLine();
                LOGGER.WriteMessageColor("  Application exiting in 7 seconds...", "red", false);
                System.Threading.Thread.Sleep(7000);
            }
        }
        

        static async Task MainAsync(string[] args)
        {
            //Makes a Logo Screen. In Green.
            for (int i = 0; i < 5; i++) { Console.WriteLine(""); }
            LOGGER.WriteMessageColor("▄▄▄█████▓ ▒█████  ▄▄▄█████▓ ██▓███   ▄▄▄       ██▓    \r\n▓  ██▒ ▓▒▒██▒  ██▒▓  ██▒ ▓▒▓██░  ██▒▒████▄    ▓██▒    \r\n▒ ▓██░ ▒░▒██░  ██▒▒ ▓██░ ▒░▓██░ ██▓▒▒██  ▀█▄  ▒██░    \r\n░ ▓██▓ ░ ▒██   ██░░ ▓██▓ ░ ▒██▄█▓▒ ▒░██▄▄▄▄██ ▒██░    \r\n  ▒██▒ ░ ░ ████▓▒░  ▒██▒ ░ ▒██▒ ░  ░ ▓█   ▓██▒░██████▒\r\n  ▒ ░░   ░ ▒░▒░▒░   ▒ ░░   ▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ▒░▓  ░\r\n    ░      ░ ▒ ▒░     ░    ░▒ ░       ▒   ▒▒ ░░ ░ ▒  ░\r\n  ░      ░ ░ ░ ▒    ░      ░░         ░   ▒     ░ ░   \r\n             ░ ░                          ░  ░    ░  ░", "green", false);
            for(int i = 0; i < 5; i++) { Console.WriteLine(""); }
            Console.ForegroundColor = ConsoleColor.White;
            //Reigsters the bot with the Discord API
            DISCORD_CLIENT = new DiscordClient(new DiscordConfiguration
            {
                //Your Token Here!
                Token = "",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Warning

                });
            LOGGER.WriteMessageColor("Client generated", "green", true);
            //Simple Ping Method, if you want one
            /*DISCORD_CLIENT.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };*/
            COMMANDS = DISCORD_CLIENT.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });
            //Registering Comments, connectingn to the API
            COMMANDS.RegisterCommands<CommandsManager>();
            LOGGER.WriteMessageColor("Commands registered", "green", true);
            await DISCORD_CLIENT.ConnectAsync();
            LOGGER.WriteMessageColor("Connected", "green", true);
            await Task.Delay(-1);
        }

    }
}
