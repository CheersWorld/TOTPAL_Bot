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

        public static ItemsSingleton Instance { get { return lazy.Value; } }
        int i = 0;
        Dictionary<string, string> UsedThings = new Dictionary<string, string>();
        private ItemsSingleton()
        {

        }
        public void SetArticle(string _key, string _value)
        {
            try
            {
                UsedThings.Add(_key.Split(' ')[2], _value);
                Console.Write("New Article added. " + _key.Split(' ')[2] + " " + _value + "\r\n");
            } catch
            {
                Console.Write("Article updated. " + _key.Split(' ')[2] + " " + _value + "\r\n");
                UsedThings[_key.Split(' ')[2]] = _value;
            }
        }
        public string GetArticle(string _key)
        {
            Console.Write("Article returned for. " + _key.Split(' ')[2]);
            return UsedThings[_key.Split(' ')[2]];
        }
        public int GetCount()
        {
            return UsedThings.Count();
        }
        public Dictionary<string, string> GetDictionary()
        {
            return UsedThings;
        }
    }
}
