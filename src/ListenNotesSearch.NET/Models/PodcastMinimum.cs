using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class PodcastMinimum 
    {
        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("thumbnail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("publisher", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Publisher { get; set; }
    }
}