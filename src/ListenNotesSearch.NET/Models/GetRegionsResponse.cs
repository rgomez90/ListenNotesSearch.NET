using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetRegionsResponse
    {
        [JsonProperty("regions", Required = Required.Always)]
        public object Regions { get; set; } = new object();
    }
}