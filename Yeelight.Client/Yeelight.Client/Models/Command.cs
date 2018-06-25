using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yeelight.Client.Models
{
    public class Command
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public List<object> Params { get; set; }
    }
}