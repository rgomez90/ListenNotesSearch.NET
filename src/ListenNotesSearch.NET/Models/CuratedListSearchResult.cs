using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    /// <summary>When **type** is *curated*.</summary>

    public class CuratedListSearchResult:ISearchResult
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("pub_date_ms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime PubDateMs { get; set; }

        /// <summary>Highlighted segment of this curated list's description</summary>
        [JsonProperty("description_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionHighlighted { get; set; }

        /// <summary>Plain text of this curated list's description</summary>
        [JsonProperty("description_original", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionOriginal { get; set; }

        /// <summary>Highlighted segment of this curated list's title</summary>
        [JsonProperty("title_highlighted", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string TitleHighlighted { get; set; }

        /// <summary>Plain text of this curated list's title</summary>
        [JsonProperty("title_original", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TitleOriginal { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("source_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceUrl { get; set; }

        [JsonProperty("source_domain", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceDomain { get; set; }

        /// <summary>Up to 5 podcasts in this curated list.</summary>
        [JsonProperty("podcasts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PodcastMinimum> Podcasts { get; set; }

        public Type Type => Type.Curated;
    }
}