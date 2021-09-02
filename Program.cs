using DiscordBot_Dragon.bot;
using System;

namespace DiscordBot_Dragon
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigSettings("","%");

            var bot = new Bot();
            Console.WriteLine("Hello World!");
        }
    }
}
