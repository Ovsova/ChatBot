﻿using System;
namespace ChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TwitchChatBot bot = new TwitchChatBot();
            bot.Connect();
            Console.ReadLine();
            bot.Disconnect();
        }
    }
}
