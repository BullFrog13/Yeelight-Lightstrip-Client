using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace Yeelight.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            ;
            tcpClient.Connect(new IPEndPoint(IPAddress.Parse("192.168.0.105"), 55443));

            if (tcpClient.Connected)
            {
                var command = new StringBuilder(); // 0x0000000004d48562
                command.Append("{\"id\":");
                command.Append("0x0000000004d48562");
                command.Append(",\"method\":\"toggle\",\"params\":[]}\r\n");

                var data = Encoding.ASCII.GetBytes(command.ToString());
                tcpClient.Client.Send(data);
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
