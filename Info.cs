using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TwitchBotSide
{
    public class Info
    {
        static string FilePath = $@"{Directory.GetCurrentDirectory()}\settings.txt";

        static readonly List<string> Lines = File.ReadAllLines(FilePath).ToList();

        public static string BotToken = Lines[0].Split('=')[1].Trim();
        public static string BotUsername = Lines[1].Split('=')[1].Trim();
        public static string ChannelName = Lines[2].Split('=')[1].Trim();
        public static string SwitchIP = Lines[3].Split('=')[1].Trim();
        public static string SwitchPort = Lines[4].Split('=')[1].Trim();
    }
}
