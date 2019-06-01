using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class CuratedListSimple
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("source_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceUrl { get; set; }

        [JsonProperty("source_domain", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceDomain { get; set; }

        [JsonProperty("pub_date_ms", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime PubDateMs { get; set; }

        [JsonProperty("listennotes_url", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>Minimum meta data of up to 5 podcasts in this curated list.</summary>
        [JsonProperty("podcasts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PodcastMinimum> Podcasts { get; set; }
    }
}