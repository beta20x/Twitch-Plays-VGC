using System.Linq;
using System.Text;

namespace TwitchBotSide
{
    public static class SwitchCommand
    {
        private static readonly Encoding Encoder = Encoding.ASCII;
        private static byte[] Encode(string command) => Encoder.GetBytes(command + "\r\n");


        public static byte[] DetachController() => Encode("detachController");


        public static byte[] Peek(uint offset, int count) => Encode($"peek 0x{offset:X8} {count}");


        public static byte[] Poke(uint offset, byte[] data) => Encode($"poke 0x{offset:X8} 0x{string.Concat(data.Select(z => $"{z:X2}"))}");

    }
}
