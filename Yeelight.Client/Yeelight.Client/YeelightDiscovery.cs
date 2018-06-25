using System;
using System.Collections.Generic;
using DeviceDiscovery;
using DeviceDiscovery.Models;

namespace Yeelight.Client
{
    public class YeelightDiscovery
    {
        private readonly DiscoveryService _discoveryService;

        public YeelightDiscovery()
        {
            _discoveryService = new DiscoveryService();
        }

        public List<YeelightDevice> DiscoverYeelights()
        {
            var yeelightDiscoveredDevices = _discoveryService.LocateDevices(new MSearchRequest
            {
                Timeout = TimeSpan.FromSeconds(5),
                MulsticastPort = 1982,
                ST = SearchTarget.Yeelight,
                UnicastPort = 1901
            });

            var yeelightDevices = new List<YeelightDevice>();

            foreach (var device in yeelightDiscoveredDevices)
            {
                yeelightDevices.Add(new YeelightDevice(Guid.NewGuid().ToString(), device.Location.Host));
            }

            return yeelightDevices;
        }
    }
}
