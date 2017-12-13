using System;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;
using TwitchLib.Models.API.v5.Users;

namespace ChatBot
{
    internal class TwitchChatBot
    {
        readonly ConnectionCredentials credentials = new ConnectionCredentials(TwitchInfo.BotUserName, TwitchInfo.BotToken);
        TwitchClient client;

        internal void Connect()
        {
            Console.WriteLine("Connecting");
            client = new TwitchClient(credentials, TwitchInfo.ChanalName, logging: false);

            client.OnLog += Client_OnLog;
            Console.WriteLine("1");
            client.OnConnectionError += Client_OnConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
            Console.WriteLine("2");
            client.Connect();
            Console.WriteLine("3");
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.StartsWith("hi", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("4");
                client.SendMessage($"Hey there {e.ChatMessage.DisplayName}");
                Console.WriteLine("5");
            }
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine("6");//Console.WriteLine(e.Data);
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Error!! {e.Error}");
        }
        internal void Disconnect()
        {
            Console.WriteLine("Disconnecting");
        }
    }
}