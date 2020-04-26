using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus;
using System.Threading.Tasks;

namespace DiscordBot
{
    class CommandsManager
    {
        ConsoleLogger LOGGER = new ConsoleLogger();
        ItemsSingleton UsedItemsSingleton = ItemsSingleton.Instance;
        bool UI = false;

        [Command("SetMyArticle"), Aliases("setmyarticle", "setMyArticle", "SetmyArticle", "SetMyarticle"), Description("Fügt einen Artikel hinzu. Überschreibt den momentan vorhandenen Artikel von dir. ")]
        public async Task AddArticle(CommandContext ctx, params string[] Message)
        {
            string tempMsg = "";
            foreach(string tempString in Message) //Necessary to allow for spaces in article name
            {
                tempMsg = tempMsg + tempString + " ";
            }
            UsedItemsSingleton.SetArticle(ctx.User.ToString(), tempMsg);
            UsedItemsSingleton.MakeUI();
            LOGGER.WriteMessageColor("Article registered for " + GetUserString(ctx), "green", true);
            await ctx.RespondAsync("Dein Artikel ist: " + tempMsg);
        }
        //Returns article of user
        [Command("GetMyArticle"),Description("Zeigt dir deinen Artikel ah")]
        public async Task GetArticle(CommandContext ctx)
        {
            LOGGER.WriteMessageColor("Returned article for " + GetUserString(ctx), "green", true);
            await ctx.RespondAsync(UsedItemsSingleton.GetArticle(ctx.User.ToString()));
        }

        /*
         * Returns a random Article in the entered Articles. Displays a yellow warning message, just to make sure you can see that this happened.
         * We need an array for this, so we populate it. We can get the Array at a random index, not the Dictionary tho, since it works as a key/value pair
         */
        [Command("GetRandomArticle"),Aliases("getrandomarticle", "GetrandomArticle", "getRandomArticle", "GetRandomarticle"),Description("Gibt einen zufälligen Artikel aus")]
        public async Task RespondArticle(CommandContext ctx)
        {
            String[] _usedArray = new string[UsedItemsSingleton.GetCount()]; //Temporary Array
            int i = 0;
            foreach (string Article in UsedItemsSingleton.GetDictionary().Values) //Populate
            {
                _usedArray[i] = Article;
                i++;
            }
            LOGGER.WriteMessageColor("Returned random Article for " + GetUserString(ctx), "yellow", true);
            await ctx.RespondAsync("Artikel ist: " + _usedArray[new Random().Next(0, UsedItemsSingleton.GetDictionary().Count())]); //Get Random Article
        }
        //Everybody needs help sometimes. Just a long line of text.
        /*[Command("helpme")]
        public async Task Help(CommandContext ctx)
        {
            await ctx.RespondAsync("Um einen Artikel hinzuzufügen, schick eine Nachricht mit !SetMyArticle gefolgt von deinem Artikel. \r\n Um deinen eingegeben Artikel zu sehen, schick eine Nachricht mit !GetMyArticle. Beide Kommandos funktionieren im Privat-Chat mit dem Bot. \r\n Aus den eingereichten Artikeln wird mit !GetRandomArticle ein Artikel ausgewählt. \r\n Wenn du das Spiel verlassen möchtest, !leave eingeben. !source verlinkt dich zum Quellcode.");
        }*/
        //Allows a User to leave the game.
        [Command("leave"),Description("Damit verlässt du das Spiel")]
        public async Task Leave(CommandContext ctx)
        {
            UsedItemsSingleton.RemoveUser(ctx.User.ToString());
            LOGGER.WriteMessageColor("User left: " + GetUserString(ctx), "green", true);
            UsedItemsSingleton.MakeUI();
            await ctx.RespondAsync(ctx.User.Mention +  " hat das Spiel verlassen.");
        }
        //Useful to Display a username in the log. Useless otherwise.
        public string GetUserString(CommandContext ctx)
        {
            return ctx.User.ToString().Split(' ')[2];
        }

        //Linking to the Source Code. 
        [Command("source"),Description("Link zum Source-Code")]
        public async Task Source(CommandContext ctx)
        {
            await ctx.RespondAsync("Der Source code ist unter https://github.com/CheersWorld/TOTPAL_Bot zu finden.");
        }
        //Better than a ping command. 
        [Command("god")]
        public async Task God(CommandContext ctx)
        {
            await ctx.RespondAsync("There is no god, only death and despair.");
        }
        //Everybody needs a splash screen
        [Command("logo")]
        public async Task Logo(CommandContext ctx)
        {
            await ctx.RespondAsync("```▄▄▄█████▓ ▒█████  ▄▄▄█████▓ ██▓███   ▄▄▄       ██▓    \r\n▓  ██▒ ▓▒▒██▒  ██▒▓  ██▒ ▓▒▓██░  ██▒▒████▄    ▓██▒    \r\n▒ ▓██░ ▒░▒██░  ██▒▒ ▓██░ ▒░▓██░ ██▓▒▒██  ▀█▄  ▒██░    \r\n░ ▓██▓ ░ ▒██   ██░░ ▓██▓ ░ ▒██▄█▓▒ ▒░██▄▄▄▄██ ▒██░    \r\n  ▒██▒ ░ ░ ████▓▒░  ▒██▒ ░ ▒██▒ ░  ░ ▓█   ▓██▒░██████▒\r\n  ▒ ░░   ░ ▒░▒░▒░   ▒ ░░   ▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ▒░▓  ░\r\n    ░      ░ ▒ ▒░     ░    ░▒ ░       ▒   ▒▒ ░░ ░ ▒  ░\r\n  ░      ░ ░ ░ ▒    ░      ░░         ░   ▒     ░ ░   \r\n             ░ ░                          ░  ░    ░  ░```");
        }
        //Allows UI-Toggle. This is great if you don't want to get spoilered. UI off by default.
        [Command("ShowUI"),Description("Toggles Console UI")] [Hidden]
        public async Task ShowUI(CommandContext ctx)
        {
            UI = !UI;
            UsedItemsSingleton.ToggleUI();
            UsedItemsSingleton.MakeUI();
            LOGGER.WriteMessageColor("UI Toggled by " + GetUserString(ctx), "yellow", true);
            await ctx.RespondAsync("Show UI ist jetzt: ``" + UI.ToString() + "``");
        }
        [Command("ResetUI"), Description("Resets Console UI")] [Hidden]
        public async Task ResetUI(CommandContext ctx)
        {
            Console.Clear();
            for (int i = 0; i < 5; i++) { Console.WriteLine(""); }
            LOGGER.WriteMessageColor("▄▄▄█████▓ ▒█████  ▄▄▄█████▓ ██▓███   ▄▄▄       ██▓    \r\n▓  ██▒ ▓▒▒██▒  ██▒▓  ██▒ ▓▒▓██░  ██▒▒████▄    ▓██▒    \r\n▒ ▓██░ ▒░▒██░  ██▒▒ ▓██░ ▒░▓██░ ██▓▒▒██  ▀█▄  ▒██░    \r\n░ ▓██▓ ░ ▒██   ██░░ ▓██▓ ░ ▒██▄█▓▒ ▒░██▄▄▄▄██ ▒██░    \r\n  ▒██▒ ░ ░ ████▓▒░  ▒██▒ ░ ▒██▒ ░  ░ ▓█   ▓██▒░██████▒\r\n  ▒ ░░   ░ ▒░▒░▒░   ▒ ░░   ▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ▒░▓  ░\r\n    ░      ░ ▒ ▒░     ░    ░▒ ░       ▒   ▒▒ ░░ ░ ▒  ░\r\n  ░      ░ ░ ░ ▒    ░      ░░         ░   ▒     ░ ░   \r\n             ░ ░                          ░  ░    ░  ░", "green", false);
            for (int i = 0; i < 5; i++) { Console.WriteLine(""); }
            foreach (string user in UsedItemsSingleton.GetDictionary().Keys) {
                LOGGER.WriteMessageColor("Article registered for: " + user, "green", true);
            }
            UsedItemsSingleton.MakeUI();
            await ctx.RespondAsync("UI wurde resetted.");
        }
    }
}
