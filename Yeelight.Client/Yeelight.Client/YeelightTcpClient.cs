using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
            device.PropertyChanged += OnPropertyChanged;
        }

        public void ToggleDeviceAsync(YeelightDevice device)
        {
            
        }

        public void Dispose()
        {
            _tcpClient?.Dispose();
        }

        private void OnPropertyChanged(object o, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "State":
                    Toggle();
                    break;
            }
        }

        private void Toggle()
        {
            if (_tcpClient.Connected)
            {
                var command = new StringBuilder();
                command.Append("{\"id\":");
                command.Append("0x0000000004d48562");
                command.Append(",\"method\":\"toggle\",\"params\":[]}\r\n");

                var data = Encoding.ASCII.GetBytes(command.ToString());
                _tcpClient.Client.Send(data);
            }
        }
    }
}