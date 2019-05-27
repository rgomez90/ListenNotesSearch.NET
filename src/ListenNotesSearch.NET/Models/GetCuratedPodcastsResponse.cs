using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetCuratedPodcastsResponse
    {
        [JsonProperty("has_previous", Required = Required.Always)]
        public bool HasPrevious { get; set; }

        [JsonProperty("previous_page_number", Required = Required.Always)]
        public int PreviousPageNumber { get; set; }

        [JsonProperty("page_number", Required = Required.Always)]
        public int PageNumber { get; set; }

        [JsonProperty("next_page_number", Required = Required.Always)]
        public int NextPageNumber { get; set; }

        [JsonProperty("has_next", Required = Required.Always)]
        public bool HasNext { get; set; }

        [JsonProperty("total", Required = Required.Always)]
        public int Total { get; set; }

        [JsonProperty("curated_lists", Required = Required.Always)]
        public ICollection<CuratedListSimple> CuratedLists { get; set; } = new Collection<CuratedListSimple>();
    }
}