using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class PodcastSimple
    {
        [JsonProperty("is_claimed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsClaimed { get; set; }

        [JsonProperty("explicit_content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool ExplicitContent { get; set; }

        [JsonProperty("website", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Website { get; set; }

        [JsonProperty("total_episodes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalEpisodes { get; set; }

        [JsonProperty("earliest_pub_date_ms", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int EarliestPubDateMs { get; set; }

        [JsonProperty("rss", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rss { get; set; }

        [JsonProperty("latest_pub_date_ms", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int LatestPubDateMs { get; set; }

        [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("language", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("thumbnail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("publisher", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Publisher { get; set; }

        [JsonProperty("itunes_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ItunesId { get; set; }

        [JsonProperty("looking_for", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PodcastLookingForField LookingFor { get; set; }

        [JsonProperty("extra", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PodcastExtraField Extra { get; set; }

        [JsonProperty("genre_ids", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public GenreIdsField GenreIds { get; set; }
    }
}