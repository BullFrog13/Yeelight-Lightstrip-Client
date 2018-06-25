using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Yeelight.Client.Core;
using Yeelight.Client.Helpers;
using Yeelight.Client.Interfaces;
using Yeelight.Client.Models;
using Yeelight.Client.Utils;

namespace Yeelight.Client
{
    // set_default set_scene cron_add cron_get cron_del set_ct_abx set_rgb set_hsv set_adjust set_name
    public class YeelightTcpClient : IYeelightTcpClient
    {
        private readonly YeelightDevice _yeelightDevice;

        public YeelightTcpClient(YeelightDevice device)

        {
            _yeelightDevice = device;
        }

        public async Task GetProperties(List<Properties> properties)
        {
            List<object> names = new List<object>();

            foreach (var property in properties)
            {
                names.Add(property);
            }

            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var testCommand = new Command
                    {
                        Id = (int) Methods.GetProp,
                        Method = Methods.GetProp.GetActualName(),
                        Params = names
                    };

                    var request = JsonConvert.SerializeObject(testCommand, new CommandConverter());

                    var data = Encoding.ASCII.GetBytes(request);

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        stream.Write(data, 0, data.Length);

                        var test = stream.DataAvailable;

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        public async Task Toggle()
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var command = new StringBuilder();
                    command.Append("{\"id\":1,\"method\":\"toggle\",\"params\":[]}\r\n");

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        var data = Encoding.ASCII.GetBytes(command.ToString());

                        stream.Write(data, 0, data.Length);

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        public async Task SetColorTemperature(int value, int duration = 0)
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var command = new StringBuilder();
                    command.Append($"{{\"id\":2,\"method\":\"set_ct_abx\",\"params\":[{value},");
                    if (duration == 0)
                    {
                        command.Append("\"sudden\",");
                    }
                    else if (duration >= 30)
                    {
                        command.Append("\"smooth\",");
                    }
                    command.Append($"{duration}]}}\r\n");

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        var data = Encoding.ASCII.GetBytes(command.ToString());
                        stream.Write(data, 0, data.Length);

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        public async Task SetRgbColor(int r, int g, int b, int duration = 0)
        {
            var value = (r << 16) | (g << 8) | b; // todo move to helper
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var command = new StringBuilder();
                    command.Append($"{{\"id\":3,\"method\":\"set_rgb\",\"params\":[{value},");
                    if (duration == 0)
                    {
                        command.Append("\"sudden\",");
                    }
                    else if (duration >= 30)
                    {
                        command.Append("\"smooth\",");
                    }
                    command.Append($"{duration}]}}\r\n");

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        var data = Encoding.ASCII.GetBytes(command.ToString());
                        stream.Write(data, 0, data.Length);

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        public async Task SetHsvColor(int hue, int sat, int duration = 0)
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var command = new StringBuilder();
                    command.Append($"{{\"id\":4,\"method\":\"set_hsv\",\"params\":[{hue},{sat},");
                    if (duration == 0)
                    {
                        command.Append("\"sudden\",");
                    }
                    else if (duration >= 30)
                    {
                        command.Append("\"smooth\",");
                    }
                    command.Append($"{duration}]}}\r\n");

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        var data = Encoding.ASCII.GetBytes(command.ToString());
                        stream.Write(data, 0, data.Length);

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        public async Task SetBrightness(int value, int duration = 0)
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var command = new StringBuilder();
                    command.Append($"{{\"id\":5,\"method\":\"set_bright\",\"params\":[{value},");
                    if (duration == 0)
                    {
                        command.Append("\"sudden\",");
                    }
                    else if (duration >= 30)
                    {
                        command.Append("\"smooth\",");
                    }
                    command.Append($"{duration}]}}\r\n");

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        var data = Encoding.ASCII.GetBytes(command.ToString());
                        stream.Write(data, 0, data.Length);

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        public async Task SetPower(bool value, int mode = 0, int duration = 0)
        {
            var test = "off";
            if (value)
            {
                test = "on";
            }

            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(_yeelightDevice.Ip, 55443);

                if (tcpClient.Connected)
                {
                    var command = new StringBuilder();
                    command.Append($"{{\"id\":6,\"method\":\"set_power\",\"params\":[\"{test}\",");
                    if (duration == 0)
                    {
                        command.Append("\"sudden\",");
                    }
                    else if (duration >= 30)
                    {
                        command.Append("\"smooth\",");
                    }
                    command.Append($"{duration}, 0]}}\r\n");

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        var data = Encoding.ASCII.GetBytes(command.ToString());
                        stream.Write(data, 0, data.Length);

                        var response = new byte[256];
                        int bytes = stream.Read(response, 0, response.Length);
                        string message = Encoding.ASCII.GetString(response, 0, bytes);
                    }
                }
            }
        }

        // todo set_default method

        // todo set_cf method
        
        // todo stop_cf method
    }
}