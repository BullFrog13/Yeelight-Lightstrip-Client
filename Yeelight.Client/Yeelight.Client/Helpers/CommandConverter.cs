using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yeelight.Client.Models;

namespace Yeelight.Client.Helpers
{
    public class CommandConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Command);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);

            t.WriteTo(writer);
            writer.WriteRaw("\r\n");
        }

        public override bool CanRead => false;
        public override bool CanWrite => true;
    }
}