using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetPodcastsInBatchResponse
    {
        [JsonProperty("podcasts", Required = Required.Always)]
        public ICollection<PodcastSimple> Podcasts { get; set; } = new Collection<PodcastSimple>();

        /// <summary>Up to 10 latest episodes from these podcasts, sorted by **pub_date**. This field shows up only when **show_latest_episodes** is 1.
        /// </summary>
        [JsonProperty("latest_episodes", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<EpisodeSimple> LatestEpisodes { get; set; }
    }
}