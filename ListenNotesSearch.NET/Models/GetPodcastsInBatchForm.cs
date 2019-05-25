using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetPodcastsInBatchForm
    {
        /// <summary>Comma-separated list of podcast ids.</summary>
        [JsonProperty("ids", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Ids { get; set; }

        /// <summary>Comma-separated rss urls.</summary>
        [JsonProperty("rsses", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rsses { get; set; }

        /// <summary>Comma-separated itunes ids.</summary>
        [JsonProperty("itunes_ids", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ItunesIds { get; set; }

        /// <summary>Whether or not to fetch up to 10 latest episodes from these podcasts, sorted by pub_date. 1 is yes, and 0 is no.
        /// </summary>
        [JsonProperty("show_latest_episodes", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public double ShowLatestEpisodes { get; set; }
    }
}