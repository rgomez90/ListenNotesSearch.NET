using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class EpisodeFull:IEpisode
    {
        [JsonProperty("maybe_audio_invalid", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool MaybeAudioInvalid { get; set; }

        [JsonProperty("pub_date_ms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int PubDateMs { get; set; }

        [JsonProperty("audio", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Audio { get; set; }

        [JsonProperty("listennotes_edit_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesEditUrl { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("thumbnail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("explicit_content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool ExplicitContent { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("audio_length_sec", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int AudioLengthSec { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("podcast", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PodcastSimple Podcast { get; set; }
    }
}