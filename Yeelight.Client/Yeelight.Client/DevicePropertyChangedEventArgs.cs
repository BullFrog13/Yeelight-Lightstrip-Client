using System.ComponentModel;

namespace Yeelight.Client
{
    public class DevicePropertyChangedEventArgs : PropertyChangedEventArgs
    {
        public virtual YeelightDevice Device { get; }

        public DevicePropertyChangedEventArgs(YeelightDevice device, string propertyName) : base(propertyName)
        {
            Device = device;
        }
    }
}