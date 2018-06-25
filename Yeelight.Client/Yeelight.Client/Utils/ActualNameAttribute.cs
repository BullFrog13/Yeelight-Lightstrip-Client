using System;

namespace Yeelight.Client.Utils
{
    internal class ActualNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ActualNameAttribute(string name)
        {
            Name = name;
        }
    }
}