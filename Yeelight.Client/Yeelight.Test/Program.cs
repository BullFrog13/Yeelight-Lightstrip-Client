using System.Linq;
using System.Threading;
using Yeelight.Client;

namespace Yeelight.Test
{
    class Program
    {
        static void Main()
        {
            var discovery = new YeelightDiscovery();

            var devices = discovery.DiscoverYeelights();
            var client = new YeelightTcpClient(devices.First());
            Thread.Sleep(5000);
            client.Toggle().Wait();
            Thread.Sleep(4000);
            client.SetColorTemperature(4520).Wait();
            Thread.Sleep(4000);

            client.SetRgbColor(204, 255, 102, 4000).Wait();
            Thread.Sleep(4000);

            client.SetRgbColor(255, 0, 0).Wait();
            Thread.Sleep(4000);

            client.SetHsvColor(255, 50, 2500).Wait();
            Thread.Sleep(4000);

            client.SetBrightness(10, 2500).Wait();
            Thread.Sleep(4000);

            client.SetPower(false).Wait();
            Thread.Sleep(4000);

            client.SetPower(true).Wait();
            Thread.Sleep(4000);
        }
    }
}