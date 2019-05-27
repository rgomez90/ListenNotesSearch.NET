using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class BestPodcastsResponse
    {
        [JsonProperty("has_previous", Required = Required.Always)]
        public bool HasPrevious { get; set; }

        /// <summary>This genre's name.</summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("listennotes_url", Required = Required.Always)]
        public string ListennotesUrl { get; set; }

        [JsonProperty("previous_page_number", Required = Required.Always)]
        public int PreviousPageNumber { get; set; }

        [JsonProperty("page_number", Required = Required.Always)]
        public int PageNumber { get; set; }

        [JsonProperty("has_next", Required = Required.Always)]
        public bool HasNext { get; set; }

        [JsonProperty("next_page_number", Required = Required.Always)]
        public int NextPageNumber { get; set; }

        /// <summary>The id of parent genre.</summary>
        [JsonProperty("parent_id", Required = Required.Always)]
        public int ParentId { get; set; }

        /// <summary>The id of this genre</summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("total", Required = Required.Always)]
        public int Total { get; set; }

        [JsonProperty("podcasts", Required = Required.Always)]
        public ICollection<PodcastSimple> Podcasts { get; set; } = new Collection<PodcastSimple>();
    }
}