using System;
using System.Collections;
using System.Linq;
using System.Threading;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchBotSide
{
    class Bot
    {

        public ArrayList commands = new ArrayList();

        TwitchClient client;

        public string[] UsableChars = { "a", "b", "x", "y", "plus", "up", "down", "left", "right" };

        public BotRunner b = new BotRunner();

        public bool InGame;

        public Bot()
        {
            ConnectionCredentials creds = new ConnectionCredentials(Info.BotUsername, Info.BotToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(creds, Info.ChannelName);

            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;

            client.Connect();
        }

        public bool Unlock()
        {
            InGame = true;
            return true;
        }

        public bool Lock()
        {
            InGame = false;
            return false;
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Bot Connnected");
            client.SendMessage(e.Channel, "Successfully connected to chat! PogChamp");
            Console.WriteLine(e.Channel);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (UsableChars.Contains(e.ChatMessage.Message.ToLower()))
            {
                if (e.ChatMessage.Message.ToLower() == "up" ||
                    e.ChatMessage.Message.ToLower() == "down" ||
                    e.ChatMessage.Message.ToLower() == "left" ||
                    e.ChatMessage.Message.ToLower() == "right")
                {
                    commands.Add($"D{e.ChatMessage.Message.ToUpper()}");
                    Console.WriteLine($"Added Command D{e.ChatMessage.Message.ToUpper()} to queue");
                }
                else
                {
                    commands.Add(e.ChatMessage.Message.ToUpper());
                    Console.WriteLine($"Added Command {e.ChatMessage.Message.ToUpper()} to queue");
                }

                client.SendMessage(e.ChatMessage.Channel, $"Button \"{e.ChatMessage.Message}\" has successfully been added to queue :)");
            }
        }
        public void MainLoop()
        {
            b.ResetPosition();
            if (b.mode == "Casual")
            {
                b.JoinCasualGame();
            }
            else
            {
                b.JoinRankedGame();
            }
            client.SendMessage(Info.ChannelName.ToLower(), "Starting to search for another trainer!");
            while (true)
            {
                if (commands.Count > 0)
                {
                    Thread.Sleep(1000);
                    b.SendCommand(commands[0].ToString());
                    Console.WriteLine($"Used Command {commands[0].ToString()}");
                    commands.RemoveAt(0);
                }
                if (b.IsInGame())
                {
                    Thread.Sleep(15000);
                    while (b.IsInGame())
                    {
                        if (commands.Count > 0)
                        {
                            Thread.Sleep(1000);
                            b.SendCommand(commands[0].ToString());
                            Console.WriteLine($"Used Command {commands[0].ToString()}");
                            commands.RemoveAt(0);
                        }
                        if (!(b.IsInGame()))
                        {
                            break;
                        }
                    }
                    break;
                }
            }

        }

    }
    class Program
    {
        public static void Main(string[] args)
        {
            Bot bot = new Bot();
            while (true)
            {
                bot.MainLoop();
            }

        }
    }
}