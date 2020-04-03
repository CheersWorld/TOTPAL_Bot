using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class ConsoleLogger
    {
        private static object _MessageLock = new object();

        public void WriteMessageColor(string message, string color, bool UseDate)
        {

            if (UseDate) { message = DateTime.Now.ToString() + ": " + message; }
            lock (_MessageLock)
            {
                switch (color)
                {
                    case "blue": Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "green": Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default: Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        public void WriteMessage(string message, bool UseDate)
        {
            lock (_MessageLock)
            {
                if (UseDate) { message = DateTime.Now.ToString() + ": " + message; }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}
