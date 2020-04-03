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

        [Command("SetMyArticle")]
        public async Task AddArticle(CommandContext ctx, params string[] Message)
        {
            string tempMsg = "";
            foreach(string tempString in Message)
            {
                tempMsg = tempMsg + tempString + " ";
            }
            UsedItemsSingleton.SetArticle(ctx.User.ToString(), tempMsg);
            await ctx.RespondAsync("Dein Artikel ist: " + tempMsg);
            UsedItemsSingleton.MakeUI();    
            LOGGER.WriteMessageColor("Article registered for " + GetUserString(ctx), "green", true);
        }

        [Command("GetMyArticle")]
        public async Task GetArticle(CommandContext ctx)
        {
            LOGGER.WriteMessageColor("Returned article for " + GetUserString(ctx), "green", true);
            await ctx.RespondAsync(UsedItemsSingleton.GetArticle(ctx.User.ToString()));
        }

        [Command("GetRandomArticle")]
        public async Task RespondArticle(CommandContext ctx)
        {
            String[] _usedArray = new string[UsedItemsSingleton.GetCount()];
            int i = 0;
            foreach (string Article in UsedItemsSingleton.GetDictionary().Values)
            {
                _usedArray[i] = Article;
                i++;
            }

            LOGGER.WriteMessageColor("Returned random Article for " + GetUserString(ctx), "yellow", true);
            await ctx.RespondAsync("Wort ist: " + _usedArray[new Random().Next(0, UsedItemsSingleton.GetDictionary().Count())]);
        }
        [Command("helpme")]
        public async Task Help(CommandContext ctx)
        {
            await ctx.RespondAsync("Die gute alte Hilfestellung. Um einen Artikel hinzuzufügen, schick eine Nachricht mit !SetMyArticle gefolgt von deinem Artikel. Um deinen eingegeben Artikel zu sehen, schick eine Nachricht mit !GetMyArticle. Beide Kommandos funktionieren im Privat-Chat. Aus den eingereichten Artikeln wird mit !GetRandomArticle ein Artikel ausgewählt.");
        }
        [Command("leave")]
        public async Task Leave(CommandContext ctx)
        {
            UsedItemsSingleton.RemoveUser(ctx.User.ToString());
            await ctx.RespondAsync(ctx.User.Mention +  " hat das Spiel verlassen.");
            LOGGER.WriteMessageColor("User left: " + GetUserString(ctx), "green", true);
            UsedItemsSingleton.MakeUI();
        }
        public string GetUserString(CommandContext ctx)
        {
            return ctx.User.ToString().Split(' ')[2];
        }
    }
}
