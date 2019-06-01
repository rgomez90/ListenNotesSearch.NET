using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    /// <summary>When **type** is *episode*.</summary>
    public class EpisodeSearchResult:ISearchResult
    {
        [JsonProperty("audio", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Audio { get; set; }

        [JsonProperty("audio_length_sec", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public int AudioLengthSec { get; set; }

        [JsonProperty("rss", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rss { get; set; }

        /// <summary>Highlighted segment of this episode's description</summary>
        [JsonProperty("description_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionHighlighted { get; set; }

        /// <summary>Plain text of this episode's description</summary>
        [JsonProperty("description_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionOriginal { get; set; }

        /// <summary>Highlighted segment of this episode's title</summary>
        [JsonProperty("title_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string TitleHighlighted { get; set; }

        /// <summary>Plain text of this episode' title</summary>
        [JsonProperty("title_original", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TitleOriginal { get; set; }

        [JsonProperty("podcast_title_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PodcastTitleHighlighted { get; set; }

        [JsonProperty("podcast_title_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PodcastTitleOriginal { get; set; }

        [JsonProperty("publisher_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PublisherHighlighted { get; set; }

        [JsonProperty("publisher_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PublisherOriginal { get; set; }

        /// <summary>Up to 2 highlighted segments of the audio transcript of this episode.</summary>
        [JsonProperty("transcripts_highlighted",Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<string> TranscriptsHighlighted { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("thumbnail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("itunes_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ItunesId { get; set; }

        [JsonProperty("pub_date_ms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime PubDateMs { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("podcast_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PodcastId { get; set; }

        [JsonProperty("genre_ids", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public GenreIdsField GenreIds { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("podcast_listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PodcastListennotesUrl { get; set; }

        [JsonProperty("explicit_content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool ExplicitContent { get; set; }

        public Type Type => Type.Episode;
    }
}