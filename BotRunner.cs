using System;
using System.Collections;

namespace TwitchBotSide
{
    public class BotRunner
    {
        public Controller c = new Controller();
        public string mode = "Casual";
        public ArrayList commands = new ArrayList();

        public void ResetPosition()
        {
            Console.WriteLine("Resetting Position...");
            while (BitConverter.ToString(c.ReadBytes(0x6b30f9e0, 4)) != "43-88-F9-FF")
            {
                System.Threading.Thread.Sleep(500);
                c.SendData("click B");
                System.Threading.Thread.Sleep(500);
            }
            c.SendData("click A");
            System.Threading.Thread.Sleep(1000);
        }

        public void JoinRankedGame()
        {

            System.Threading.Thread.Sleep(500);
            c.SendData("click DDOWN");
            System.Threading.Thread.Sleep(2000);
            c.SendData("click DDOWN");
            System.Threading.Thread.Sleep(500);
            c.SendData("click B");
            System.Threading.Thread.Sleep(8000);
            c.SendData("click A");
            System.Threading.Thread.Sleep(500);
            c.SendData("click A");
            System.Threading.Thread.Sleep(500);
            mode = "Casual";

        }

        public void JoinCasualGame()
        {

            c.SendData("click A");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(5000);
            c.SendData("click DDOWN");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            c.SendData("click a");
            System.Threading.Thread.Sleep(1000);
            mode = "Casual";
        }

        //static void Main(string[] args)
        //{
        //    Controller c = new Controller();
        //    Console.WriteLine(BitConverter.ToInt32(c.ReadBytes(0x6b30f9e0, 4), 0));
        //    Console.ReadLine();
        //}

        public void SendCommand(string s)
        {
            c.SendData($"click {s}");
        }

        public string Add(string s)
        {
            commands.Add(s);
            return s;
        }

        public string Remove(string s)
        {
            commands.Remove(s);
            return s;
        }

        public ArrayList GetList()
        {
            return commands;
        }

        public bool IsInGame()
        {
            if (BitConverter.ToString(c.ReadBytes(0x3F12850F, 1)) == "00")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

