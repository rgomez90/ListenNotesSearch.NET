using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class PodcastTypeaheadResult
    {
        [JsonProperty("publisher_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PublisherHighlighted { get; set; }

        [JsonProperty("publisher_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PublisherOriginal { get; set; }

        [JsonProperty("explicit_content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool ExplicitContent { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("thumbnail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("title_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string TitleHighlighted { get; set; }

        [JsonProperty("title_original", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TitleOriginal { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}