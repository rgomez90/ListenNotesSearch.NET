﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class PodcastFull : IPodcast
    {
        [JsonProperty("episodes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<EpisodeMinimum> Episodes { get; set; }

        [JsonProperty("is_claimed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsClaimed { get; set; }

        [JsonProperty("explicit_content", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool ExplicitContent { get; set; }

        [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
        public string Website { get; set; }

        [JsonProperty("total_episodes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalEpisodes { get; set; }

        [JsonProperty("earliest_pub_date_ms", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime EarliestPubDateMs { get; set; }

        [JsonProperty("rss", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rss { get; set; }

        [JsonProperty("latest_pub_date_ms", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime LatestPubDateMs { get; set; }

        [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("language", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("next_episode_pub_date", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateTimeFromUnixMsJsonConverter))]
        public DateTime NextEpisodePubDate { get; set; }
    }
}