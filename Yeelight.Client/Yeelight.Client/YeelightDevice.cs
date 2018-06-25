using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Yeelight.Client
{
    public class YeelightDevice : INotifyPropertyChanged
    {
        public const int Port = 55443;

        public event PropertyChangedEventHandler PropertyChanged;
        private TcpClient _tcpClient;

        public string Id { get; set; }
        public string Ip { get; set; }


        /*public bool State
        {
            get => _state;
            set => SetField(ref _state, value);
        }*/
        public string Model { get; set; }
        public string Name { get; set; }

        public YeelightDevice(string id, string ip)
        {
            Id = id;
            Ip = ip;

            // PropertyChanged += async (o, e) => await OnPropertyChanged((DevicePropertyChangedEventArgs)e);
        }

        /*public async Task<bool> Connect()
        {
            Disconnect();

            _tcpClient = new TcpClient();
            await _tcpClient.ConnectAsync(Ip, 55443);

            return _tcpClient.Connected;
        }

        public void Disconnect()
        {
            if (_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
            }
        }*/








        /*protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new DevicePropertyChangedEventArgs(this, propertyName));
            return true;
        }

        public async Task OnPropertyChanged(DevicePropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "State":
                    await _tcpClient.Toggle(e.De  vice);
                    break;
                default:
                    break;
            }
        }*/
    }
}