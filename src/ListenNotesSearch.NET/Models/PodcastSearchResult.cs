using System;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    /// <summary>When **type** is *podcast*.</summary>

    public class PodcastSearchResult: ISearchResult
    {
        [JsonProperty("rss", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rss { get; set; }

        /// <summary>Highlighted segment of podcast description</summary>
        [JsonProperty("description_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionHighlighted { get; set; }

        /// <summary>Plain text of podcast description</summary>
        [JsonProperty("description_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionOriginal { get; set; }

        [JsonProperty("title_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string TitleHighlighted { get; set; }

        [JsonProperty("title_original", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TitleOriginal { get; set; }

        [JsonProperty("publisher_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PublisherHighlighted { get; set; }

        [JsonProperty("publisher_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PublisherOriginal { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("thumbnail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("itunes_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ItunesId { get; set; }

        [JsonProperty("latest_pub_date_ms", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime LatestPubDateMs { get; set; }

        [JsonProperty("earliest_pub_date_ms", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime EarliestPubDateMs { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("genre_ids", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public GenreIdsField GenreIds { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("total_episodes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalEpisodes { get; set; }

        [JsonProperty("email", /*Required = Required.DisallowNull,*/ NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("explicit_content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool ExplicitContent { get; set; }

        public Type Type => Type.Podcast;
    }
}