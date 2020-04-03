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
        ItemsSingleton UsedItemsSingleton = ItemsSingleton.Instance;

        [Command("SetMyArticle")]
        public async Task AddArticle(CommandContext ctx, string Message)
        {
            UsedItemsSingleton.SetArticle(ctx.User.ToString(), Message);
            await ctx.RespondAsync("Dein Artikel ist: " + Message);
        }

        [Command("GetMyArticle")]
        public async Task GetArticle(CommandContext ctx)
        {
            await ctx.RespondAsync("Dein Artikel ist: " + UsedItemsSingleton.GetArticle(ctx.User.ToString()));
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
            Console.WriteLine("Returned random Article");
            await ctx.RespondAsync("Wort ist: " + _usedArray[new Random().Next(0, UsedItemsSingleton.GetDictionary().Count())]);
        }
        [Command("helpme")]
        public async Task Help(CommandContext ctx)
        {
            await ctx.RespondAsync("Die gute alte Hilfestellung. Um einen Artikel hinzuzufügen, schick eine Nachricht mit !SetMyArticle gefolgt von deinem Artikel. Um deinen eingegeben Artikel zu sehen, schick eine Nachricht mit !GetMyArticle. Beide Kommandos funktionieren im Privat-Chat. Aus den eingereichten Artikeln wird mit !GetRandomArticle ein Artikel ausgewählt.");
        }
    }
}
