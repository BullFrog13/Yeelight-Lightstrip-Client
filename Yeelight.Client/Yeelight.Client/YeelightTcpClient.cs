using System;
using System.Net.Sockets;
using Yeelight.Client.Interfaces;

namespace Yeelight.Client
{
    public class YeelightTcpClient : IYeelightTcpClient, IDisposable
    {
        private readonly TcpClient _tcpClient;

        public YeelightTcpClient(YeelightDevice device)
        {
            _tcpClient = new TcpClient();
            _tcpClient.Connect(device.GetEndPoint());
        }

        public void ToggleDeviceAsync(YeelightDevice device)
        {
            
        }

        public void Dispose()
        {
            _tcpClient?.Dispose();
        }
    }
}