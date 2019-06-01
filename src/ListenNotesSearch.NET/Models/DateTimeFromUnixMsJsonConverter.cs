using System;
using ListenNotesSearch.NET.Helpers;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class DateTimeFromUnixMsJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var t = long.Parse(reader.Value.ToString());
            return DateTimeHelpers.DateTimeFromUnixMiliseconds(t);
        }

        public override bool CanConvert(System.Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override bool CanWrite => false;
    }
}