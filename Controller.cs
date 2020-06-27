using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TwitchBotSide
{
    public class Controller
    {
        private Socket s = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);

        IPAddress ipAddress = IPAddress.Parse(Info.SwitchIP);
        int portI = int.Parse(Info.SwitchPort);

        public Controller()
        {
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, portI);
            s.Connect(remoteEP);
            Console.WriteLine("Succesfully Connected To Device");
        }

        public void SendData(string content)
        {
            byte[] encoded = Encoding.ASCII.GetBytes($"{content}\r\n");
            s.Send(encoded);
        }

        public int Read(byte[] buffer) => s.Receive(buffer);
        private const int BaseDelay = 64;
        private const int DelayFactor = 256;
        public int Send(byte[] buffer) => s.Send(buffer);


        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public byte[] ReadBytes(uint offset, int length)
        {
            var cmd = SwitchCommand.Peek(offset, length);
            Send(cmd);

            Thread.Sleep((length / DelayFactor) + BaseDelay);
            var buffer = new byte[(length * 2) + 1];
            var _ = Read(buffer);
            return Decoder.ConvertHexByteStringToBytes(buffer);
        }

    }
}
