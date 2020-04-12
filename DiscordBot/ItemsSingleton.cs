using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public sealed class ItemsSingleton
    {
        private static readonly Lazy<ItemsSingleton>
            lazy =
            new Lazy<ItemsSingleton>
                (() => new ItemsSingleton());
        private static char SPLIT_CHAR = ' ';
        private static int SPLIT_INT = 2;
        private static ConsoleLogger LOGGER = new ConsoleLogger();
        public static ItemsSingleton Instance { get { return lazy.Value; } }
        Dictionary<string, string> UsedThings = new Dictionary<string, string>();
        bool showUI = false;
        private ItemsSingleton()
        {

        }
        public void SetArticle(string _key, string _value)
        {
            try
            {
                UsedThings.Add(_key.Split(SPLIT_CHAR)[2], _value);
            } catch
            {
                UsedThings[_key.Split(SPLIT_CHAR)[SPLIT_INT]] = _value;
            }
        }
        public string GetArticle(string _key)
        {
            try{ return "Dein Artikel ist " + UsedThings[_key.Split(SPLIT_CHAR)[SPLIT_INT]]; }
            catch
            {
                LOGGER.WriteMessageColor("No article found for " + _key.Split(SPLIT_CHAR)[SPLIT_INT], "yellow", true);
                return "Kein Artikel gefunden";
            }            
        }
        public int GetCount()
        {
            return UsedThings.Count();
        }
        public Dictionary<string, string> GetDictionary()
        {
            return UsedThings;
        }
        public void RemoveUser(string _key)
        {
            UsedThings.Remove(_key.Split(SPLIT_CHAR)[SPLIT_INT]);
        }
        public void ToggleUI()
        {
            showUI = !showUI;
        }
        //You could make another class for this method, would be neater. However, would need instancing of the singleton. Since this is just one method I'll do it here
        public void MakeUI()
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < (UsedThings.Count() + 2); i++)
            {
                Console.SetCursorPosition(width - 65, i);
                Console.Write("\b");
                if (showUI) { Console.Write("|"); } else { Console.Write(" "); }
                    for (int j = 0; j < 49; j++)
                    {
                        Console.SetCursorPosition(width - 64 + j, i);
                        Console.Write("\b");
                        Console.Write(" ");
                    }
            }
            int LineIndex = 1;
            foreach (string key in UsedThings.Keys)
            {
                int charPos = 0;
                foreach (char c in key)
                {
                    Console.SetCursorPosition(width - (60 - charPos), LineIndex);
                    Console.Write("\b");
                    if (showUI)
                    {
                        Console.Write(c);
                    }
                    else { Console.Write(" "); }
                    charPos++;
                }
                charPos = 0;
                foreach (char j in UsedThings[key])
                {
                    Console.SetCursorPosition(width - (30-charPos), LineIndex);
                    Console.Write("\b");
                    if (showUI)
                    {
                        Console.Write(j);
                    }
                    else { Console.Write(" "); }
                    charPos++;
                }
                LineIndex++;
            }
            Console.SetCursorPosition(currentLeft, currentTop);
        }
    }
}
