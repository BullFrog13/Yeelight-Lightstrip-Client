using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace Yeelight.Client
{
    public class YeelightDevice : INotifyPropertyChanged
    {
        public const int Port = 554433;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _state;

        public string Id { get; set; }
        public string Ip { get; set; }


        public bool State
        {
            get => _state;
            set => SetField(ref _state, value);
        }
        public string Model { get; set; }
        public string Name { get; set; }

        public YeelightDevice(string id, string ip, bool state, string model, string name)
        {
            Id = id;
            Ip = ip;
            State = state;
            Model = model;
            Name = name;
        }

        public IPEndPoint GetEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(Ip), Port);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}